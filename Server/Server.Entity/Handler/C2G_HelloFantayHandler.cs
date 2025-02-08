using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entity.Handler
{
    public class C2G_HelloFantayHandler : Message<C2G_HelloFantay>
    {
        protected override async FTask Run(Session session, C2G_HelloFantay message)
        {
            Log.Debug($"收到客户端消息:{message.Test}");
            await FTask.CompletedTask;
        }
    }
}
