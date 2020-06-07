



using System.Numerics;
using MongoDB.Bson.Serialization;

#if UNITY_EDITOR
using UnityEditor;    
#endif

namespace ETModel
{
    /// <summary>
    /// Bson序列化反序列化辅助类
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public static class BsonHelper
    {
        static BsonHelper()
        {
            RegisterStructSerializer();
        }

        /// <summary>
        /// 注册所有需要使用Bson序列化反序列化的结构体
        /// </summary>
        public static void RegisterStructSerializer()
        {
            BsonSerializer.RegisterSerializer(typeof (Vector2), new StructBsonSerialize<Vector2>());
        }

        /// <summary>
        /// 初始化BsonHelper
        /// </summary>
        public static void Init()
        {
            //调用这个是为了执行静态构造方法
        }
    }
}