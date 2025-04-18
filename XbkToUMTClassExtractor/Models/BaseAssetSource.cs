using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    public abstract class BaseAssetSource
    {
        [JsonPropertyName("$assetType")]
        public abstract string Type { get; }

        public Guid? ContentItemGuid { get; set; }
        public Guid? Identifier { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime? LastModified { get; set; }
    }
}