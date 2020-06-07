



namespace ETModel
{
    [ObjectSystem]
    public class FUICheckForResUpdateComponentStartSystem: StartSystem<FUICheckForResUpdateComponent>
    {
        public override void Start(FUICheckForResUpdateComponent self)
        {
            StartAsync(self).Coroutine();
        }

        private async ETVoid StartAsync(FUICheckForResUpdateComponent self)
        {
            TimerComponent timerComponent = Game.Scene.GetComponent<TimerComponent>();
            long instanceId = self.InstanceId;
            while (true)
            {
                await timerComponent.WaitAsync(1);

                if (self.InstanceId != instanceId)
                {
                    return;
                }

                BundleDownloaderComponent bundleDownloaderComponent = Game.Scene.GetComponent<BundleDownloaderComponent>();
                if (bundleDownloaderComponent == null)
                {
                    continue;
                }

                if (!bundleDownloaderComponent.CheckResCompleted)
                {
                    self.FUICheackForResUpdate.m_updateInfo.text = "正在为您检查资源更新：" + $"{bundleDownloaderComponent.CheckUpdateResProgress}%";
                    self.FUICheackForResUpdate.m_processbar.value = bundleDownloaderComponent.CheckUpdateResProgress;
                    if (bundleDownloaderComponent.CheckUpdateResProgress == 100)
                    {
                        if (bundleDownloaderComponent.bundles.Count == 1)
                        {
                            self.FUICheackForResUpdate.m_updateInfo.text = "您已是最新版本，祝您游戏愉快。";
                        }
                        else
                        {
                            self.FUICheackForResUpdate.m_updateInfo.text = "检测到有资源更新，即将为您更新资源。";
                        }
                    }
                }
                else
                {
                    self.FUICheackForResUpdate.m_updateInfo.text = "正在为您更新资源：" + $"{bundleDownloaderComponent.UpdateResProgress}%";
                    self.FUICheackForResUpdate.m_processbar.value = bundleDownloaderComponent.UpdateResProgress;
                    if (bundleDownloaderComponent.UpdateResProgress == 100)
                    {
                        self.FUICheackForResUpdate.m_updateInfo.text = "资源更新完成，祝您游戏愉快。";
                    }
                }
            }
        }
    }
}