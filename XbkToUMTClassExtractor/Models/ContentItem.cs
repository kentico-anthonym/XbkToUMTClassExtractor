using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentItem
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentItem";
        public Guid ContentItemGUID { get; set; }
        public string ContentItemName { get; set; }
        public bool ContentItemIsReusable { get; set; }
        public bool ContentItemIsSecured { get; set; }
        public Guid ContentItemDataClassGuid { get; set; }
        public Guid ContentItemChannelGuid { get; set; }
        public Guid? ContentItemContentFolderGUID { get; set; }
    }
}