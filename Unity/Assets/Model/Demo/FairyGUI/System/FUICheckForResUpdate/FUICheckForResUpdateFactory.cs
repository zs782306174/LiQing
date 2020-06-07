



using FairyGUI;

namespace ETModel
{
    public static class FUICheckForResUpdateFactory
    {
        public static FUI Create()
        {
            FUI fui = ComponentFactory.Create<FUI, GObject>(FUICheckForResUpdate.UI_FUICheckForResUpdate.CreateInstance());
            fui.Name = "FUICheckForResUpdate";
            fui.MakeFullScreen();
            return fui;
        }
    }
}