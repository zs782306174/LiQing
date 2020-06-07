using ETModel;
using FairyGUI;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
	public class FUIComponentAwakeSystem : AwakeSystem<FUIComponent>
	{
		public override void Awake(FUIComponent self)
		{
			
			float idealscreenProportion = FUIComponent.IdealWide * 1.00f / FUIComponent.IdealHigh;
			float screenProportion = Screen.width * 1.00f / Screen.height;
			int match = 0;
			if (screenProportion > idealscreenProportion)
			{
				match = 1;

			}
			GRoot.inst.SetContentScaleFactor(FUIComponent.IdealWide, FUIComponent.IdealHigh,
				match == 1 ? UIContentScaler.ScreenMatchMode.MatchWidth : UIContentScaler.ScreenMatchMode.MatchHeight);
			self.Root = ComponentFactory.Create<FUI, GObject>(GRoot.inst);
		}
	}

	/// <summary>
	/// 管理所有顶层UI, 顶层UI都是GRoot的孩子
	/// </summary>
	public class FUIComponent: Component
	{
		public FUI Root;

		public const int IdealWide = 1024;
		public const int IdealHigh = 640;
		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

            Root.Dispose();
            Root = null;
		}

		public void Add(FUI ui, bool asChildGObject)
		{
			Root?.Add(ui, asChildGObject);
		}
		
		public void Remove(string name)
		{
			Root?.Remove(name);
		}
		
		/// <summary>
		/// 通过名字获得FUI
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public FUI Get(string name)
		{
			return Root?.Get(name);
        }
		
		/// <summary>
		/// 通过ID获得FUI
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public FUI Get(long id)
		{
			return Root?.Get(id.ToString());
		}

        public FUI[] GetAll()
        {
            return Root?.GetAll();
        }

        public void Clear()
        {
            var childrens = GetAll();

            if(childrens != null)
            {
                foreach (var fui in childrens)
                {
                    Remove(fui.Name);
                }
            }
        }
	}
}