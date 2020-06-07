



using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ETMode;
using ETModel;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using NodeEditorFramework;
using Plugins.NodeEditor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace B2S_CollisionRelation
{
    [NodeCanvasType("包含一个英雄所有相关的碰撞关系的Canvas")]
    public class B2S_CollisionRelationCanvas: NodeCanvas
    {
        public override string canvasName => Name;

        [TabGroup("数据部分")]
        [LabelText("保存文件名"), GUIColor(0.9f, 0.7f, 1)]
        public string Name = "CollisionRelation";

        [TabGroup("数据部分")]
        [LabelText("保存路径"), GUIColor(0.1f, 0.7f, 1)]
        [FolderPath]
        public string SavePath;

        /// <summary>
        /// 节点数据载体，用以搜集所有本SO文件的数据
        /// </summary>
        [TabGroup("数据部分")]
        public B2S_CollisionsRelationSupport m_MainDataDic = new B2S_CollisionsRelationSupport();

        /// <summary>
        /// 预制数据结点载体
        /// </summary>
        [TabGroup("数据部分")]
        [DisableInEditorMode]
        public B2S_CollisionsRelationSupport m_PrefabDic = new B2S_CollisionsRelationSupport();

        /// <summary>
        /// 预制数据结点载体,long为结点id，list为结点所包含的数据
        /// </summary>
        [TabGroup("数据部分")]
        [DisableInEditorMode]
        public Dictionary<long, List<long>> m_PrefabDataDic = new Dictionary<long, List<long>>();

        [TabGroup("数据部分")]
        [Button("自动配置所有Node所有数据", 25), GUIColor(0.4f, 0.8f, 1)]
        public void AutoSetNodeData()
        {
            foreach (var VARIABLE in nodes)
            {
                if (VARIABLE is B2S_CollisionRelationForOneHero)
                {
                    ((B2S_CollisionRelationForOneHero) VARIABLE).AutoSetCollisionRelations();
                }
            }

            foreach (var VARIABLE in this.groups)
            {
                foreach (var VARIABLE1 in VARIABLE.pinnedNodes)
                {
                    VARIABLE1.B2SCollisionRelation_GetNodeData().BelongGroup = VARIABLE.title;
                }
            }
        }

        [TabGroup("数据部分")]
        [Button("自动扫描所需Node并添加到字典", 25), GUIColor(0.4f, 0.8f, 1)]
        public void AddAllNodeData()
        {
            this.m_MainDataDic.B2S_CollisionsRelationDic.Clear();
            this.m_PrefabDic.B2S_CollisionsRelationDic.Clear();
            this.m_PrefabDataDic.Clear();
            foreach (var VARIABLE in this.groups)
            {
                if (VARIABLE.title == "GenerateCollision" || VARIABLE.title == "NoGenerateCollision")
                    foreach (var VARIABLE1 in VARIABLE.pinnedNodes)
                    {
                        this.m_MainDataDic.B2S_CollisionsRelationDic.Add(VARIABLE1.B2SCollisionRelation_GetNodeData().nodeDataId,
                            VARIABLE1.B2SCollisionRelation_GetNodeData());
                    }
                else
                {
                    foreach (var VARIABLE2 in VARIABLE.pinnedNodes)
                    {
                        this.m_PrefabDic.B2S_CollisionsRelationDic.Add(VARIABLE2.B2SCollisionRelation_GetNodeData().nodeDataId,
                            VARIABLE2.B2SCollisionRelation_GetNodeData());
                        this.m_PrefabDataDic.Add(VARIABLE2.B2SCollisionRelation_GetNodeData().nodeDataId,
                            VARIABLE2.Prefab_GetNodeData().colliderNodeIDs);
                    }
                }
            }
        }

        [TabGroup("数据部分")]
        [Button("保存碰撞信息为二进制文件", 25), GUIColor(0.4f, 0.8f, 1)]
        public void Save()
        {
            using (FileStream file = File.Create($"{SavePath}/{this.Name}.bytes"))
            {
                BsonSerializer.Serialize(new BsonBinaryWriter(file), this.m_MainDataDic);
            }

            Debug.Log("保存成功");
        }

        [TabGroup("自动生成代码部分")]
        [LabelText("Key为结点flag，value为保存的类名")]
        public Dictionary<(string, B2S_CollisionInstance), string> className = new Dictionary<(string, B2S_CollisionInstance), string>();

        [TabGroup("自动生成代码部分")]
        [LabelText("碰撞关系代码保存路径")]
        [FolderPath]
        public string theCollisionPathWillBeSaved;

        [TabGroup("自动生成代码部分")]
        [LabelText("用于添加碰撞关系组件EventID保存路径")]
        [FolderPath]
        public string theEventIdPathWillBeSaved;

        //用来记录已经生成过的id
        public List<long> hasRegisterIDs = new List<long>();

        [TabGroup("自动生成代码部分")]
        [Button("读取所有结点flag信息(配置保存类名用)", 25), GUIColor(0.4f, 0.8f, 1)]
        public void ReadAllNodeFlag()
        {
            this.AddAllNodeData();
            if (className == null) className = new Dictionary<(string, B2S_CollisionInstance), string>();
            var tempSave = new Dictionary<string, string>();
            foreach (KeyValuePair<(string, B2S_CollisionInstance), string> VARIABLE in className)
            {
                tempSave.Add(VARIABLE.Key.Item1, VARIABLE.Value);
            }

            this.className.Clear();
            foreach (KeyValuePair<long, B2S_CollisionInstance> VARIABLE in this.m_MainDataDic.B2S_CollisionsRelationDic)
            {
                if (VARIABLE.Value.BelongGroup == "GenerateCollision")
                    if (tempSave.ContainsKey(VARIABLE.Value.Flag))
                    {
                        this.className.Add((VARIABLE.Value.Flag, VARIABLE.Value), tempSave[VARIABLE.Value.Flag]);
                    }
                    else
                    {
                        this.className.Add((VARIABLE.Value.Flag, VARIABLE.Value), "");
                    }
            }
        }

        [TabGroup("自动生成代码部分")]
        [Button("开始自动生成代码", 25), GUIColor(0.4f, 0.8f, 1)]
        public void AutoGenerateCollisionCode()
        {
        }
    }
}