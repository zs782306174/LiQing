
using Box2DSharp.Common;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using ETModel;
namespace ETHotfix
{
    [ObjectSystem]
    public class ColliderComponentAwakeSystem: AwakeSystem<ColliderComponent,Unit, ColliderShape>
    {
        public override void Awake(ColliderComponent self, Unit beLongUnit,ColliderShape colliderShape)
        {
            self.m_BelongUnit = beLongUnit;
            self.m_Body = B2S_BodyUtility.CreateDynamicBody();
            switch (colliderShape.colliderType)
            {
                case ColliderType.BoxColllider:
                    self.m_Body.CreateBoxFixture(colliderShape.width/2, colliderShape.height / 2, colliderShape.offset, 0, colliderShape.isTriger, self);
                    break;
                case ColliderType.CircleCollider:
                    self.m_Body.CreateCircleFixture(colliderShape.radius, colliderShape.offset, colliderShape.isTriger, self);
                    break;
            }
            Game.Scene.GetComponent<ColliderComponentManagerComponent>().AddColliderEntity(self);
        }
    }

    [ObjectSystem]
    public class B2S_HeroColliderDataFixedUpdateSystem: FixedUpdateSystem<ColliderComponent>
    {
        public override void FixedUpdate(ColliderComponent self)
        {
            if (self.m_Body.IsActive && !Game.Scene.GetComponent<B2S_WorldComponent>().GetWorld().IsLocked)
            {
                self.SyncBody();
            }
        }
    }

    public static class B2S_HeroColliderComponentHelper
    {
        /// <summary>
        /// 同步刚体（依据归属Unit）
        /// </summary>
        /// <param name="self"></param>
        /// <param name="pos"></param>
       
        /// <summary>
        /// 设置刚体状态
        /// </summary>
        /// <param name="self"></param>
        /// <param name="state"></param>
        public static void SetColliderBodyState(this ColliderComponent self, bool state)
        {
            self.m_Body.IsActive = state;
        }
    }
}