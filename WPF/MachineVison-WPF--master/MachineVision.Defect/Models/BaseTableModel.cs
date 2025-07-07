using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
    public class BaseTableModel:BindableBase
    {
        private int id;
        private DateTime createTime;
        private DateTime dateTime;

        /// <summary>
        /// 项目ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set
            {
                createTime = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                RaisePropertyChanged();
            }
        }
    }
}
