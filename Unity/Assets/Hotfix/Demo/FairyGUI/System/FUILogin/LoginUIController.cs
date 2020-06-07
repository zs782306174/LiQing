using ETModel;
using ETHotfix.FUIGlobal;
using UnityEngine;
namespace ETHotfix
{
    [Event(EventIdType.ShowLoginUI)]
    public class ShowLoginUI: AEvent
    {
        public override void Run()
        {
            FUILogin fuiLogin = FUILogin.CreateInstance();
            fuiLogin.Name = FUILogin.UIResName;
            fuiLogin.GObject.MakeFullScreen();
            Game.Scene.GetComponent<FUIComponent>().Add(fuiLogin, true);
        }
    }
    [Event(EventIdType.LobbyUIAllDataLoadComplete)]
    public class CloseLoginUI : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<FUIComponent>().Remove(FUILogin.UIResName);
        }
    }
}