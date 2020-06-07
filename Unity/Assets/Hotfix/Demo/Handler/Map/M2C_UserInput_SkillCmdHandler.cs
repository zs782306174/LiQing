



using ETModel;
using NPOI.HPSF;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class M2C_UserInput_SkillCmdHandler: AMHandler<M2C_UserInput_SkillCmd>
    {
        protected override async ETTask Run(ETModel.Session session, M2C_UserInput_SkillCmd message)
        {
            
            Unit unit = ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.Id);
            var skillholder = unit.GetComponent<SkillManagerComponent>().getSkillById(message.SkillId);
            if (message.SelectUnit != 0) 
            {
                skillholder.TagartUnit = ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.SelectUnit);
                UserInputComponent.Instance.SelectUnit = skillholder.TagartUnit;
            }
            skillholder.TagartPoints.Clear();
            if (message.Points != null)
            {
                foreach (var item in message.Points)
                {
                    Vector3 point = new Vector3(item.X, item.Y, item.Z);
                    skillholder.TagartPoints.Add(point);
                }
            }
            skillholder.SkillState = (SkillState)message.SkillState;
            await ETTask.CompletedTask;
        }
    }
}