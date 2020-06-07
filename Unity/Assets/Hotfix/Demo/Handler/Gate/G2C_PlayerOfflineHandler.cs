



using ETModel;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_PlayerOfflineHandler: AMHandler<G2C_PlayerOffline>
    {
        protected override async ETTask Run(ETModel.Session session, G2C_PlayerOffline message)
        {
            Log.Info("收到了服务端的下线指令");
            switch (message.MPlayerOfflineType)
            {
                case 1:
                    Log.Info("由于长时间未执行操作而离线");
                    break;
                case 2:
                    Log.Info("由于账号被顶而离线");
                    Game.EventSystem.Run(EventIdType.ShowDialogUI, 1, "提示", "很抱歉，由于您的账号在别处登录，您和服务器的连接已断开");
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}