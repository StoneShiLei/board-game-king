using Fantasy;
using Fantasy.Async;
using Fantasy.Event;
using Server.Entity.Gate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Gate.Event
{
    public class OnTestEvent : EventSystem<TestEvent>
    {
        protected override void Handler(TestEvent self)
        {
            Log.Debug($"接收到TestEvent事件：{self.Age}");
        }
    }

    public class OnTestEventAsync : AsyncEventSystem<TestEvent>
    {
        protected override async FTask Handler(TestEvent self)
        {
            Log.Debug($"接收到TestEvent异步事件：{self.Age}");

            await FTask.CompletedTask;
        }
    }
}
