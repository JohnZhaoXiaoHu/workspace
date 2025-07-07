using GYPlugin;

namespace Zhaoxi.NewVision.Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // 安装用户插件
            PluginInstall.InstallPlugin();

            Application.Run(new MainForm());
        }
    }
}