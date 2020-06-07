



using System.Collections.Generic;
using System.ComponentModel;
using ETModel;
using Sirenix.OdinInspector;
using Vector2 = System.Numerics.Vector2;

namespace ETModel
{
    public class B2S_PolygonColliderDataStructure: B2S_ColliderDataStructureBase
    {
        [LabelText("碰撞体所包含的顶点信息(顺时针),可能由多个多边形组成")]
        [DisableInEditorMode]
        public List<List<Vector2>> finalPoints = new List<List<Vector2>>();

        [LabelText("总顶点数")]
        [DisableInEditorMode]
        public int pointCount;
    }
}