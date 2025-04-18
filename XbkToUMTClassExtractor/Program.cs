
using CMS.Core;
using CMS.DataEngine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XbkToUMTClassExtractor.Extractors;
using XbkToUMTClassExtractor.Services;

// Ensures a preconfigured environment (DI, configuration providers) for .NET console apps
var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, true)
    .AddJsonFile("appsettings.Development.json", optional: true);

string jsonFilePath = builder.Configuration.GetSection("projectPath").Value ?? string.Empty;

// Preinitializes Xperience by Kentico without building a custom DI container
CMSApplication.PreInit(false);

// Registers extractors and other services
builder.Services.AddCoreServices();

// Merges Xperience services with the application's service collection
Service.MergeDescriptors(builder.Services);

var app = builder.Build();

// Tells Xperience to use this app's service container for service resolution
Service.SetProvider(app.Services);

// Initializes Xperience APIs and database for use in the app
CMSApplication.Init();


using var serviceScope = app.Services.CreateScope();
var classExtractor = serviceScope.ServiceProvider.GetService<DataClassExtractor>();
classExtractor.ExtractDataClasses();

var channelExtractor = serviceScope.ServiceProvider.GetService<ChannelExtractor>();
channelExtractor.ExtractChannels();
