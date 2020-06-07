using System.Collections.Generic;
using System.Threading;
using PF;
using UnityEngine;

namespace ETModel
{
    public class UnitPathComponent: Component
    {
        public Vector3 Target;

        private ABPathWrap abPath;
        
        public List<Vector3> Path;

        public CancellationTokenSource CancellationTokenSource;
        public async ETTask MoveAsync(List<Vector3> path)
        {
            if (path.Count == 0)
            {
                return;
            }
            // 第一个点是unit的当前位置，所以不用发送
            for (int i = 1; i < path.Count; ++i)
            {
                // 每移动3个点发送下3个点给客户端
                if (i % 3 == 1)
                {
                   BroadcastPath(path, i, 3);
                }
                Vector3 v3 = path[i];
                float speed = 5;
                await Entity.GetComponent<MoveComponent>().MoveToAsync(v3, speed, CancellationTokenSource.Token);
            }
        }
        public async ETVoid MoveTo( Vector3 target)
        {
            if ((Target - target).magnitude < 0.1f)
            {
                return;
            }

            Target = target;

            Unit unit = GetParent<Unit>();


            PathfindingComponent pathfindingComponent = Game.Scene.GetComponent<PathfindingComponent>();
            ABPath = ComponentFactory.Create<ABPathWrap, Vector3, Vector3>(unit.Position, new Vector3(target.x, target.y, target.z));
            pathfindingComponent.Search(ABPath);
            //Log.Debug($"find result: {ABPath.Result.ListToString()}");

            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();
            await MoveAsync(ABPath.Result);
            CancellationTokenSource.Dispose();
            CancellationTokenSource = null;
        }
        public void BroadcastPath( List<Vector3> path, int index, int offset)
        {
            Unit unit = GetParent<Unit>();
            Vector3 unitPos = unit.Position;
            M2C_PathfindingResult m2CPathfindingResult = new M2C_PathfindingResult();
            m2CPathfindingResult.X = unitPos.x;
            m2CPathfindingResult.Y = unitPos.y;
            m2CPathfindingResult.Z = unitPos.z;
            m2CPathfindingResult.Id = unit.Id;

            for (int i = 0; i < offset; ++i)
            {
                if (index + i >= ABPath.Result.Count)
                {
                    break;
                }
                Vector3 v = ABPath.Result[index + i];
                m2CPathfindingResult.Xs.Add(v.x);
                m2CPathfindingResult.Ys.Add(v.y);
                m2CPathfindingResult.Zs.Add(v.z);
            }
            MessageHelper.Broadcast(m2CPathfindingResult);
        }
        public ABPathWrap ABPath
        {
            get
            {
                return this.abPath;
            }
            set
            {
                this.abPath?.Dispose();
                this.abPath = value;
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();
            
            this.abPath?.Dispose();
        }
    }
}