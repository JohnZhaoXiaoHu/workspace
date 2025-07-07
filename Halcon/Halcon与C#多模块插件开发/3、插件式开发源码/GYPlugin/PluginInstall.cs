using GYBase;
using System.ComponentModel;
using System.Reflection;

namespace GYPlugin
{
    /// <summary>
    /// 插件的安装类【必须使用反射】，项目与项目之间依赖解耦合
    /// </summary>
    public class PluginInstall
    {
        // 定义安装了插件的列表，必须通过插件名称获取
        // key 代表插件名称
        // value 存储key对应插件的信息
        public static Dictionary<string, PluginInfo> pluginDic = 
            new Dictionary<string, PluginInfo>();


        /// <summary>
        /// 安装用户插件的方法
        /// </summary>
        public static void InstallPlugin() 
        {
            // 清空插件列表
            pluginDic.Clear();
            // 获取插件放置根目录
            string pluginDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Plugins\\Debug\\net8.0-windows");
            // 判断是否有插件
            if (!Directory.Exists(pluginDir)) 
            {
                return;
            }

            try
            {
                // 获取当前目录下所有文件
                var files = Directory.GetFiles(pluginDir);
                // 遍历所有文件
                foreach (var file in files)
                {
                    var newFile =new FileInfo(file);
                    // 获取遍历的文件名称
                    var name = newFile.Name;
                    // 判断是否为插件文件
                    if (!name.StartsWith("GYPlugin.") || !name.EndsWith(".dll")) 
                    {
                        continue;
                    }
                    // 满足条件找到了对应的插件文件GYPlugin.xxxxx.dll
                    // 创建插件文件的反射对象namespace.类名
                    var assembly = Assembly.LoadFrom(newFile.FullName);
                    // 判断是否为插件类
                    foreach (var type in assembly.GetTypes())
                    {
                        // 判断当前遍历的type是否为IPluginBase接口实现类
                        if (typeof(IPluginBase).IsAssignableFrom(type)) 
                        {
                            // 创建插件信息对象
                            var pluginInfo = new PluginInfo();
                            // 解析插件信息
                            ResolvePluginInfo(type, ref pluginInfo);
                            // 把找到插件及对应解析信息放入到列表中
                            pluginDic.Add(pluginInfo.PluginName, pluginInfo );
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// 解析插件信息的方法
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pluginInfo"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ResolvePluginInfo(Type type, ref PluginInfo pluginInfo)
        {
            // 解析类别
            var categories = type.GetCustomAttributes<CategoryAttribute>(true).ToArray();
            // 解析插件名称
            var pluginNames = type.GetCustomAttributes<DisplayNameAttribute>(true).ToArray();
            // 设置到插件信息对象中
            pluginInfo.PluginCategory = categories[0].Category; // 插件类别
            pluginInfo.PluginName = pluginNames[0].DisplayName; // 插件名称
            pluginInfo.PluginType = type; // 插件类型

        }
    }
}
