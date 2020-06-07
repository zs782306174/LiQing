



using System;
using Sirenix.OdinInspector;

namespace ETModel
{
    /// <summary>
    /// 英雄职业
    /// </summary>
    [Flags]
    public enum HeroProfession
    {
        [LabelText("法师")]
        Caster = 1 << 1,

        [LabelText("坦克")]
        Tank = 1 << 2,

        [LabelText("刺客")]
        Assassin = 1 << 3,

        [LabelText("射手")]
        Archer = 1 << 4,

        [LabelText("辅助")]
        Assist = 1 << 5,

        [LabelText("打野")]
        Jungle = 1 << 6,

        [LabelText("战士")]
        Warrior = 1 << 7,
    }
}