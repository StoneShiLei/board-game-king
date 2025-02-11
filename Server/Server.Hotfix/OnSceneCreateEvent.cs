using Fantasy;
using Fantasy.Async;
using Fantasy.Event;
using Server.Entity.Gate.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hotfix
{
    /// <summary>
    /// 当Scene创建时，为其添加组件
    /// </summary>
    public class OnSceneCreateEvent : AsyncEventSystem<OnCreateScene>
    {
        protected override async FTask Handler(OnCreateScene self)
        {
            var scene = self.Scene;

            switch (scene.SceneType)
            {
                case SceneType.Gate:
                    scene.AddComponent<TestComponent>();
                    break;
                case SceneType.Addressable:
                    break;
            }

            await FTask.CompletedTask;
        }
    }
}
