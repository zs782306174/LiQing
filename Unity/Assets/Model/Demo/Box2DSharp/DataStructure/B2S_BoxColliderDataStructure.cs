



using System.ComponentModel;
using System.Numerics;
using Sirenix.OdinInspector;

namespace ETModel
{
    public class B2S_BoxColliderDataStructure: B2S_ColliderDataStructureBase
    {
        [LabelText("x轴方向上的一半长度")]
        [DisableInEditorMode]
        public float hx;

        [LabelText("y轴方向上的一半长度")]
        [DisableInEditorMode]
        public float hy;
        
    }
}