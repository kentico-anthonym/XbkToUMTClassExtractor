using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentItemLanguageMetadata
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentItemLanguageMetadata";
        public Guid ContentItemLanguageMetadataGUID { get; set; }
        public Guid ContentItemLanguageMetadataContentItemGuid { get; set; }
        public string ContentItemLanguageMetadataDisplayName { get; set; }
        public int ContentItemLanguageMetadataLatestVersionStatus { get; set; }
        public DateTime ContentItemLanguageMetadataCreatedWhen { get; set; }
        public Guid ContentItemLanguageMetadataCreatedByUserGuid { get; set; }
        public DateTime ContentItemLanguageMetadataModifiedWhen { get; set; }
        public Guid ContentItemLanguageMetadataModifiedByUserGuid { get; set; }
        public bool ContentItemLanguageMetadataHasImageAsset { get; set; }
        public Guid ContentItemLanguageMetadataContentLanguageGuid { get; set; }

    }
}