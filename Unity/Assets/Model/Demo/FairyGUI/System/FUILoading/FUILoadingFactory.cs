



using FairyGUI;

namespace ETModel
{
    public class FUILoadingFactory
    {
        public static FUI Create()
        {
            FUI fui = ComponentFactory.Create<FUI, GObject>(FUILoading.UI_FUILoading.CreateInstance());
            fui.Name = "FUILoading";
            fui.GObject.sortingOrder = 99999;
            return fui;
        }
    }
}