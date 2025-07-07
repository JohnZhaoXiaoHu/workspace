using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MTHCollection.Tools;

namespace MTHCollection.Models
{
    public class DeviceModel
    {
        public string IP { get; set; }

        public int Port { get; set; }

        [JsonIgnore]
        public bool IsConnected { get; set; }   


        [JsonIgnore]
        public List<GroupModel> GroupList { get; set; } = null;


        /// <summary>
        /// 用于存取设备中所有变量的名称和对应的值的字典
        /// </summary>
        [JsonIgnore]
        private Dictionary<string,object> dicVarible { get; set; } = new Dictionary<string, object>();

        [JsonIgnore]
        public Action<bool,VaribleModel> AlarmAction { get; set; }


        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [JsonIgnore]
        public object  this[string key]
        {
            get
            {
                if(dicVarible.ContainsKey(key))
                {
                    return dicVarible[key];

                }
                return null;
            }
        }

        
        
        /// <summary>
        /// 更新设备中的变量值
        /// </summary>
        /// <param name="v"></param>
        public void UpdateVarible(VaribleModel v)
        {
            if(dicVarible.ContainsKey(v.VaribleName))
            {
                dicVarible[v.VaribleName] = v.Value;
            }
            else
            {
                dicVarible.Add(v.VaribleName, v.Value);
            }
            CheckAlarm(v);
           
        }

       
        

        /// <summary>
        /// 检查报警
        /// </summary>
        /// <param name="varible"></param>
        private void CheckAlarm(VaribleModel varible)
        {

            

            if (varible.IsPosEdgeAlarm && dicVarible.ContainsKey(varible.VaribleName))
            {
                
                if (varible.IsAlarmTrig())//报警触发
                {
                    AlarmAction?.Invoke(true, varible);
                }
                if(varible.IsAlarmFallTrig())//报警消除
                {
                    AlarmAction?.Invoke(false, varible);
                }
            }
            
            
            
        }

       


        /// <summary>
        /// 根据变量名称获取变量
        /// </summary>
        /// <param name="varibleName"></param>
        /// <returns></returns>
        public VaribleModel GetVarible(string varibleName)
        {
            VaribleModel varible = null;
            if(GroupList != null)
            {
                foreach (var group in GroupList)
                {
                    varible = group.VaribleList.Find(v => v.VaribleName == varibleName);
                }
            }
            return varible;
        }
    }
}
