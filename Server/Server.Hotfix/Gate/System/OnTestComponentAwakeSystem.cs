using Fantasy;
using Fantasy.Entitas.Interface;
using Server.Entity.Gate.Component;
using Server.Entity.Gate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Gate.Model
{
    public class OnTestComponentAwakeSystem : AwakeSystem<TestComponent>
    {
        protected override void Awake(TestComponent self)
        {
            Log.Debug($"TestComponent {self.RuntimeId} is awake");
        }
    }
}
