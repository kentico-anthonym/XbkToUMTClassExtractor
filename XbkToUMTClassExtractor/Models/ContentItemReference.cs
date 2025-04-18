using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentItemReference
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentItemReference";
        public Guid ContentItemReferenceGUID { get; set; }
        public Guid ContentItemReferenceSourceCommonDataGuid { get; set; }
        public Guid ContentItemReferenceTargetItemGuid { get; set; }
        public Guid ContentItemReferenceGroupGUID { get; set; } //Guid of the reference field
    }
}