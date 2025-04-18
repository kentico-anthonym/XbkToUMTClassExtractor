using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentItemCommonData
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentItemCommonData";
        public Guid ContentItemCommonDataGUID { get; set; }
        public Guid ContentItemCommonDataContentItemGuid { get; set; }
        public Guid ContentItemCommonDataContentLanguageGuid { get; set; }
        public int ContentItemCommonDataVersionStatus { get; set; }
        public bool ContentItemCommonDataIsLatest { get; set; }
        public string ContentItemCommonDataVisualBuilderWidgets { get; set; }
        public string ContentItemCommonDataVisualBuilderTemplateConfiguration { get; set; }
    }
}