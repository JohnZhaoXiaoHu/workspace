using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaribleConfig.DAL.Helper
{
    public class JsonFileHelper
    {
        /// <summary>
        /// 对象序列化并保存到文件
        /// </summary>
        /// <param name="objectToSerialize">要序列化的类</param>
        /// <param name="filePath">序列化后存储的地址</param>
        public void SerializeAndSave(Object objectToSerialize, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, objectToSerialize);
            }
        }

        /// <summary>
        /// 从Json文件反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T DeserializeAndLoad<T>(string filePath) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            using (FileStream reader = new FileStream(filePath, FileMode.Open))
            {
                using (JsonReader jsonReader = new JsonTextReader(new StreamReader(reader)))
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        /// <summary>
        /// 将对象序列化成json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetJsonString<T>(T model) where T : class
        {
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 将对象集合序列化成json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetJsonString<T>(IList<T> list) where T : class
        {
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 将对象序列化存储为字符串
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string GetJsonString(object o) 
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
