using Fantasy;
using Fantasy.Entitas.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entity.Model.TestEntity
{
    public class OnTestEntityAwakeSystem : AwakeSystem<TestEntity>
    {
        protected override void Awake(TestEntity self)
        {
            Log.Debug($"TestEntity {self.RuntimeId} is awake");
        }
    }
}
