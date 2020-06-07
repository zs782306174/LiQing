



using ETModel;
using Plugins.NodeEditor;

namespace NodeEditorFramework
{
    public abstract partial class Node
    {
        /// <summary>
        /// 获取结点数据
        /// </summary>
        /// <returns></returns>
        public virtual B2S_PrefabData Prefab_GetNodeData()
        {
            return null;
        }
    }
}