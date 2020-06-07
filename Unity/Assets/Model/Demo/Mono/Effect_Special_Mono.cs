



using System;
using UnityEngine;

namespace ETModel.NKGMOBA.Mono
{
    public class Effect_Special_Mono: MonoBehaviour
    {
        public float RotateSpeed;

        private void Update()
        {
            this.transform.Rotate(0, RotateSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}