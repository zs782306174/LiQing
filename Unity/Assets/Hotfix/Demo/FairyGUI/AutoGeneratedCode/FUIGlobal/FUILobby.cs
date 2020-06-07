/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIGlobal
{
    [ObjectSystem]
    public class FUILobbyAwakeSystem : AwakeSystem<FUILobby, GObject>
    {
        public override void Awake(FUILobby self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUILobby : FUI
	{	
		public const string UIPackageName = "FUIGlobal";
		public const string UIResName = "FUILobby";
		
		/// <summary>
        /// FUILobby的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		public GImage n5;
		public FUIButton enterButton;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUILobby CreateInstance()
		{			
			return ComponentFactory.Create<FUILobby, GObject>(CreateGObject());
		}

        public static Task<FUILobby> CreateInstanceAsync()
        {
            TaskCompletionSource<FUILobby> tcs = new TaskCompletionSource<FUILobby>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUILobby, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUILobby Create(GObject go)
		{
			return ComponentFactory.Create<FUILobby, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUILobby GetFormPool(GObject go)
        {
            var fui = go.Get<FUILobby>();

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
				n5 = (GImage)com.GetChildAt(0);
				enterButton = FUIButton.Create(com.GetChildAt(1));
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
			n5 = null;
			enterButton.Dispose();
			enterButton = null;
		}
	}
}