

using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models;

[Serializable]
public class ContentItemData
{
    [JsonPropertyName("$type")]
    public string Type => "ContentItemData";
    public Guid ContentItemDataGUID { get; set; }
    public Guid ContentItemDataCommonDataGuid { get; set; }
    public string ContentItemContentTypeName { get; set; }
    [JsonExtensionData]
    public Dictionary<string, object> Properties { get; set; }
}
