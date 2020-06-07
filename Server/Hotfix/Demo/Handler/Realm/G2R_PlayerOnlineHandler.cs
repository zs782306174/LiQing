
using ETModel;
using System;

namespace ETHotfix
{
    [MessageHandler(AppType.Realm)]
    public class G2R_PlayerOnlineHandler: AMRpcHandler<G2R_PlayerOnline, R2G_PlayerOnline>
    {
        protected override async ETTask Run(Session session, G2R_PlayerOnline message, R2G_PlayerOnline response, Action reply)
        {
            //Log.Info("将已在线玩家踢下线");
            await RealmHelper.KickOutPlayer(message.PlayerId, PlayerOfflineTypes.SamePlayerLogin);

            //Log.Info("玩家上线");
            Game.Scene.GetComponent<OnlineComponent>().Add(message.PlayerId, message.PlayerIDInPlayerComponent, message.GateAppID);
            //Log.Info($"玩家{message.playerAccount}上线");
            reply();
        }
    }
}