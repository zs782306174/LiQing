



namespace ETModel
{
    [ObjectSystem]
    public class FUILoadingComponentAwakeSystem: AwakeSystem<FUILoadingComponent>
    {
        public override void Awake(FUILoadingComponent self)
        {
            self.FuiLoading = (FUILoading.UI_FUILoading) Game.Scene.GetComponent<FUIComponent>().Get("FUILoading").GObject;
        }
    }
}