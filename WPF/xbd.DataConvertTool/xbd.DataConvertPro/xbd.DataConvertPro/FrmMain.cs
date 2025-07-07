using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.DataConvertLib;

namespace xbd.DataConvertPro
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            this.dgv_Param.AutoGenerateColumns = false;

            this.lbl_LibPath.Text = Application.StartupPath + "\\xbd.DataConvertLib.dll";
        }

        private Assembly assembly;

        private Type[] types;

        private Type type;

        private MethodInfo[] methods;

        private MethodInfo methodInfo;

        private List<ParamEntity> ParamList;

        private Dictionary<string, string> CurrentClassDesList = new Dictionary<string, string>();

        private Dictionary<string, string> CurrentMethodDesList = new Dictionary<string, string>();

        private void listClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取注释
            string className = this.listClass.SelectedItem.ToString();

            if (CurrentClassDesList.ContainsKey(className))
            {
                this.lbl_Description.Text = CurrentClassDesList[className];
            }

            type = assembly.GetType("xbd.DataConvertLib." + className);

            methods = type.GetMethods();

            this.listMethods.Items.Clear();

            foreach (MethodInfo method in methods)
            {
                //去除默认的四个方法名
                if (method.Name != "Equals" && method.Name != "GetHashCode" && method.Name != "GetType" && method.Name != "ToString")
                {
                    this.listMethods.Items.Add(method.Name);
                }
            }
        }

        private void listMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listMethods.SelectedIndex >= 0)

            {
                methodInfo = methods[this.listMethods.SelectedIndex];

                //获取注释
                string methodName = methodInfo.Name.ToString();

                string key = this.listClass.SelectedItem.ToString() + "." + methodName + "." + this.listMethods.SelectedIndex.ToString();

                if (CurrentMethodDesList.ContainsKey(key))
                {
                    this.lbl_Description.Text = CurrentMethodDesList[key];
                }

                ParameterInfo[] paramsInfo = methodInfo.GetParameters();

                ParamList = new List<ParamEntity>();

                foreach (var item in paramsInfo)
                {

                    ParamEntity paramEntity = new ParamEntity();
                    paramEntity.ParamName = item.Name;
                    paramEntity.ParamType = item.ParameterType;

                    switch (paramEntity.ParamType.Name.ToUpper())
                    {
                        case "BOOLEAN": paramEntity.ParamShowValue = "true"; break;
                        case "BOOLEAN[]":
                            paramEntity.ParamShowValue = JsonConvert.SerializeObject(new bool[] { true, true });
                            break;
                        case "BYTE[]":
                        case "INT16[]":
                        case "UINT16[]":
                        case "INT32[]":
                        case "UINT32[]":
                        case "INT64[]":
                        case "UINT64[]":
                        case "FLOAT[]":
                        case "DOUBLE[]":
                            paramEntity.ParamShowValue = JsonConvert.SerializeObject(new int[] { 1, 2 });
                            break;
                        case "DATAFORMAT":
                            paramEntity.ParamShowValue = "ABCD";
                            break;
                        case "STRING":
                            paramEntity.ParamShowValue = "";
                            break;
                        default:
                            paramEntity.ParamShowValue = "1";
                            break;
                    }

                    ParamList.Add(paramEntity);
                }

                this.dgv_Param.DataSource = null;
                this.dgv_Param.DataSource = ParamList;
            }
        }

        private void btn_Excute_Click(object sender, EventArgs e)
        {
            object obj = Activator.CreateInstance(type);

            foreach (var item in ParamList)
            {
                switch (item.ParamType.Name.ToUpper())
                {
                    case "BOOLEAN":
                        item.ParamSetValue = item.ParamShowValue == "1" || item.ParamShowValue.ToUpper() == "TRUE";
                        break;
                    case "BYTE":
                        item.ParamSetValue = Convert.ToByte(item.ParamShowValue);
                        break;
                    case "INT16":
                        item.ParamSetValue = Convert.ToInt16(item.ParamShowValue);
                        break;
                    case "UINT16":
                        item.ParamSetValue = Convert.ToUInt16(item.ParamShowValue);
                        break;
                    case "INT32":
                        item.ParamSetValue = Convert.ToInt32(item.ParamShowValue);
                        break;
                    case "UINT32":
                        item.ParamSetValue = Convert.ToUInt32(item.ParamShowValue);
                        break;
                    case "INT64":
                        item.ParamSetValue = Convert.ToInt64(item.ParamShowValue);
                        break;
                    case "UINT64":
                        item.ParamSetValue = Convert.ToUInt64(item.ParamShowValue);
                        break;
                    case "SINGLE":
                        item.ParamSetValue = Convert.ToSingle(item.ParamShowValue);
                        break;
                    case "DOUBLE":
                        item.ParamSetValue = Convert.ToDouble(item.ParamShowValue);
                        break;
                    case "BOOLEAN[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<bool[]>(item.ParamShowValue);
                        break;
                    case "BYTE[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<byte[]>(item.ParamShowValue);
                        break;
                    case "INT16[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<short[]>(item.ParamShowValue);
                        break;
                    case "UINT16[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<ushort[]>(item.ParamShowValue);
                        break;
                    case "INT32[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<int[]>(item.ParamShowValue);
                        break;
                    case "UINT32[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<uint[]>(item.ParamShowValue);
                        break;
                    case "INT64[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<long[]>(item.ParamShowValue);
                        break;
                    case "UINT64[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<ulong[]>(item.ParamShowValue);
                        break;
                    case "SINGLE[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<float[]>(item.ParamShowValue);
                        break;
                    case "DOUBLE[]":
                        item.ParamSetValue = JsonConvert.DeserializeObject<double[]>(item.ParamShowValue);
                        break;
                    case "DATAFORMAT":
                        if (Enum.TryParse(item.ParamShowValue, out DataFormat dataFormat))
                        {
                            item.ParamSetValue = dataFormat;
                        }
                        else
                        {
                            item.ParamSetValue = DataFormat.ABCD;
                        }
                        break;
                    default:
                        item.ParamSetValue = item.ParamShowValue.ToString();
                        break;

                }
            }

            object[] paramvalues = ParamList.Select(c => c.ParamSetValue).ToArray();

            try
            {
                object result = methodInfo.Invoke(obj, paramvalues);

                string res = string.Empty;

                switch (result.GetType().Name.ToUpper())
                {
                    case "BOOLEAN":
                    case "BYTE":
                    case "INT16":
                    case "UINT16":
                    case "INT32":
                    case "UINT32":
                    case "INT64":
                    case "UINT64":
                    case "SINGLE":
                    case "DOUBLE":
                        res = result.ToString();
                        break;
                    case "BOOLEAN[]":
                        res = JsonConvert.SerializeObject(((bool[])result).ToList());
                        break;
                    case "BYTE[]":
                        res = JsonConvert.SerializeObject(((byte[])result).ToList());
                        break;
                    case "INT16[]":
                        res = JsonConvert.SerializeObject(((short[])result).ToList());
                        break;
                    case "UINT16[]":
                        res = JsonConvert.SerializeObject(((ushort[])result).ToList());
                        break;
                    case "INT32[]":
                        res = JsonConvert.SerializeObject(((int[])result).ToList());
                        break;
                    case "UINT32[]":
                        res = JsonConvert.SerializeObject(((uint[])result).ToList());
                        break;
                    case "INT64[]":
                        res = JsonConvert.SerializeObject(((long[])result).ToList());
                        break;
                    case "UINT64[]":
                        res = JsonConvert.SerializeObject(((ulong[])result).ToList());
                        break;
                    case "SINGLE[]":
                        res = JsonConvert.SerializeObject(((float[])result).ToList());
                        break;
                    case "DOUBLE[]":
                        res = JsonConvert.SerializeObject(((double[])result).ToList());
                        break;
                    default:
                        res = result.ToString();
                        break;
                }

                this.txt_Result.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("方法执行出错：" + ex.Message);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;//设置初始目录
            openFileDialog.Title = "选择DLL文件";//设置对话框的标题
            openFileDialog.FileName = "";//设置初始选择的文件名为空
            openFileDialog.Multiselect = false;//设置对话框为单选
            openFileDialog.Filter = "DLL文件|*.dll"; //筛选文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.lbl_LibPath.Text = System.IO.Path.GetFullPath(openFileDialog.FileName); //获取文件路径
            }
        }

        private void LoadLib(string filePath)
        {
            this.listClass.Items.Clear();
            this.listMethods.Items.Clear();

            //我们要调用的dll文件路径
            assembly = Assembly.LoadFrom(filePath);

            types = assembly.GetTypes();

            foreach (Type type in types)
            {
                //只获取Lib结束的类
                if (type.Name.EndsWith("Lib"))
                {
                    this.listClass.Items.Add(type.Name);

                    var attribute = type.GetCustomAttribute(typeof(DescriptionAttribute), false);

                    if (attribute != null)
                    {
                        string description = ((DescriptionAttribute)attribute).Description;

                        if (CurrentClassDesList.ContainsKey(type.Name))
                        {
                            CurrentClassDesList[type.Name] = description;
                        }
                        else
                        {
                            CurrentClassDesList.Add(type.Name, description);
                        }
                    }
                    else
                    {
                        CurrentClassDesList.Add(type.Name, "未填写注释");
                    }


                    methods = type.GetMethods();

                    for (int i = 0; i < methods.Length; i++)
                    {
                        if (methods[i].Name != "Equals" && methods[i].Name != "GetHashCode" && methods[i].Name != "GetType" && methods[i].Name != "ToString")
                        {

                            attribute = methods[i].GetCustomAttribute(typeof(DescriptionAttribute), false);


                            //用类名+方法名+索引ID 作为键
                            string key = type.Name + "." + methods[i].Name + "." + i.ToString();

                            if (attribute != null)
                            {
                                string description = ((DescriptionAttribute)attribute).Description;

                                if (CurrentMethodDesList.ContainsKey(key))
                                {
                                    CurrentMethodDesList[key] = description;
                                }
                                else
                                {
                                    CurrentMethodDesList.Add(key, description);
                                }
                            }
                            else
                            {
                                CurrentMethodDesList.Add(key, "未填写注释");
                            }
                        }
                    }
                }
            }
        }

        private void lbl_LibPath_TextChanged(object sender, EventArgs e)
        {
            LoadLib(this.lbl_LibPath.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tssl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    public class ParamEntity
    {
        public string ParamName { get; set; }

        public Type ParamType { get; set; }

        public string ParamShowValue { get; set; }

        public object ParamSetValue { get; set; }

    }
}
