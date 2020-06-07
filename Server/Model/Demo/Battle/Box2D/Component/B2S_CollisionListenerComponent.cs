
using System;
using System.Collections.Generic;
using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;

namespace ETModel
{
    [ObjectSystem]
    public class B2S_CollisionListenerComponentAwake: AwakeSystem<B2S_CollisionListenerComponent>
    {
        public override void Awake(B2S_CollisionListenerComponent self)
        {
            //绑定指定的物理世界，正常来说一个房间一个物理世界,这里是Demo，直接获取了
            Game.Scene.GetComponent<B2S_WorldComponent>().GetWorld().SetContactListener(self);
            //self.TestCollision();
            //self.B2SColliderEntityManagerComponent = Game.Scene.GetComponent<ColliderComponentManagerComponent>();
        }
    }

    /// <summary>
    /// 某一物理世界所有碰撞的监听者，负责碰撞事件的分发
    /// </summary>
    public class B2S_CollisionListenerComponent: Component, IContactListener
    {
        public void BeginContact(Contact contact)
        {
            //这里获取的是碰撞实体
            ColliderComponent aUserEntity = (ColliderComponent) contact.FixtureA.UserData;
            ColliderComponent bUserEntity = (ColliderComponent) contact.FixtureB.UserData;

            if (aUserEntity == null || bUserEntity == null)
            {
                return;
            }
            aUserEntity.OnCollideStart(bUserEntity);
            bUserEntity.OnCollideStart(aUserEntity);
        }

        public void EndContact(Contact contact)
        {
            ColliderComponent aUserEntity = (ColliderComponent) contact.FixtureA.UserData;
            ColliderComponent bUserEntity = (ColliderComponent) contact.FixtureB.UserData;
            if (aUserEntity == null || bUserEntity == null)
            {
                return;
            }
            aUserEntity.OnCollideFinish(bUserEntity);
            bUserEntity.OnCollideFinish(aUserEntity);
        }

        public void PreSolve(Contact contact, in Manifold oldManifold)
        {
        }

        public void PostSolve(Contact contact, in ContactImpulse impulse)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.IsDisposed)
                return;
        }

       
    }
}