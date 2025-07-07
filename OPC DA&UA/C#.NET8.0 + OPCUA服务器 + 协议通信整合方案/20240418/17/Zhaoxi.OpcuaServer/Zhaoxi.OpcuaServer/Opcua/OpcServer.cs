using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.OpcuaServer.Models;

namespace Zhaoxi.OpcuaServer.Opcua
{
    public class OpcServer : StandardServer
    {
        private List<ProtocolModel> ProtocolList { get; set; }
        public OpcServer(List<ProtocolModel> protocolList)
        {
            ProtocolList = protocolList;
        }
        // 生命周期
        protected override void OnServerStarted(IServerInternal server)
        {
            base.OnServerStarted(server);
            // 提示服务器启动完成
        }


        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            // 需要将编辑的节点数据添加到服务器里面
            List<INodeManager> nodes = new List<INodeManager>();

            nodes.Add(new NodeManager(server, configuration, ProtocolList, "http://www.zhaoxiedu.net"));
            return new MasterNodeManager(server, configuration, "", nodes.ToArray());
        }
    }
}
