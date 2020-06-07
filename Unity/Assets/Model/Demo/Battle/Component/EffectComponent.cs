



using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    /// <summary>
    /// 特效组件，用于管理Unit身上的特效
    /// </summary>
    public class EffectComponent: Component
    {
        private Dictionary<string, Unit> AllEffects = new Dictionary<string, Unit>();

        /// <summary>
        /// 特效组，用于处理互斥特效，例如诺克的一个血滴，两个血滴，三个血滴这种，里面的数据应由excel表来配置
        /// </summary>
        private List<string> effectGroup = new List<string>
        {
            "Darius_Passive_Bleed_Effect_1",
            "Darius_Passive_Bleed_Effect_2",
            "Darius_Passive_Bleed_Effect_3",
            "Darius_Passive_Bleed_Effect_4",
            "Darius_Passive_Bleed_Effect_5"
        };

        /// <summary>
        /// 添加一个特效
        /// </summary>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        public void Add(string name, Unit unit)
        {
            if (this.AllEffects.ContainsKey(name))
            {
                return;
            }

            this.AllEffects.Add(name, unit);
        }

        /// <summary>
        /// 移除一个特效
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            if (this.AllEffects.TryGetValue(name, out var tempUnit))
            {
                tempUnit.GameObject.GetComponent<ParticleSystem>().Stop();
                AllEffects.Remove(name);
                Game.Scene.GetComponent<GameObjectPool<Unit>>().Recycle(tempUnit);
            }
        }

        /// <summary>
        /// 播放一个特效
        /// </summary>
        /// <param name="name"></param>
        public void Play(string name, Unit unit)
        {
            //处理特效冲突
            HandleConflict(name);

            //播放特效
            if (this.AllEffects.TryGetValue(name, out var tempUnit))
            {
                tempUnit.GameObject.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Add(name, unit);
                unit.GameObject.GetComponent<ParticleSystem>().Play();
            }
        }

        /// <summary>
        /// 检查一个特效的状态，如果正在播放就返回True
        /// </summary>
        /// <param name="effectNameToBeChecked"></param>
        /// <returns></returns>
        public bool CheckState(string effectNameToBeChecked)
        {
            if (this.AllEffects.TryGetValue(effectNameToBeChecked, out var unit))
            {
                if (unit.GameObject.GetComponent<ParticleSystem>().isPlaying)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// 处理特效冲突
        /// </summary>
        /// <param name="name"></param>
        public void HandleConflict(string name)
        {
            //如果互斥列表中不包含此项，说明不与其他特效互斥
            if (!effectGroup.Contains(name)) return;
            //查看他是否与特效组里面的一些特效冲突，如果是就移除当前冲突的特效，而播放他
            foreach (var VARIABLE in this.effectGroup)
            {
                //是同一个特效，就不需要做操作
                if (VARIABLE == name)
                {
                    continue;
                }

                //如果当前播放的特效中不含VARIABLE，就不需要做操作
                if (!this.AllEffects.ContainsKey(VARIABLE))
                {
                    continue;
                }

                //如果它并没有在播放，就不需要操作
                if (!this.AllEffects[VARIABLE].GameObject.GetComponent<ParticleSystem>().isPlaying)
                {
                    continue;
                }

                //将目标特效移除
                Remove(VARIABLE);
                //Log.Info($"停止了{VARIABLE1}");
            }
        }
    }
}