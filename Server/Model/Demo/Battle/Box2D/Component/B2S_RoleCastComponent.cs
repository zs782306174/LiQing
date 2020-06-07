
namespace ETModel
{
    public enum RoleCast
    {
        /// <summary>
        /// 友善的
        /// </summary>
        Friendly,

        /// <summary>
        /// 敌对的
        /// </summary>
        Adverse,

        /// <summary>
        /// 中立的
        /// </summary>
        Neutral
    }

    public class B2S_RoleCastComponent: Component
    {
        public RoleCast RoleCast = RoleCast.Adverse;
    }
}