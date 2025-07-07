using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch
{
    /// <summary>
    /// 模板匹配结果
    /// </summary>
    public class TeamplateMatchResult : BindableBase
    {
        private bool isSucess;
        private BindingList<MatchResult> results;
        private double timeSpan;
        private int matchCount;
        private bool isShowText=true;
        private bool isShowCenter=true;
        private bool isShowMathRegion = true;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSucess
        {
            get { return isSucess; }
            set
            {
                isSucess = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配结果
        /// </summary>
        public BindingList<MatchResult> Results
        {
            get { return results; }
            set
            {
                results = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配时间
        /// </summary>
        public double TimeSpan
        {
            get { return timeSpan; }
            set
            {
                timeSpan = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配到的数量
        /// </summary>
        public int MatchCount
        {
            get { return matchCount; }
            set
            {
                matchCount = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 是否显示文本
        /// </summary>
        public bool IsShowText
        {
            get { return isShowText; }
            set
            {
                isShowText = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 是否显示中心点
        /// </summary>
        public bool IsShowCenter
        {
            get { return isShowCenter; }
            set
            {
                isShowCenter = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 是否显示匹配区域轮廓
        /// </summary>
        public bool IsShowMatchRegion
        {
            get { return isShowMathRegion; }
            set
            {
                isShowMathRegion = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TeamplateMatchResult()
        {
            Results = new BindingList<MatchResult>();
            
        }

        public static explicit operator TeamplateMatchResult(DependencyObject v)
        {
            throw new NotImplementedException();
        }
    }
}
