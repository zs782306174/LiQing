



using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Sirenix.OdinInspector;

namespace ETModel
{
    public class HeroDataSupportor
    {
        [LabelText("此数据载体ID")]
        public int SupportId;
        
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, NodeDataForHero> MHeroDataSupportorDic = new Dictionary<long, NodeDataForHero>();
    }
}