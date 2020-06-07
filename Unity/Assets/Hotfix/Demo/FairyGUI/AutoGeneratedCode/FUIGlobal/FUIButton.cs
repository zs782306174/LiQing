/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIGlobal
{
    [ObjectSystem]
    public class FUIButtonAwakeSystem : AwakeSystem<FUIButton, GObject>
    {
        public override void Awake(FUIButton self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIButton : FUI
	{	
		public const string UIPackageName = "FUIGlobal";
		public const string UIResName = "FUIButton";
		
		/// <summary>
        /// FUIButton的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GButton self;
		
		public GImage bg;
		public GTextField title;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIButton CreateInstance()
		{			
			return ComponentFactory.Create<FUIButton, GObject>(CreateGObject());
		}

        public static Task<FUIButton> CreateInstanceAsync()
        {
            TaskCompletionSource<FUIButton> tcs = new TaskCompletionSource<FUIButton>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUIButton, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUIButton Create(GObject go)
		{
			return ComponentFactory.Create<FUIButton, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIButton GetFormPool(GObject go)
        {
            var fui = go.Get<FUIButton>();

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
			
			self = (GButton)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				bg = (GImage)com.GetChildAt(0);
				title = (GTextField)com.GetChildAt(1);
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
			bg = null;
			title = null;
		}
	}
}