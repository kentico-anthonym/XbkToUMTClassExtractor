using System;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class AssetUrlSource : BaseAssetSource
    {
        public override string Type => "AssetUrl";
        public string Url { get; set; }
    }
}