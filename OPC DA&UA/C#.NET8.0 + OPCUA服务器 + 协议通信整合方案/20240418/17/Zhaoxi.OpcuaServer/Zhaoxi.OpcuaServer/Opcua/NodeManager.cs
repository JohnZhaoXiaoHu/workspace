using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.OpcuaServer.Models;

namespace Zhaoxi.OpcuaServer.Opcua
{
    public class NodeManager : CustomNodeManager2
    {
        private List<ProtocolModel> ProtocolList { get; set; }

        public NodeManager(
            IServerInternal server,
            ApplicationConfiguration configuration,
            List<ProtocolModel> protocolList,
            params string[] namespaceUris)
            : base(server, configuration, namespaceUris)
        {
            ProtocolList = protocolList;
        }

        List<BaseDataVariableState> _variables = new List<BaseDataVariableState>();
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            // 创建节点树
            base.CreateAddressSpace(externalReferences);

            if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out IList<IReference> _reference))
            {
                externalReferences[ObjectIds.ObjectsFolder] = _reference = new List<IReference>();
            }

            foreach (var p in ProtocolList)
            {
                var folder = CreateFolder(null, p.Name);

                folder.AddReference(ReferenceTypes.Organizes, true, ObjectIds.ObjectsFolder);
                _reference?.Add(new NodeStateReference(ReferenceTypes.Organizes, false, folder.NodeId));

                // 添加Device Folder
                foreach (var d in p.DeviceList)
                {
                    var d_folder = CreateFolder(folder, p.Name + "." + d.DName);

                    // 添加变量 VariableState
                    foreach (var v in d.VariableList)
                    {
                        var variable = this.CreateVaiable(d_folder, p.Name + "." + d.DName + "." + v.Name,
                              DataTypeIds.Int16);

                        _variables.Add(variable);
                    }
                }

                AddPredefinedNode(SystemContext, folder);
            }

            Monitor();
        }

        private FolderState CreateFolder(NodeState parent, string name)
        {
            FolderState folder = new FolderState(parent);

            folder.SymbolicName = name;
            folder.ReferenceTypeId = ReferenceTypes.Organizes;
            folder.TypeDefinitionId = Opc.Ua.ObjectTypeIds.FolderType;
            folder.NodeId = new NodeId(name, NamespaceIndex);
            folder.BrowseName = new QualifiedName(name, NamespaceIndex);
            folder.DisplayName = new LocalizedText("zh", name);
            folder.Description = "Zhaoxi Folder - " + name;

            if (parent != null)
            {
                parent.AddChild(folder);
            }

            return folder;
        }

        private BaseDataVariableState CreateVaiable(NodeState parent, string name, NodeId dataType)
        {
            BaseDataVariableState variable = new BaseDataVariableState(parent);

            variable.Description = "Zhaoxi Variable - " + name;
            variable.SymbolicName = name;
            variable.ReferenceTypeId = ReferenceTypes.Organizes;
            variable.TypeDefinitionId = VariableTypeIds.BaseDataVariableType;
            variable.NodeId = new NodeId(name, NamespaceIndex);
            variable.BrowseName = new QualifiedName(name, NamespaceIndex);
            variable.DisplayName = new LocalizedText("en", name);

            variable.DataType = dataType;
            variable.ValueRank = ValueRanks.Scalar;

            variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Historizing = false;
            variable.Value = 123;
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.Now;

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }

        private void Monitor()
        {
            Task.Run(() =>
            {
                //foreach (var p in ProtocolList)
                {
                    //if (p.Name == "ModbusRTU")
                    {
                        SerialPort serialPort = new SerialPort("COM3");
                        serialPort.Open();
                        //p.DeviceList[0].PropertyList;
                        Modbus.Device.ModbusMaster master =
                            Modbus.Device.ModbusSerialMaster.CreateRtu(serialPort);
                        while (true)
                        {
                            // 温度值
                            ushort value = master.ReadHoldingRegisters(1, 0, 1)[0];

                            _variables[0].Value = value;
                            _variables[0].ClearChangeMasks(SystemContext, false);
                        }
                    }
                }
            });
        }
    }
}
