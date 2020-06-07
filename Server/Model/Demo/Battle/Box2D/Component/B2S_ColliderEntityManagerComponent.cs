
using System.Collections.Generic;

namespace ETModel
{
    /// <summary>
    /// 用于管理一个物理世界中所有的碰撞实体
    /// </summary>
    public class ColliderComponentManagerComponent: Component
    {
        /// <summary>
        /// 用于管理碰撞实体
        /// </summary>
        public Dictionary<long, ColliderComponent> AllColliderEntitys = new Dictionary<long, ColliderComponent>();

        public void AddColliderEntity(ColliderComponent b2SColliderEntity)
        {
            if (this.AllColliderEntitys.ContainsKey(b2SColliderEntity.Entity.Id))
                return;
            this.AllColliderEntitys.Add(b2SColliderEntity.Entity.Id, b2SColliderEntity);
        }

        public void RemoveColliderEntity(long id)
        {
            if (this.AllColliderEntitys.ContainsKey(id))
            {
                this.AllColliderEntitys.Remove(id);
            }
        }

        public ColliderComponent GetColliderEntity(long id)
        {
            if (this.AllColliderEntitys.TryGetValue(id, out var b2SColliderEntity))
            {
                return b2SColliderEntity;
            }
            else
            {
                return null;
            }
        }
    }
}