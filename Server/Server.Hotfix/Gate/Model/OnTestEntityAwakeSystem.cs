using Fantasy;
using Fantasy.Entitas.Interface;
using Server.Entity.Gate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Gate.Model
{
    public class OnTestEntityAwakeSystem : AwakeSystem<TestEntity>
    {
        protected override void Awake(TestEntity self)
        {
            Log.Debug($"TestEntity {self.RuntimeId} is awake");
        }
    }
}
