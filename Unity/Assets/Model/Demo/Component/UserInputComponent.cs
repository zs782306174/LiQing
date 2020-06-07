
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class UserInputComponentAwakeSystem : AwakeSystem<UserInputComponent>
    {
        public override void Awake(UserInputComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class UserInputComponentUpdateSystem : UpdateSystem<UserInputComponent>
    {
        
        public override void Update(UserInputComponent self)
        {
            self.Update();
        }
    }

    public class UserInputComponent : Component
    {
        private static UserInputComponent instance;
        private List<KeyCode> keys = new List<KeyCode>();
        public Dictionary<KeyCode, bool> keyBoardDown = new Dictionary<KeyCode, bool>();
        public Dictionary<KeyCode, bool> keyBoardUp = new Dictionary<KeyCode, bool>();
        public Dictionary<KeyCode, float> keyBoardStayTime = new Dictionary<KeyCode, float>();
        private Unit selectUnit = null;
        public List<Vector3> points = new List<Vector3>();
        public float dealTime = 0.01f;

        public static UserInputComponent Instance { get => instance; set => instance = value; }
        public Unit SelectUnit { get => selectUnit; set => selectUnit = value; }

        public void Awake()
        {
            //应读取设置配置
            Instance = this;
            keys.Add(KeyCode.Q);
            keys.Add(KeyCode.W);
            keys.Add(KeyCode.E);
            keys.Add(KeyCode.R);
            keys.Add(KeyCode.D);
            keys.Add(KeyCode.F);
            keys.Add(KeyCode.Mouse1);
            keys.Add(KeyCode.A);
            keyBoardDown[KeyCode.Q] = false;
            keyBoardDown[KeyCode.W] = false;
            keyBoardDown[KeyCode.E] = false;
            keyBoardDown[KeyCode.R] = false;
            keyBoardDown[KeyCode.D] = false;
            keyBoardDown[KeyCode.F] = false;
            keyBoardDown[KeyCode.Mouse1] = false;
            keyBoardDown[KeyCode.A] = false;

            keyBoardUp[KeyCode.Q] = false;
            keyBoardUp[KeyCode.W] = false;
            keyBoardUp[KeyCode.E] = false;
            keyBoardUp[KeyCode.R] = false;
            keyBoardUp[KeyCode.D] = false;
            keyBoardUp[KeyCode.F] = false;
            keyBoardUp[KeyCode.Mouse1] = false;
            keyBoardUp[KeyCode.A] = false;

            keyBoardStayTime[KeyCode.Q] = 0;
            keyBoardStayTime[KeyCode.W] = 0;
            keyBoardStayTime[KeyCode.E] = 0;
            keyBoardStayTime[KeyCode.R] = 0;
            keyBoardStayTime[KeyCode.D] = 0;
            keyBoardStayTime[KeyCode.F] = 0;
            keyBoardStayTime[KeyCode.Mouse1] = 0;
            keyBoardStayTime[KeyCode.A] = 0;
        }
        private void ResetAllState()
        {
            foreach (var key in keys)
            {
                keyBoardDown[key] = false;
                keyBoardUp[key] = false;
            }
        }
        public void Update()
        {
            ResetAllState();
            foreach (var key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    keyBoardDown[key] = true;
                    keyBoardStayTime[key] = 0f;
                }
                if (Input.GetKey(key))
                {
                    keyBoardStayTime[key] += dealTime;
                }
                if (Input.GetKeyUp(key))
                {
                    keyBoardUp[key] = true;
                }
            }

        }
    }
}