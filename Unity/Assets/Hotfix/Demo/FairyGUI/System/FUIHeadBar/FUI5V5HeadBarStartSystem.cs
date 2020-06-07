



using ETModel;
using FairyGUI;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class FUIHeadBarStartSystem: StartSystem<FUIHeadBar.HeadBar>
    {
        public override void Start(FUIHeadBar.HeadBar self)
        {
            //self.HPGapList.itemRenderer += (index, item) => { Log.Info("血条更新了"); };
            
        }
    }
}