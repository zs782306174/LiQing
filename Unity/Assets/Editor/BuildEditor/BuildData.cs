



using System.Collections.Generic;
using ETModel;
using MongoDB.Bson.Serialization.Attributes;

namespace ETEditor
{
    public class BuildData
    {
        public int VersionInfo;

        public List<string> IndependentBundleAndAtlas = new List<string>();

        public List<string> BundleAndAtlasWithoutShare = new List<string>();
        
        public List<string> BundleAndAtlasShare = new List<string>();
    }
}