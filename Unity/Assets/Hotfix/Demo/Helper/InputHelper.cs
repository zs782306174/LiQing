using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class InputHelper
    {
        public static void checkInput(SkillManagerComponent self)
        {
            foreach (var skillHolder in self.skillHolders)
            {
                if (UserInputComponent.Instance.keyBoardDown[skillHolder.KeyCode])
                {
                    UserInputComponent.Instance.points.Clear();
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    switch (skillHolder.CurrentSkill.SkillData.skillInputType)
                    {
                        case SkillInputType.None:
                            if (skillHolder.CountDown == 0)
                            {
                                SessionComponent.Instance.Session.Send(new UserInput_SkillCmd() { SkillId = skillHolder.RootSkill.SkillData.id, });
                            }
                            break;
                        case SkillInputType.Point:

                            if (skillHolder.CountDown == 0 && Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                            {
                                UserInputComponent.Instance.points.Add(hit.point);
                                OperatePoint point = new OperatePoint() { X = hit.point.x, Y = hit.point.y, Z = hit.point.z };
                                SessionComponent.Instance.Session.Send(new UserInput_SkillCmd() { SkillId = skillHolder.RootSkill.SkillData.id, Points = { point } });
                            }
                            break;
                        case SkillInputType.TwoPoint:
                            if (skillHolder.CountDown == 0 && Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                            {
                                UserInputComponent.Instance.points.Add(hit.point);
                            }
                            break;
                        case SkillInputType.target:
                            var selected = UserInputComponent.Instance.SelectUnit;
                            if (skillHolder.CountDown == 0 && selected != null)
                            {
                                SessionComponent.Instance.Session.Send(new UserInput_SkillCmd() { SkillId = skillHolder.RootSkill.SkillData.id, SelectUnit = selected.Id });
                            }
                            break;
                    }
                }
                if (UserInputComponent.Instance.keyBoardUp[skillHolder.KeyCode])
                {

                    switch (skillHolder.CurrentSkill.SkillData.skillInputType)
                    {
                        case SkillInputType.None:
                            break;
                        case SkillInputType.Point:
                            break;
                        case SkillInputType.TwoPoint:
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (skillHolder.CountDown == 0 && Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                            {
                                UserInputComponent.Instance.points.Add(hit.point);
                                List<OperatePoint> points = new List<OperatePoint>();
                                foreach (var point in UserInputComponent.Instance.points)
                                {
                                    OperatePoint operatePoint = new OperatePoint() { X = point.x, Y = point.y, Z = point.z };
                                    points.Add(operatePoint);
                                }
                                SessionComponent.Instance.Session.Send(new UserInput_SkillCmd() { SkillId = skillHolder.RootSkill.SkillData.id, Points = { points } });
                            }
                            break;
                        case SkillInputType.target:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
