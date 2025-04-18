using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models;

[Serializable]
public class WebSiteChannel
{
    [JsonPropertyName("$type")]
    public string Type => "WebSiteChannel";
    public Guid WebsiteChannelGUID { get; set; }
    public Guid WebsiteChannelChannelGuid { get; set; }
    public string WebsiteChannelDomain { get; set; }
    public string WebsiteChannelHomePage { get; set; }
    public Guid WebsiteChannelPrimaryContentLanguageGuid { get; set; }
    public int WebsiteChannelDefaultCookieLevel { get; set; }
    public bool WebsiteChannelStoreFormerUrls { get; set; }
}
