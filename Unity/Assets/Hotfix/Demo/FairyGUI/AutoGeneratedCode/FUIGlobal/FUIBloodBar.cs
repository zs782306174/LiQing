/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIGlobal
{
    [ObjectSystem]
    public class FUIBloodBarAwakeSystem : AwakeSystem<FUIBloodBar, GObject>
    {
        public override void Awake(FUIBloodBar self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIBloodBar : FUI
	{	
		public const string UIPackageName = "FUIGlobal";
		public const string UIResName = "FUIBloodBar";
		
		/// <summary>
        /// FUIBloodBar的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GProgressBar self;
		
		public GImage n0;
		public GImage bar;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIBloodBar CreateInstance()
		{			
			return ComponentFactory.Create<FUIBloodBar, GObject>(CreateGObject());
		}

        public static Task<FUIBloodBar> CreateInstanceAsync()
        {
            TaskCompletionSource<FUIBloodBar> tcs = new TaskCompletionSource<FUIBloodBar>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUIBloodBar, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUIBloodBar Create(GObject go)
		{
			return ComponentFactory.Create<FUIBloodBar, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIBloodBar GetFormPool(GObject go)
        {
            var fui = go.Get<FUIBloodBar>();

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
			
			self = (GProgressBar)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				n0 = (GImage)com.GetChildAt(0);
				bar = (GImage)com.GetChildAt(1);
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
			n0 = null;
			bar = null;
		}
	}
}