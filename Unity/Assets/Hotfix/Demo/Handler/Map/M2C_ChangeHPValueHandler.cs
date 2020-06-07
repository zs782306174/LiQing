



using ETModel;

namespace ETHotfix
{
    [MessageHandler]
    public class M2C_ChangeHPValueHandler: AMHandler<M2C_ChangeHeroHP>
    {
        protected override ETTask Run(ETModel.Session session, M2C_ChangeHeroHP message)
        {
            ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.UnitId).GetComponent<HeroDataComponent>().CurrentLifeValue +=
                    message.ChangeHPValue;
            Game.EventSystem.Run(EventIdType.ChangeHPValue, message.UnitId, message.ChangeHPValue);
            return ETTask.CompletedTask;
        }
    }
}