
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using System;
namespace ETModel
{
    [ObjectSystem]
    public class SkillInputUpdateSystem : UpdateSystem<SkillManagerComponent>
    {
        public override void Update(SkillManagerComponent self)
        {
            self.checkInput.Invoke(self);
        }
    }
    [ObjectSystem]
    class SkillAwakeSysterm : AwakeSystem<SkillManagerComponent, SkillData[], Action<SkillManagerComponent>>
    {
        public override void Awake(SkillManagerComponent self,SkillData[] skillDatas, Action<SkillManagerComponent> checkInput)
        {
            self.Awake(skillDatas, checkInput);
        }
    }
   

    
    public class SkillManagerComponent : Component
    {
        public List<SkillHolder> skillHolders = new List<SkillHolder>();

        public Action<SkillManagerComponent> checkInput;
        public void Awake(SkillData[] skillDatas,Action<SkillManagerComponent> checkInput) 
        {
            this.checkInput += checkInput;
            foreach (var skillData in skillDatas)
            {
                SkillHolder skillHolder;
                switch (skillData.skillType)
                {
                    case SkillType.MoveSelf:
                        skillHolder = new SkillHolder(new MoveSelfSkill(skillData),Entity as Unit) ;
                        break;
                    case SkillType.MoveOther:
                        skillHolder = new SkillHolder(new MoveOtherSkill(skillData), Entity as Unit);
                        break;
                    case SkillType.Dynamics:
                        skillHolder = new SkillHolder(new DynamicsSkill(skillData), Entity as Unit); 
                        break;
                    case SkillType.Duration:
                        skillHolder = new SkillHolder(new DurationSkill(skillData), Entity as Unit);
                        break;
                    case SkillType.Default:
                        skillHolder = new SkillHolder(new Skill(skillData), Entity as Unit);
                        break;
                    default:
                        skillHolder = new SkillHolder(new Skill(skillData), Entity as Unit);
                        break;
                }
                this.skillHolders.Add(skillHolder);
            }
        }
        public SkillHolder getSkillById(long id) 
        {
            for (int i = 0; i < skillHolders.Count; i++)
            {
                var skillId = skillHolders[i].RootSkill.SkillData.id;
                if (id == skillId)
                {
                    return skillHolders[i];
                }
            }
            return null;
        }
      
    }
}
