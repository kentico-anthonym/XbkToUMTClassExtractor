using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.Websites;
using System.Text.Json;
using XbkToUMTClassExtractor.Helpers;
using XbkToUMTClassExtractor.Models;

namespace XbkToUMTClassExtractor.Extractors;

public class ChannelExtractor
{
    private readonly IInfoProvider<WebsiteChannelInfo> websiteChannelProvider;
    private readonly IInfoProvider<ContentLanguageInfo> contentLanguageProvider;
    private readonly IInfoProvider<ChannelInfo> channelProvider;

    public ChannelExtractor(IInfoProvider<WebsiteChannelInfo> websiteChannelProvider,
        IInfoProvider<ContentLanguageInfo> contentLanguageProvider,
        IInfoProvider<ChannelInfo> channelProvider)
    {
        this.websiteChannelProvider = websiteChannelProvider;
        this.contentLanguageProvider = contentLanguageProvider;
        this.channelProvider = channelProvider;
    }

    public async void ExtractChannels(string path = "")
    {
        List<WebSiteChannel> channels = new List<WebSiteChannel>();
        channels = websiteChannelProvider.Get()
            .Select(x => new WebSiteChannel()
            {
                WebsiteChannelGUID = x.WebsiteChannelGUID,
                WebsiteChannelChannelGuid = GetWebsiteChannelChannelGuid(x.WebsiteChannelChannelID),
                WebsiteChannelStoreFormerUrls = x.WebsiteChannelStoreFormerUrls,
                WebsiteChannelDefaultCookieLevel = x.WebsiteChannelDefaultCookieLevel,
                WebsiteChannelDomain = x.WebsiteChannelDomain,
                WebsiteChannelHomePage = x.WebsiteChannelHomePage,
                WebsiteChannelPrimaryContentLanguageGuid = GetContentLanguageGuid(x.WebsiteChannelPrimaryContentLanguageID)
            }).ToList();

        path = path != string.Empty ? path : CustomPathHelper.ProjectPath;

        await using FileStream createStream = File.Create(@$"{path}\ExampleJson\{nameof(WebSiteChannel)}.json");
        await JsonSerializer.SerializeAsync(createStream, channels, new JsonSerializerOptions
        {
            DefaultBufferSize = 32000,
            WriteIndented = true
        });
    }

    public Guid GetContentLanguageGuid(int id)
    {
        var languageGuid = contentLanguageProvider.Get(id).ContentLanguageGUID;

        return languageGuid;
    }

    public Guid GetWebsiteChannelChannelGuid(int id)
    {
        var channelGuid = channelProvider.Get(id).ChannelGUID;

        return channelGuid;
    }
}
