/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUIFallBleed
{
    [ObjectSystem]
    public class FUIFallBleedAwakeSystem : AwakeSystem<FUIFallBleed, GObject>
    {
        public override void Awake(FUIFallBleed self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIFallBleed : FUI
	{	
		public const string UIPackageName = "FUIFallBleed";
		public const string UIResName = "FUIFallBleed";
		
		/// <summary>
        /// FUIFallBleed的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		public GTextField Tex_ValueToFall;
		public Transition FallingBleed;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIFallBleed CreateInstance()
		{			
			return ComponentFactory.Create<FUIFallBleed, GObject>(CreateGObject());
		}

        public static ETTask<FUIFallBleed> CreateInstanceAsync()
        {
            ETTaskCompletionSource<FUIFallBleed> tcs = new ETTaskCompletionSource<FUIFallBleed>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<FUIFallBleed, GObject>(go));
            });

            return tcs.Task;
        }

        public static FUIFallBleed Create(GObject go)
		{
			return ComponentFactory.Create<FUIFallBleed, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIFallBleed GetFormPool(GObject go)
        {
            var fui = go.Get<FUIFallBleed>();

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
				Tex_ValueToFall = (GTextField)com.GetChild("Tex_ValueToFall");
				FallingBleed = com.GetTransition("FallingBleed");
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
			Tex_ValueToFall = null;
			FallingBleed = null;
		}
	}
}