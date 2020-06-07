
using ETModel;

namespace ETHotfix
{
	public class FUIInitComponent : Component
    {
        public async ETTask Init()
        {
            await ETModel.Game.Scene.GetComponent<FUIPackageComponent>().AddPackageAsync(FUIPackage.FUIGlobal);
        }

        public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

            ETModel.Game.Scene.GetComponent<FUIPackageComponent>().RemovePackage(FUIPackage.FUIGlobal);
        }
    }
}