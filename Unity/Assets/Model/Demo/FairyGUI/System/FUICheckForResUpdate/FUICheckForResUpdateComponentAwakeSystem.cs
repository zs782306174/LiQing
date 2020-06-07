



namespace ETModel
{
    [ObjectSystem]
    public class FUICheckForResUpdateComponentAwakeSystem: AwakeSystem<FUICheckForResUpdateComponent>
    {
        public override void Awake(FUICheckForResUpdateComponent self)
        {
            self.FUICheackForResUpdate =
                    (FUICheckForResUpdate.UI_FUICheckForResUpdate) Game.Scene.GetComponent<FUIComponent>().Get("FUICheckForResUpdate").GObject;
            self.FUICheackForResUpdate.m_processbar.value = 0;
        }
    }
}