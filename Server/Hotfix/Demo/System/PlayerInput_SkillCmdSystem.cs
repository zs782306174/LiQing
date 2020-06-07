
using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
    [Event(SkillcmdEvent.Send)]
    public class PlayerInput_SkillCmd : AEvent<SkillHolder>
    {
        public override void Run(SkillHolder skillHolder)
        {
            List<OperatePoint> points = new List<OperatePoint>();
            foreach (var item in skillHolder.TagartPoints)
            {
                OperatePoint point = new OperatePoint() { X = item.x, Y = item.y, Z = item.z };
                points.Add(point);
            }
            var SelectUnit = skillHolder.TagartUnit;
            long SelectUnitId = 0;
            if (SelectUnit != null)
                SelectUnitId = SelectUnit.Id;
            M2C_UserInput_SkillCmd m2CUserInputSkillCmd = new M2C_UserInput_SkillCmd()
            {
                Id = skillHolder.BeLongUnit.Id,
                SkillId = skillHolder.RootSkill.SkillData.id,
                SelectUnit = SelectUnitId,
                Points = { points },
                SkillState = (int)skillHolder.SkillState,
            };
            MessageHelper.Broadcast(m2CUserInputSkillCmd);
        }
    }
}