using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DragVision.Controls;
using DragVision.Plugin.Service;
using HalconDotNet;

namespace DragVision.Plugin
{
    public class PluginFactory
    {
        /// <summary>
        /// 插件委托,用于插件服务执行完成后让视图进行显示
        /// </summary>
        public static Action<List<HObject>> PluginViewAction { get; set; } = null;

        /// <summary>
        /// 插件消息委托,用于插件服务执行完成后添加相应的日志
        /// </summary>
        public static Action<string> PluginMessageAction { get; set; } = null;

        /// <summary>
        /// 获取所有的插件类别和插件名称
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<String>> GetAllPluginCategoryAndName()
        {
            //创建一个字典，用于存储插件类别和插件名称
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            //获取当前程序集
            var assembly = Assembly.GetExecutingAssembly();

            //获取当前程序集下所有IPlugin的非抽象类和非接口子类
            var types = assembly
                .GetTypes()
                .Where(t =>
                    typeof(IPlugin).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract
                   
                );// && t.IsSubclassOf(typeof(BasePluginService))

            //获取所有类别特性的标签
            var categorys = types
                .Select(t => t.GetCustomAttribute<CategoryAttribute>())
                .Where(t => t != null)
                .Select(t => t.Category)
                .Distinct()
                .ToArray();

            //遍历每个插件类别,将类别名称和插件名称添加到字典中
            foreach (var category in categorys)
            {
                List<string> pluginNames = new List<string>();
                foreach (var type in types)
                {
                    //获取当前插件类别的特性标签
                    var categoryName = type.GetCustomAttribute<CategoryAttribute>().Category;

                    //获取当前插件的插件名称
                    var pluginName = type.GetCustomAttribute<DisplayNameAttribute>().DisplayName;

                    if (categoryName == category)
                    {
                        pluginNames.Add(pluginName);
                    }
                }
                dic.Add(category, pluginNames);
            }

            return dic;
        }

        /// <summary>
        /// 根据流程节点获取插件服务
        /// </summary>
        /// <param name="node">流程节点</param>
        public static BasePluginService GetPluginService(FlowNode node)
        {
            //获取当前程序集
            var assembly = Assembly.GetExecutingAssembly();

            //获取当前程序集下所有BasePluginService的子类
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BasePluginService)));

            //获取Display特性名称与流程节点插件名称相同的具体类型
            var type = types.FirstOrDefault(t =>
                t.GetCustomAttribute<DisplayNameAttribute>().DisplayName == node.FlowNodeName
            );

            //创建插件服务实例
            var pluginService = Activator.CreateInstance(type) as BasePluginService;

            return pluginService;
        }
    }
}
