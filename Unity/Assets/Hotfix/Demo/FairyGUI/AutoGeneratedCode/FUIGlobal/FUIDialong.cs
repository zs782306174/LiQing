/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIGlobal
{
    [ObjectSystem]
    public class FUIDialongAwakeSystem : AwakeSystem<FUIDialong, GObject>
    {
        public override void Awake(FUIDialong self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIDialong : FUI
	{	
		public const string UIPackageName = "FUIGlobal";
		public const string UIResName = "FUIDialong";
		
		/// <summary>
        /// FUIDialong的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		public GImage n4;
		public FUIButton confirmBtn;
		public GTextField TipsText;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIDialong CreateInstance()
		{			
			return ComponentFactory.Create<FUIDialong, GObject>(CreateGObject());
		}

        public static Task<FUIDialong> CreateInstanceAsync()
        {
            TaskCompletionSource<FUIDialong> tcs = new TaskCompletionSource<FUIDialong>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUIDialong, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUIDialong Create(GObject go)
		{
			return ComponentFactory.Create<FUIDialong, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIDialong GetFormPool(GObject go)
        {
            var fui = go.Get<FUIDialong>();

            if(fui == null)
            {
                fui = Create(go);
            }

            fui.isFromFGUIPool = true;

            return fui;
        }
						
		public void Awake(GObject go)
		{
			if(go == null)
			{
				return;
			}
			
			GObject = go;	
			
			if (string.IsNullOrWhiteSpace(Name))
            {
				Name = Id.ToString();
            }
			
			self = (GComponent)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				n4 = (GImage)com.GetChildAt(0);
				confirmBtn = FUIButton.Create(com.GetChildAt(1));
				TipsText = (GTextField)com.GetChildAt(2);
			}
		}
		
		public override void Dispose()
		{
			if(IsDisposed)
			{
				return;
			}
			
			base.Dispose();
			
			self.Remove();
			self = null;
			n4 = null;
			confirmBtn.Dispose();
			confirmBtn = null;
			TipsText = null;
		}
	}
}