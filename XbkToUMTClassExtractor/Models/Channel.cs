using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class Channel
    {
        [JsonPropertyName("$type")]
        public string Type => "Channel";
        public string ChannelDisplayName { get; set; }
        public string ChannelName { get; set; }
        public Guid ChannelGUID { get; set; }
        public int ChannelType { get; set; }
    }
}