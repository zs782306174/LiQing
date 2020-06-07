
using ETModel;
using ETHotfix.FUIGlobal;
namespace ETHotfix
{
    [Event(EventIdType.LoginFinish)]
    public class LoginSuccess_CreateLobbyUI: AEvent
    {
        public override void Run()
        {
            var hotfixui = FUILobby.CreateInstance();
            hotfixui.Name = FUILobby.UIResName;
            hotfixui.GObject.sortingOrder = 999;
            hotfixui.MakeFullScreen();
            Game.Scene.GetComponent<FUIComponent>().Add(hotfixui, true);
        }
    }
    
    [Event(EventIdType.EnterMapFinish)]
    public class CloseLobbyUI: AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<FUIComponent>().Remove(FUILobby.UIResName);
        }
    }
}