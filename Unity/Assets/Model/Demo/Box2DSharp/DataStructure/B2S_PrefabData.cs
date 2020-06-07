



using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Plugins.NodeEditor
{
    public class B2S_PrefabData
    {
        [LabelText("相关碰撞结点id")]
        public List<long> colliderNodeIDs = new List<long>();
    }
}