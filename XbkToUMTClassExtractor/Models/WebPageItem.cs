using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class WebPageItem
    {
        [JsonPropertyName("$type")]
        public string Type => "WebPageItem";
        public Guid WebPageItemGUID { get; set; }
        public Guid? WebPageItemParentGuid { get; set; }
        public string WebPageItemName { get; set; }
        public string WebPageItemTreePath { get; set; }
        public Guid WebPageItemWebsiteChannelGuid { get; set; }
        public Guid WebPageItemContentItemGuid { get; set; }
        public int WebPageItemOrder { get; set; }
    }
}