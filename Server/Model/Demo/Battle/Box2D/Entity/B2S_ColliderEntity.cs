
using System;
using System.Collections.Generic;
using Box2DSharp.Dynamics;

using Box2DSharp.Common;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
namespace ETModel
{
    /// <summary>
    /// 一个碰撞体,为一个实体
    /// </summary>
    public class ColliderComponent : Component
    {
        /// <summary>
        /// Box2D世界中的刚体
        /// </summary>
        public Body m_Body;
        
        /// <summary>
        /// 所归属的Unit
        /// </summary>
        public Unit m_BelongUnit;
        public bool IsActive { get => m_Body.IsActive; set => m_Body.IsActive = value; }

        /// <summary>
        /// 碰撞开始事件
        /// </summary>
        public event Action<ColliderComponent> OnCollideStartAction;

        /// <summary>
        /// 碰撞结束事件
        /// </summary>
        public event Action<ColliderComponent> OnCollideFinishAction;

        /// <summary>
        /// 碰撞持续事件
        /// </summary>,
        public event Action<ColliderComponent> OnCollideSustainAction;
        /// <summary>
        /// 碰撞开始
        /// </summary>
        /// <param name="b2SFixtureUserData"></param>
        public void OnCollideStart(ColliderComponent b2SColliderEntity)
        {
            this.OnCollideStartAction?.Invoke(b2SColliderEntity);
        }

        /// <summary>
        /// 碰撞结束
        /// </summary>
        /// <param name="b2SFixtureUserData"></param>
        public void OnCollideFinish(ColliderComponent b2SColliderEntity)
        {
            this.OnCollideFinishAction?.Invoke(b2SColliderEntity);
        }

        /// <summary>
        /// 碰撞持续
        /// </summary>
        /// <param name="b2SFixtureUserData"></param>
        public void OnCollideSustain(ColliderComponent b2SColliderEntity)
        {
            this.OnCollideSustainAction?.Invoke(b2SColliderEntity);
        }
        public void SyncBody()
        {
            SetColliderBodyPos(new Vector2((Entity as Unit).Position.x, (Entity as Unit).Position.z));
            SetColliderBodyAngle(-Quaternion.QuaternionToEuler((Entity as Unit).Rotation).y * Settings.Pi / 180);
        }
        /// <summary>
        /// 设置刚体位置
        /// </summary>
        /// <param name="self"></param>
        /// <param name="pos"></param>
        public void SetColliderBodyPos(Vector2 pos)
        {
            m_Body.SetTransform(pos, m_Body.GetAngle());
        }

        /// <summary>
        /// 设置刚体角度
        /// </summary>
        /// <param name="self"></param>
        /// <param name="angle"></param>
        public void SetColliderBodyAngle(float angle)
        {
            m_Body.SetTransform(m_Body.GetPosition(), angle);
        }
        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            B2S_BodyUtility.DestroyBody(this.m_Body);
            base.Dispose();

            if (this.OnCollideStartAction != null)
            {
                foreach (var VARIABLE in this.OnCollideStartAction.GetInvocationList())
                {
                    OnCollideStartAction -= VARIABLE as Action<ColliderComponent>;
                }
                this.OnCollideStartAction = null;
            }
            
            if (this.OnCollideFinishAction != null)
            {
                foreach (var VARIABLE in this.OnCollideFinishAction.GetInvocationList())
                {
                    OnCollideFinishAction -= VARIABLE as Action<ColliderComponent>;
                }
                this.OnCollideFinishAction = null;
            }
            if (this.OnCollideSustainAction != null)
            {
                foreach (var VARIABLE in this.OnCollideSustainAction.GetInvocationList())
                {
                    OnCollideSustainAction -= VARIABLE as Action<ColliderComponent>;
                }
                this.OnCollideSustainAction = null;
            }
            
        }
    }
}