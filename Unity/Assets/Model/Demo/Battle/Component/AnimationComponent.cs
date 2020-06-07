
using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class AnimationComponentAwakeSystem: AwakeSystem<AnimationComponent>
    {
        public override void Awake(AnimationComponent self)
        {
            self.AnimancerComponent = self.Parent.GameObject.GetComponent<AnimancerComponent>();
            //如果是以Anim开头的key值，说明是动画文件，需要添加引用
            foreach (var VARIABLE in self.Parent.GameObject.GetComponent<ReferenceCollector>().data)
            {
                if (VARIABLE.key.StartsWith("anim"))
                {
                    self.AnimationClips.Add(VARIABLE.key, VARIABLE.gameObject as AnimationClip);
                }
            }
            self.PlayIdel();
        }
    }

    /// <summary>
    /// 基于Animancer插件做的动画机系统。配合可视化编辑使用效果更佳
    /// 暂时只提供基本的跑，默认外部接口，技能动画的播放应该交给可视化编辑器来做
    /// </summary>
    public class AnimationComponent: Component
    {
        /// <summary>
        /// Animacner的组件
        /// </summary>
        public AnimancerComponent AnimancerComponent;


        /// <summary>
        /// 管理所有的动画文件
        /// </summary>
        public Dictionary<string, AnimationClip> AnimationClips = new Dictionary<string, AnimationClip>();

        
        /// <summary>
        /// 播放一个动画(播放完成自动循环)
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <returns></returns>
        public void PlayAnim(string name)
        {
            AnimancerComponent.CrossFade(this.AnimationClips[name]);
        }

        /// <summary>
        /// 播放一个动画(播放完成自动回到默认动画)
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <returns></returns>
        public void PlayAnimAndReturnIdel(string name)
        {
            AnimancerComponent.CrossFade(this.AnimationClips[name]).OnEnd = PlayIdel;
        }
        /// <summary>
        /// 播放默认动画（非正式版）
        /// </summary>
        public void PlayIdel()
        {
             AnimancerComponent.CrossFade(this.AnimationClips["animIdle"]);
        }
        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            this.AnimancerComponent = null;
            this.AnimationClips.Clear();
            this.AnimationClips = null;
        }
    }
}