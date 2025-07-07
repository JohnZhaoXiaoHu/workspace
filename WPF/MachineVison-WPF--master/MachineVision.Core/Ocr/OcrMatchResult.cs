using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.Ocr
{
    public class OcrMatchResult:BindableBase
    {
		private bool isSuccess;
        private string message;
        private double timeSpan;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
		{
			get { return isSuccess; }
			set { isSuccess = value; RaisePropertyChanged(); }
		}

		

		/// <summary>
		/// 消息
		/// </summary>
		public string Message
		{
			get { return message; }
			set { message = value; RaisePropertyChanged(); }
		}


		

		/// <summary>
		/// 耗时
		/// </summary>
		public double TimeSpan
		{
			get { return timeSpan; }
			set { timeSpan = value;RaisePropertyChanged(); }
		}


	}
}
