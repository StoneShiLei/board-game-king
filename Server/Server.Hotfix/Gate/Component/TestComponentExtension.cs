using Fantasy;
using Fantasy.Async;
using Server.Entity.Gate.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix.Gate.Component
{
    public static class TestComponentExtension
    {
        public static async FTask TestMethod(this TestComponent self,string value)
        {
            Log.Debug($"TestComponentMethod:{value}");
        }
    }
}
