using ETModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETHotfix.Demo.Box2D.System
{
    [Event(EventCollision.Liqing_E_CRS)]
    public class Liqing_E_CRS : AEvent<Entity>
    {
        public override void Run(Entity a)
        {
            a.AddComponent<B2S_LiQing_E_CRS>();
        }
    }

    [ObjectSystem]
    public class B2S_Darius_Q_CRSAwakeSystem : AwakeSystem<B2S_LiQing_E_CRS>
    {
        public override void Awake(B2S_LiQing_E_CRS self)
        {
            self.Entity.GetComponent<ColliderComponent>().OnCollideStartAction += self.OnCollideStart;
            //self.Entity.GetComponent<ColliderComponent>().OnCollideSustainAction += self.OnCollideSustain;
            //self.Entity.GetComponent<ColliderComponent>().OnCollideFinishAction += self.OnCollideFinish;
        }
    }

    public class B2S_LiQing_E_CRS : Component
    {
        /// <summary>
        /// 当发生碰撞时
        /// </summary>
        public void OnCollideStart(ColliderComponent collider)

        {
            
        }

        public void OnCollideSustain(ColliderComponent collider)
        {
            //Log.Info("持续碰撞了");
        }

        public void OnCollideFinish(ColliderComponent collider)
        {
            //Log.Info("不再碰撞了");
        }
    }
}
