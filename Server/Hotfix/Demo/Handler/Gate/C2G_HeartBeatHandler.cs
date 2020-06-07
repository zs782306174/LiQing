
using System;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class C2G_HeartBeatHandler: AMRpcHandler<C2G_HeartBeat, G2C_HeartBeat>
    {
        protected override async ETTask Run(Session session, C2G_HeartBeat message, G2C_HeartBeat response, Action reply)
        {
            if (session.GetComponent<HeartBeatComponent>() != null)
            {
                session.GetComponent<HeartBeatComponent>().CurrentTime = TimeHelper.ClientNowSeconds();
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}