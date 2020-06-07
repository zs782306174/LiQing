/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIGlobal
{
    [ObjectSystem]
    public class FUILoginAwakeSystem : AwakeSystem<FUILogin, GObject>
    {
        public override void Awake(FUILogin self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUILogin : FUI
	{	
		public const string UIPackageName = "FUIGlobal";
		public const string UIResName = "FUILogin";
		
		/// <summary>
        /// FUILogin的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		public GImage n28;
		public GImage n27;
		public GImage n23;
		public GTextInput accountInput;
		public GImage n24;
		public GTextInput passwordInput;
		public FUIButton loginButton;
		public FUIButton registerButton;
		public GGroup content;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUILogin CreateInstance()
		{			
			return ComponentFactory.Create<FUILogin, GObject>(CreateGObject());
		}

        public static Task<FUILogin> CreateInstanceAsync()
        {
            TaskCompletionSource<FUILogin> tcs = new TaskCompletionSource<FUILogin>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUILogin, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUILogin Create(GObject go)
		{
			return ComponentFactory.Create<FUILogin, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUILogin GetFormPool(GObject go)
        {
            var fui = go.Get<FUILogin>();

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
				n28 = (GImage)com.GetChildAt(0);
				n27 = (GImage)com.GetChildAt(1);
				n23 = (GImage)com.GetChildAt(2);
				accountInput = (GTextInput)com.GetChildAt(3);
				n24 = (GImage)com.GetChildAt(4);
				passwordInput = (GTextInput)com.GetChildAt(5);
				loginButton = FUIButton.Create(com.GetChildAt(6));
				registerButton = FUIButton.Create(com.GetChildAt(7));
				content = (GGroup)com.GetChildAt(8);
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
			n28 = null;
			n27 = null;
			n23 = null;
			accountInput = null;
			n24 = null;
			passwordInput = null;
			loginButton.Dispose();
			loginButton = null;
			registerButton.Dispose();
			registerButton = null;
			content = null;
		}
	}
}