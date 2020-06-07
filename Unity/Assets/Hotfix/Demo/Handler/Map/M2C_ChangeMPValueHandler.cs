



using ETModel;

namespace ETHotfix
{
    [MessageHandler]
    public class M2C_ChangeMPValueHandler: AMHandler<M2C_ChangeHeroMP>
    {
        protected override ETTask Run(ETModel.Session session, M2C_ChangeHeroMP message)
        {
            //Log.Info("接收到蓝量改变事件");
            ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.UnitId).GetComponent<HeroDataComponent>().CurrentMagicValue +=
                    message.ChangeMPValue;
            Game.EventSystem.Run(EventIdType.ChangeMPValue, message.UnitId, message.ChangeMPValue);
            return ETTask.CompletedTask;
        }
    }
}