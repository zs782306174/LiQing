



using System;
using System.Collections.Generic;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;

namespace ETModel
{
    /// <summary>
    /// 名称与id映射字典
    /// </summary>
    public class ColliderNameAndIdInflectSupporter
    {
        public Dictionary<string, long> colliderNameAndIdInflectDic = new Dictionary<string, long>();
    }

    /// <summary>
    /// 碰撞体数据字典
    /// </summary>
    public class ColliderDataSupporter
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, B2S_ColliderDataStructureBase> colliderDataDic = new Dictionary<long, B2S_ColliderDataStructureBase>();
    }
}