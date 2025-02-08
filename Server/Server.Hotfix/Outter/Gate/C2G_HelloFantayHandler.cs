using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Server.Hotfix.Event.TestEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Outter.Gate
{
    public class C2G_HelloFantayHandler : Message<C2G_HelloFantay>
    {
        protected override async FTask Run(Session session, C2G_HelloFantay message)
        {
            Log.Debug($"收到客户端消息:{message.Test}");

            var scene = session.Scene;

            scene.EventComponent.Publish(new TestEvent
            {
                Age = 1,
            });

            await scene.EventComponent.PublishAsync(new TestEvent
            {
                Age = 2,
            });

            var timerId1 = scene.TimerComponent.Net.OnceTimer(1000 * 60, new TestEvent
            {
                Age = 3,
            });

            var timerId2 = scene.TimerComponent.Net.OnceTimer(1000 * 60, () =>
            {
                Log.Debug($"触发定时任务");
            });

            await FTask.CompletedTask;
        }
    }
}
