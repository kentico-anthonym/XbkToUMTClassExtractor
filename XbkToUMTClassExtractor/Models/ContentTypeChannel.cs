using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentTypeChannel
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentTypeChannel";
        public Guid ContentTypeChannelChannelGuid { get; set; }
        public Guid ContentTypeChannelContentTypeGuid { get; set; }
    }
}