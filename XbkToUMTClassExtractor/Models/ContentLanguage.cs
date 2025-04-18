using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentLanguage
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentLanguage";
        public Guid ContentLanguageGUID { get; set; }
        public string ContentLanguageDisplayName { get; set; }
        public string ContentLanguageName { get; set; }
        public bool ContentLanguageIsDefault { get; set; }
        public Guid? ContentLanguageFallbackContentLanguageGuid { get; set; }
        public string ContentLanguageCultureFormat { get; set; }
    }
}