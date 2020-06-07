



using ETModel;

namespace ETHotfix
{
    public class HotfixUnitFactory
    {
        public static HotfixUnit CreateHotfixUnit(Unit unit)
        {
            HotfixUnit hotfixUnit = ComponentFactory.CreateWithId<HotfixUnit, Unit>(unit.Id, unit);
            //Log.Info($"此英雄的热更层ID为{hotfixUnit.Id}");
            Game.Scene.GetComponent<M5V5GameComponent>().AddHotfixUnit(hotfixUnit.Id, hotfixUnit);
            return hotfixUnit;
        }
    }
}