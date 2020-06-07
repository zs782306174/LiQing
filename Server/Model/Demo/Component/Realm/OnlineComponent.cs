
using System;
using System.Collections.Generic;

namespace ETModel
{
    /// <summary>
    /// 在线组件，用于记录在线玩家
    /// </summary>
    public class OnlineComponent: Component
    {
        /// <summary>
        /// 记录玩家在线情况的字典，long为playerID（MongoDB数据库中的），long为PlayerComonent的id，int为GateAppID
        /// </summary>
        private readonly Dictionary<long, (long, int)> m_dictionarty = new Dictionary<long, (long, int)>();

        /// <summary>
        /// 添加在线玩家
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="playerIDInPlayerComponent"></param>
        /// <param name="gateAppId"></param>
        public void Add(long playerId, long playerIDInPlayerComponent, int gateAppId)
        {
            this.m_dictionarty.Add(playerId, (playerIDInPlayerComponent, gateAppId));
        }

        /// <summary>
        /// 获取在线玩家网关服务器ID
        /// </summary>
        /// <param name="playerID">玩家ID（MongoDB数据库中的）</param>
        /// <returns></returns>
        public int GetGateAppId(long playerID)
        {
            if (this.m_dictionarty.TryGetValue(playerID, out (long,int) tempGateAppID))
            {
                return tempGateAppID.Item2;
            }

            return tempGateAppID.Item2;
        }
        
        /// <summary>
        /// 获取在线玩家id(PlayerComponent中的id)
        /// </summary>
        /// <param name="playerID">玩家ID（MongoDB数据库中的）</param>
        /// <returns></returns>
        public long GetPlayerIdInPlayerComponent(long playerID)
        {
            if (this.m_dictionarty.TryGetValue(playerID, out (long,int) tempGateAppID))
            {
                return tempGateAppID.Item1;
            }

            return tempGateAppID.Item1;
        }

        /// <summary>
        /// 移除在线玩家
        /// </summary>
        /// <param name="playerID">玩家ID（MongoDB数据库中的）</param>
        public void Remove(long playerID)
        {
            this.m_dictionarty.Remove(playerID);
        }
    }
}