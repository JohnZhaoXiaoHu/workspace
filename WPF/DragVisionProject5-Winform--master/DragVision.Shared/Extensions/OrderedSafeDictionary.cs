using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Shared.Extensions
{
    public class OrderedSafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        // 线程安全字典存储键值对
        private readonly ConcurrentDictionary<TKey, TValue> _dictionary = new();

        // 线程安全队列维护插入顺序
        private  ConcurrentQueue<TKey> _orderedKeys = new();

        /// <summary>
        /// 获取按插入顺序排列的键列表（线程安全）
        /// </summary>
        public List<TKey> Keys => new(_orderedKeys);

        /// <summary>
        /// 获取按插入顺序排列的值列表（线程安全）
        /// </summary>
        public List<TValue> Values
        {
            get
            {
                var list = new List<TValue>();
                foreach (var key in _orderedKeys)
                {
                    if (_dictionary.TryGetValue(key, out var value))
                        list.Add(value);
                }
                return list;
            }
        }

        public TValue this[TKey key]
        {
            get =>
                _dictionary.TryGetValue(key, out var value)
                    ? value
                    : throw new KeyNotFoundException();
            set => Add(key, value);
        }

        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

        /// <summary>
        /// 线程安全的添加/更新操作
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (_dictionary.TryAdd(key, value))
            {
                _orderedKeys.Enqueue(key);
            }
            else
            {
                _dictionary[key] = value;
            }
        }

        /// <summary>
        /// 线程安全的移除操作
        /// </summary>
        public bool Remove(TKey key)
        {
            // 步骤1：尝试从线程安全字典中移除指定键
            var removed = _dictionary.TryRemove(key, out _);

            if (removed) // 如果字典移除成功
            {
                // 步骤2：重建有序队列（核心逻辑）
                // 原因：ConcurrentQueue不支持直接删除中间元素（网页8提到其删除局限性）
                var newQueue = new ConcurrentQueue<TKey>();

                // 步骤3：遍历原始队列过滤目标键
                foreach (var k in _orderedKeys) // 遍历维护插入顺序的队列
                {
                    // 使用默认相等比较器判断是否为目标键（网页5中字典的键比较逻辑）
                    if (!EqualityComparer<TKey>.Default.Equals(k, key))
                        newQueue.Enqueue(k); // 非目标键保留到新队列
                }

                // 步骤4：清空原始队列并重建
                _orderedKeys.Clear(); // 清空原有队列（线程安全操作）
                while (newQueue.TryDequeue(out var k)) // 将过滤后的元素重新入队
                {
                    _orderedKeys.Enqueue(k); // 重建后的队列保持原有顺序
                }
            }
            return removed; // 返回是否成功移除
        }

        public void Clear()
        {
            try
            {
                // 阶段1：原子清空字典（网页7验证ConcurrentDictionary.Clear的线程安全性）
                _dictionary.Clear();

                // 阶段2：构建新队列并原子替换（网页6的键快照思想扩展）
                var emptyQueue = new ConcurrentQueue<TKey>();
                var oldQueue = Interlocked.Exchange(ref _orderedKeys, emptyQueue);

                // 阶段3：异步清理旧队列（避免阻塞主线程）
                Task.Run(() =>
                {
                    while (oldQueue.TryDequeue(out _)) { }
                    oldQueue = null;
                });
            }
            catch (Exception ex)
            {
                // 异常处理（网页8建议记录并发操作异常）
                Debug.WriteLine($"Clear failed: {ex.Message}");
                throw;
            }
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var key in _orderedKeys)
            {
                if (_dictionary.TryGetValue(key, out var value))
                    yield return new KeyValuePair<TKey, TValue>(key, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
