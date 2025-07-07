using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Helper
{
    /// <summary>
    /// 顺序任务管理器
    /// </summary>
    class SequentialTaskManager
    {
        private ConcurrentQueue<Action> taskQueue = new ConcurrentQueue<Action>();

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="task"></param>
        public void EnqueueTask(Action task)
        {
            taskQueue.Enqueue(task);
        }

        /// <summary>
        /// 执行队列中的所有任务
        /// </summary>
        public void ProcessTasks()
        {
            while (true)
            {
                //将队列中的任务取出，若为空，则退出循序
                if (!taskQueue.TryDequeue(out Action task))
                    return;

                //执行队列中取出的任务
                task.Invoke();
            }
        }
    }
}
