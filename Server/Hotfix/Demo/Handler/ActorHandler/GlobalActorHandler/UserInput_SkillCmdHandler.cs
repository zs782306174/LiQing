
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class UserInput_SkillCmdHandler: AMActorLocationHandler<Unit, UserInput_SkillCmd>
    {
        protected override async ETTask Run(Unit entity, UserInput_SkillCmd message)
        {
            var skill = entity.GetComponent<SkillManagerComponent>().getSkillById(message.SkillId);
            if (message.SelectUnit != 0)
            {
                skill.TagartUnit = Game.Scene.GetComponent<UnitComponent>().Get(message.SelectUnit);
            }
            skill.TagartPoints.Clear();
            if (message.Points.Count > 0)
            {
                foreach (var item in message.Points)
                {
                    Vector3 point = new Vector3(item.X, item.Y, item.Z);
                    skill.TagartPoints.Add(point);
                }
            }
            if (message.SelectUnit != 0)
            {
                skill.TagartUnit = Game.Scene.GetComponent<UnitComponent>().Get(message.SelectUnit);
            }
            skill.SkillState = SkillState.Fireing;
            //M2C_UserInput_SkillCmd m2CUserInputSkillCmd = new M2C_UserInput_SkillCmd()
            //{
            //    Id = entity.Id,
            //    SkillId = skill.CurrentSkillData.id,
            //    SelectUnit = message.SelectUnit,
            //    Points = message.Points,
            //    SkillState = (int)skill.SkillState,
            //};
            
            //MessageHelper.Broadcast(m2CUserInputSkillCmd);
            await ETTask.CompletedTask;
        }
    }
}