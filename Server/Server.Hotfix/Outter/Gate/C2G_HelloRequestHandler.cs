using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Server.Entity.Model.TestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Outter.Gate
{
    public class C2G_HelloRequestHandler : MessageRPC<C2G_HelloRequest, G2C_HelloResponse>
    {
        protected override async FTask Run(Session session, C2G_HelloRequest request, G2C_HelloResponse response, Action reply)
        {
            Log.Debug($"收到来自客户端的请求：{request.Test}");

            var testEntity = Fantasy.Entitas.Entity.Create<TestEntity>(session.Scene, true, true);

            response.TestRes = testEntity.RuntimeId.ToString();

            await FTask.CompletedTask;
        }
        //如不调用reply方法，执行完Run方法后会自动调用reply方法，将response发送给调用端
    }
}
