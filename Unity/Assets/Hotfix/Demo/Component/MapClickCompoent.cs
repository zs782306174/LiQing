



using System;
using ETModel;
using FairyGUI;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class MapClickComponentAwake: AwakeSystem<MapClickCompoent, UserInputComponent>
    {
        public override void Awake(MapClickCompoent self, UserInputComponent a)
        {
            self.Awake(a);
        }
    }

    [ObjectSystem]
    public class MapClickComponentUpdate: UpdateSystem<MapClickCompoent>
    {
        public override void Update(MapClickCompoent self)
        {
            self.Update();
        }
    }

    [Event(EventIdType.ClickSmallMap)]
    public class SmallMapPathFinder: AEvent<Vector3>
    {
        public override void Run(Vector3 a)
        {
            ETModel.SessionComponent.Instance.Session.Send(new Frame_ClickMap() { X = a.x, Y = a.y, Z = a.z });
        }
    }
    
    public class MapClickCompoent: Component
    {
        private UserInputComponent m_UserInputComponent;
        
        private readonly Frame_ClickMap frameClickMap = new Frame_ClickMap();

        public void Awake(UserInputComponent userInputComponent)
        {
            this.m_UserInputComponent = userInputComponent;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Stage.isTouchOnUI) //点在了UI上
                {
                    //Log.Info("点在UI上");
                }
                else //没有点在UI上
                {
                    //Log.Info("没点在UI上");
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                    {
                        MapPathFinder(hit.point);
                    }
                }
            }
        }
        
        public void MapPathFinder(Vector3 ClickPoint)
        {
            frameClickMap.X = ClickPoint.x;
            frameClickMap.Y = ClickPoint.y;
            frameClickMap.Z = ClickPoint.z;
            ETModel.SessionComponent.Instance.Session.Send(frameClickMap);
            // 测试actor rpc消息
            this.TestActor().Coroutine();
        }
        
        public async ETVoid TestActor()
        {
            try
            {
                M2C_TestActorResponse response = (M2C_TestActorResponse) await SessionComponent.Instance.Session.Call(
                    new C2M_TestActorRequest() { Info = "actor rpc request" });
                Log.Info(response.Info);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}