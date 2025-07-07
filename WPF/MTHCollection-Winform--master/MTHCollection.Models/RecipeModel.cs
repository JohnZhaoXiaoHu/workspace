using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Models
{
    /// <summary>
    /// 配方实体
    /// </summary>
    public class RecipeModel
    {
		
        /// <summary>
        /// 温度高限值
        /// </summary>
		public float TemperatureHeigh { get; set; }

        /// <summary>
        /// 温度低限值
        /// </summary>
        public float TemperatureLow { get; set; }

        /// <summary>
        /// 湿度高限值
        /// </summary>
        public float HumidityHeght { get; set; }


        /// <summary>
        /// 湿度低限值
        /// </summary>
        public float HumidityLow { get; set; }

        /// <summary>
        /// 是否使用温度报警
        /// </summary>
        public bool IsTemperatureAlarmUse { get; set; }
       
        /// <summary>
        /// 是否使用湿度报警
        /// </summary>
        public bool IsHumidityAlarmUse { get; set; }

	}
}
