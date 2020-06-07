



using ETModel;

namespace NodeEditorFramework
{
    public abstract partial class Node
    {
        /// <summary>
        /// 获取结点数据
        /// </summary>
        /// <returns></returns>
        public virtual NodeDataForHero HeroData_GetNodeData()
        {
            return null;
        }
    }
}