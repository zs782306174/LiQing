



using ETMode;

namespace NodeEditorFramework
{
    public abstract partial class Node
    {
        /// <summary>
        /// 获取结点数据
        /// </summary>
        /// <returns></returns>
        public virtual B2S_CollisionInstance B2SCollisionRelation_GetNodeData()
        {
            return null;
        }
    }
}