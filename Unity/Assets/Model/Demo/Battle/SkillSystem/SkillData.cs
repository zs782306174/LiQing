

using System.Numerics;

namespace ETModel
{
    public static class EventCollision
    {
        public const string Liqing_Self_CRS = "10006";
        public const string Liqing_E_CRS = "10002";
        public const string Liqing_Q_CRS = "10001";
    }
    public  class ColliderShape
    {
        public bool isTriger;
        public ColliderType colliderType;
        public Vector2 offset;
        public float angle;
        public float radius;
        public float width;
        public float height;
        public string collisionEvent;
    }
    public static class SkillcmdEvent
    {
        public const string Send = "20001";
    }
    public enum ColliderType
    {
        BoxColllider,
        CircleCollider,
    }
    public enum SkillState
    { 
        CanFire = 0,
        FindPath = 1,
        Fireing = 2,
        Cding = 3,
        Next = 4,
    }
    public enum SkillType
    { 
        MoveSelf,
        MoveOther,
        Dynamics,
        Duration,
        Default,
    }
    public enum SkillInputType
    {
        None = 0,
        Point = 1,
        TwoPoint = 2,
        target = 3,
    }
    public class SkillData
    {
        public SkillType skillType;
        
        public long id;
        public int delay;
        public int waitInputTime;
        public int cd;
        public int hurt;
        public int hurtPerSecond;
        public int cost;
        public string icon;
        public string animation;
        public string prafab;
        public string defaultHotKey;
        public SkillData next;
        public ColliderShape shape;
        public SkillInputType skillInputType;
        public int distance;
        public int speed;
        public float duration;
        public int fireDistance;
    }
}
