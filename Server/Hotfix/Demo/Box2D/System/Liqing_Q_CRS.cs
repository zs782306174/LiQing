
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [Event(EventCollision.Liqing_Q_CRS)]
    public class Liqing_Q_CRS : AEvent<Entity>
    {
        public override void Run(Entity a)
        {
            a.AddComponent<B2S_LiQing_Q_CRS>();
        }
    }

    [ObjectSystem]
    public class B2S_Darius_Q_CRSAwakeSystem: AwakeSystem<B2S_LiQing_Q_CRS>
    {
        public override void Awake(B2S_LiQing_Q_CRS self)
        {
            self.Entity.GetComponent<ColliderComponent>().OnCollideStartAction += self.OnCollideStart;
            //self.Entity.GetComponent<ColliderComponent>().OnCollideSustainAction += self.OnCollideSustain;
            //self.Entity.GetComponent<ColliderComponent>().OnCollideFinishAction += self.OnCollideFinish;
        }
    }

    public class B2S_LiQing_Q_CRS: Component
    {
        /// <summary>
        /// 当发生碰撞时
        /// </summary>
        public void OnCollideStart(ColliderComponent collider)
        
        {
            
            ColliderComponent colliderComponent = this.Entity.GetComponent<ColliderComponent>();
            if (collider.m_BelongUnit.Id == colliderComponent.m_BelongUnit.Id)
            {
                return;
            }
            long skillid = this.Entity.GetComponent<SkillDataComponent>().skillId;
            
            SkillHolder skillHolder = colliderComponent.m_BelongUnit.GetComponent<SkillManagerComponent>().getSkillById(skillid);
            skillHolder.TagartUnit = collider.Entity as Unit;
            skillHolder.SkillState = SkillState.Next;
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