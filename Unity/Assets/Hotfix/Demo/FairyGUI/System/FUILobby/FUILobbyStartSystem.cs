
using ETModel;
using ETHotfix.FUIGlobal;
namespace ETHotfix
{
    [ObjectSystem]
    public class FUILobbyStartSystem: StartSystem<FUILobby>
    {
        public override void Start(FUILobby self)
        {
            GetUserInfo().Coroutine();
            self.enterButton.self.onClick.Add(EnterMapAsync);
        }

        private async ETVoid GetUserInfo()
        {
            G2C_GetUserInfo g2CGetUserInfo = (G2C_GetUserInfo)await Game.Scene.GetComponent<SessionComponent>().Session
                    .Call(new C2G_GetUserInfo() { PlayerId = ETModel.Game.Scene.GetComponent<PlayerComponent>().MyPlayer.Id });
         

            Game.EventSystem.Run(EventIdType.LobbyUIAllDataLoadComplete);
        }
        private void EnterMapAsync()
        {
            ETModel.Game.EventSystem.Run(ETModel.EventIdType.ShowLoadingUI);
            MapHelper.EnterMapAsync().Coroutine();
        }
    }
}