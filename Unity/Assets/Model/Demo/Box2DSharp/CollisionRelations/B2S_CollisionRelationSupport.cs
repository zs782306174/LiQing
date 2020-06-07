



using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Sirenix.OdinInspector;

namespace ETMode
{
    public class B2S_CollisionsRelationSupport
    {
        [LabelText("此数据载体ID")]
        public int SupportId;

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, B2S_CollisionInstance> B2S_CollisionsRelationDic = new Dictionary<long, B2S_CollisionInstance>();
    }
}