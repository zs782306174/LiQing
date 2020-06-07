

using ETModel;
using ETHotfix.FUIGlobal;
namespace ETHotfix
{
    
    [Event(EventIdType.ShowDialogUI)]
    public class ShowDialogUI: AEvent<string>
    {
        public override void Run(string content)
        {
            FUIDialong Dialong = (FUIDialong)Game.Scene.GetComponent<FUIComponent>().Get(FUIDialong.UIResName);
            if (Dialong == null)
            {
                Dialong = FUIDialong.CreateInstance();
                Dialong.Name = FUIDialong.UIResName;
                Game.Scene.GetComponent<FUIComponent>().Add(Dialong, true);
            }
            else
            {
                Dialong.Visible = true;
            }
            Dialong.GObject.Center();
            Dialong.TipsText.text = content;

            Dialong.confirmBtn.self.onClick.Add(() =>
            {
                Game.EventSystem.Run(EventIdType.CloseDialogUI);
            });

        }
    }

    [Event(ETModel.EventIdType.ShowOfflineDialogUI_Model)]
    public class ShowHotfixDialogUI : AEvent<int, string, string>
    {
        public override void Run(int mode, string tittle, string content)
        {
            FUIDialong Dialong = (FUIDialong)Game.Scene.GetComponent<FUIComponent>().Get(FUIDialong.UIResName);
            if (Dialong == null)
            {
                Dialong = FUIDialong.CreateInstance();
                Dialong.Name = FUIDialong.UIResName;
                Game.Scene.GetComponent<FUIComponent>().Add(Dialong, true);
            }
            else
            {
                Dialong.Visible = true;
            }
            Dialong.GObject.Center();
            Dialong.TipsText.text = content;
            Dialong.confirmBtn.self.onClick.Add(() =>
            {
                //关闭所有UI，回到登录注册界面
                Game.Scene.GetComponent<FUIComponent>().Clear();
                Game.EventSystem.Run(EventIdType.ShowLoginUI);
            });
        }
    }

    [Event(EventIdType.CloseDialogUI)]
    public class CloseDialogUI: AEvent
    {
        public override void Run()
        {
            FUIDialong Dialong = (FUIDialong)Game.Scene.GetComponent<FUIComponent>().Get(FUIDialong.UIResName);
            Dialong.Visible = false;
        }
    }
}