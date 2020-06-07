



using FairyGUI;
using UnityEngine;

namespace ETModel
{
    public class SkillGLoaderExtension: GLoader
    {
        protected override void LoadExternal()
        {
            StartToLoadIcon().Coroutine();
        }

        private async ETVoid StartToLoadIcon()
        {
            GameObject HeroAvatars = (GameObject)Game.Scene.GetComponent<ResourcesComponent>().GetAsset("heroavatars.unity3d","HeroAvatars");
            Texture2D tex = HeroAvatars.Get<Sprite>("Darius").texture;
            if (tex != null)
                onExternalLoadSuccess(new NTexture(tex));
            else
                onExternalLoadFailed();
        }
    }
}