



using B2S_CollisionRelation;
using ETMode;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.NodeEditor
{
    [Node(false, "Box2DSharp/预制件/友方英雄", typeof (B2S_CollisionRelationCanvas))]
    public class B2S_Prefab_FriendHero: Node
    {
        /// <summary>
        /// 内部ID
        /// </summary>
        private const string Id = "友方英雄";

        public override string GetID => Id;

        public override Vector2 DefaultSize => new Vector2(150, 60);

        [ValueConnectionKnob("PrevB2S", Direction.In, "PrevB2SDatas", ConnectionCount.Multi, NodeSide.Left, 30f)]
        [LabelText("左边的输入端")]
        public ValueConnectionKnob PrevSkill;

        [LabelText("上边的输入端")]
        [ValueConnectionKnob("PrevB2Sl", Direction.In, "PrevB2SDatas", ConnectionCount.Multi, NodeSide.Top, 75f)]
        public ValueConnectionKnob PrevSkill1;

        /// <summary>
        /// 碰撞关系数据
        /// </summary>
        public B2S_CollisionInstance MB2SCollisionInstance = new B2S_CollisionInstance();
        
        [LabelText("相关碰撞数据信息")]
        public B2S_PrefabData mPrefabdata = new B2S_PrefabData();
        public override B2S_PrefabData Prefab_GetNodeData()
        {
            return this.mPrefabdata;
        }
        public override B2S_CollisionInstance B2SCollisionRelation_GetNodeData()
        {
            return this.MB2SCollisionInstance;
        }

        private void OnEnable()
        {
            this.MB2SCollisionInstance.Flag = "友方英雄";
            this.MB2SCollisionInstance.nodeDataId = B2S_PrefabIDDefine.FriendHero;
        }

        public override void NodeGUI()
        {
            RTEditorGUI.TextField("标识：" + MB2SCollisionInstance.Flag);
        }
    }
}