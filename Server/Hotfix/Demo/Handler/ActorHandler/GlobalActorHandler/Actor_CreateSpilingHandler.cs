
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class Actor_CreateSpilingHandler: AMActorLocationHandler<Unit, Actor_CreateSpiling>
    {
        protected override ETTask Run(Unit entity, Actor_CreateSpiling message)
        {
            Unit unit = ComponentFactory.CreateWithId<Unit>(IdGenerater.GenerateId());
            //Log.Info($"服务端响应木桩请求，父id为{message.ParentUnitId}");
            Game.Scene.GetComponent<UnitComponent>().Get(message.ParentUnitId).GetComponent<ChildrenUnitComponent>().AddUnit(unit);

            NodeDataForHero nodeDataForHero = unit.AddComponent<HeroDataComponent, long>(10001).NodeDataForHero;
            //unit.AddComponent<SkillManagerComponent, SkillData[]>(nodeDataForHero.skillDatas);
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<ColliderComponent, Unit, ColliderShape>(unit, nodeDataForHero.colliderShape);
            unit.AddComponent<B2S_RoleCastComponent>().RoleCast = RoleCast.Adverse;
            //设置木桩位置
            unit.Position = new Vector3(message.X, 0, message.Z);
            // 广播创建的木桩unit
            M2C_CreateSpilings createSpilings = new M2C_CreateSpilings();

            SpilingInfo spilingInfo = new SpilingInfo();
            spilingInfo.X = unit.Position.x;
            spilingInfo.Y = unit.Position.y;
            spilingInfo.Z = unit.Position.z;
            spilingInfo.UnitId = unit.Id;
            spilingInfo.ParentUnitId = message.ParentUnitId;
            createSpilings.Spilings = spilingInfo;

            MessageHelper.Broadcast(createSpilings);
            return ETTask.CompletedTask;
        }
    }
}