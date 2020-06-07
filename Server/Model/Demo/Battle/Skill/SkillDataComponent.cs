using System;
using System.Collections.Generic;
using System.Text;

namespace ETModel
{
    [ObjectSystem]
    public class SkillDataComponentAwakeSystem : AwakeSystem<SkillDataComponent, long>
    {
        public override void Awake(SkillDataComponent self, long skillId)
        {
            self.skillId = skillId;
        }
    }
    public class SkillDataComponent:Component
    {
        public long skillId;
    }
}
