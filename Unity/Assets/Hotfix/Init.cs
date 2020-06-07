﻿using System;
using ETModel;
namespace ETHotfix
{
    public static class Init
    {
        public static async void Start()
        {
#if ILRuntime
			if (!Define.IsILRuntime)
			{
				Log.Error("mono层是mono模式, 但是Hotfix层是ILRuntime模式");
			}
#else
            if (Define.IsILRuntime)
            {
                Log.Error("mono层是ILRuntime模式, Hotfix层是mono模式");
            }
#endif

            try
            {
                ETModel.Game.EventSystem.Run(ETModel.EventIdType.ShowLoadingUI);
                // 注册热更层回调
                ETModel.Game.Hotfix.Update = () => { Update(); };
                ETModel.Game.Hotfix.FixedUpdate = () => { FixedUpdate(); };
                ETModel.Game.Hotfix.LateUpdate = () => { LateUpdate(); };
                ETModel.Game.Hotfix.OnApplicationQuit = () => { OnApplicationQuit(); };

                Game.Scene.AddComponent<OpcodeTypeComponent>();
                Game.Scene.AddComponent<MessageDispatcherComponent>();

                ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("config.unity3d");
                Game.Scene.AddComponent<ConfigComponent>();
                ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");

                UnitConfig unitConfig = (UnitConfig) Game.Scene.GetComponent<ConfigComponent>().Get(typeof (UnitConfig), 1001);
                Log.Debug($"config {JsonHelper.ToJson(unitConfig)}");

                //增加FGUI组件
                Game.Scene.AddComponent<FUIComponent>();
                //初始化UI操作
                await Game.Scene.AddComponent<FUIInitComponent>().Init();
                //增加UI栈组件，方便管理UI
                Game.Scene.AddComponent<FUIStackComponent>();
                

                //至此，检查更新界面使命正式结束
                ETModel.Game.EventSystem.Run(ETModel.EventIdType.CheckForUpdateFinish);
                //显示登录UI
                ETModel.Game.EventSystem.Run(ETModel.EventIdType.CloseLoadingUI);
                ETModel.Game.EventSystem.Run(EventIdType.ShowLoginUI);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void Update()
        {
            try
            {
                Game.EventSystem.Update();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void FixedUpdate()
        {
            try
            {
                Game.EventSystem.FixedUpdate();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void LateUpdate()
        {
            try
            {
                Game.EventSystem.LateUpdate();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void OnApplicationQuit()
        {
            Game.Close();
        }
    }
}