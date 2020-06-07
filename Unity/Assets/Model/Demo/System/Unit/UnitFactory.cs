﻿using UnityEngine;

namespace ETModel
{
    public static class UnitFactory
    {
        public static Unit Create(string unitType, long id)
        {
            PrepareHeroRes(unitType);
            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            Unit unit = Game.Scene.GetComponent<GameObjectPool<Unit>>().FetchWithId(id, unitType);
            //增加子实体组件，用于管理子实体
            unit.AddComponent<ChildrenUnitComponent>();
            unit.AddComponent<AnimationComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<TurnComponent>();
            unit.AddComponent<UnitPathComponent>();
            unit.AddComponent<EffectComponent>();
            unitComponent.Add(unit);
            return unit;
        }

        /// <summary>
        /// 创建木桩
        /// </summary>
        /// <param name="selfId">自己的id</param>
        /// <param name="parentId">父实体id</param>
        /// <returns></returns>
        public static Unit CreateSpiling(long selfId, long parentId)
        {
            PrepareHeroRes("NuoKe");

            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            Unit unit = Game.Scene.GetComponent<GameObjectPool<Unit>>().FetchWithId(selfId, "NuoKe");
            //Log.Info($"此英雄的Model层ID为{unit.Id}");

            //增加子实体组件，用于管理子实体
            unit.AddComponent<ChildrenUnitComponent>();
            unit.AddComponent<AnimationComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<TurnComponent>();
            unit.AddComponent<EffectComponent>();
            unitComponent.Get(parentId).GetComponent<ChildrenUnitComponent>().AddUnit(unit);
            return unit;
        }

        /// <summary>
        /// 准备英雄资源
        /// </summary>
        /// <param name="heroType"></param>
        private static void PrepareHeroRes(string heroType)
        {
            ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject) resourcesComponent.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(heroType);
            Game.Scene.GetComponent<GameObjectPool<Unit>>().Add(heroType, prefab);
        }

        /// <summary>
        /// 用于NPBehave测试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Unit NPBehaveTestCreate()
        {
            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            Unit unit = ComponentFactory.Create<Unit>();
            unitComponent.Add(unit);
            return unit;
        }
    }
}