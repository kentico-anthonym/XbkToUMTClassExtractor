using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class WebPageUrlPath
    {
        [JsonPropertyName("$type")]
        public string Type => "WebPageUrlPath";
        public Guid WebPageUrlPathGUID { get; set; }
        [JsonPropertyName("WebPageUrlPath")]
        public string WebPageUrlPathPath { get; set; }
        public string WebPageUrlPathHash { get; set; }
        public Guid WebPageUrlPathWebPageItemGuid { get; set; }
        public Guid WebPageUrlPathWebsiteChannelGuid { get; set; }
        public Guid WebPageUrlPathContentLanguageGuid { get; set; }
        public bool WebPageUrlPathIsLatest { get; set; }
        public bool WebPageUrlPathIsDraft { get; set; }
    }
}