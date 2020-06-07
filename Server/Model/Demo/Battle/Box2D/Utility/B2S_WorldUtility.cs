
using System.Numerics;
using Box2DSharp.Dynamics;

namespace ETModel
{
    public class B2S_WorldUtility
    {
        /// <summary>
        /// 创造一个物理世界
        /// </summary>
        /// <param name="gravity">重力加速度</param>
        /// <returns></returns>
        public static World CreateWorld(Vector2 gravity)
        {
            return new World(gravity);
        }
    }
}