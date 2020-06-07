



using System;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class B2S_DebuggerHandler: MonoBehaviour
    {
        public List<B2S_ColliderVisualHelperBase> MB2SColliderVisualHelpers = new List<B2S_ColliderVisualHelperBase>();

        private void OnDrawGizmos()
        {
            foreach (var VARIABLE in this.MB2SColliderVisualHelpers)
            {
                if (VARIABLE.canDraw)
                    VARIABLE.OnDrawGizmos();
            }
        }

        public void CleanCollider()
        {
            MB2SColliderVisualHelpers.Clear();
        }

        public void OnUpdate()
        {
            foreach (var VARIABLE in this.MB2SColliderVisualHelpers)
            {
                VARIABLE.OnUpdate();
            }
        }
    }
}