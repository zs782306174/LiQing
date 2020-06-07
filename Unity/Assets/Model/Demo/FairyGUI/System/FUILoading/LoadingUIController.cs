



namespace ETModel
{
    [Event(EventIdType.CreateLoadingUI)]
    public class CreateLoadingEvent_CreateLoadingUI: AEvent
    {
        public override void Run()
        {
            FUI fui = FUILoadingFactory.Create();
            Game.Scene.GetComponent<FUIComponent>().Add(fui);
            fui.AddComponent<FUILoadingComponent>();
        }
    }
    
    [Event(EventIdType.CloseLoadingUI)]
    public class RequireCloseLoadingUI_CloseLoadingUI: AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<FUIComponent>().Get("FUILoading").Visible = false;
            Log.Info("加载UI关闭");
        }
    }
    
    [Event(EventIdType.ShowLoadingUI)]
    public class RequireLoadingUIEvent_ShowLoadingUI: AEvent
    {
        public override void Run()
        {
            var fui = Game.Scene.GetComponent<FUIComponent>().Get("FUILoading");
            fui.GObject.Center();
            fui.GObject.visible = true;
            Log.Info("加载UI显示");
        }
    }
}