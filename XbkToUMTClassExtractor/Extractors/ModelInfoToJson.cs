using Kentico.Xperience.UMT.Attributes;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Serialization;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using XbkToUMTClassExtractor.Helpers;

namespace XbkToUMTClassExtractor.Extractors;

public class ModelInfoToJson
{
    private readonly IServiceProvider serviceProvider;

    public ModelInfoToJson(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async void SerializeModelInfos()
    {
        Type[] umtModelType = GetTypesWithHelpAttribute(Assembly.GetAssembly(typeof(UmtModelAttribute))).ToArray();

        var umtModelService = serviceProvider.GetService<UmtModelService>();

        UmtModel?[] models = umtModelType
            .Select(t => Activator.CreateInstance(t) as UmtModel) // Safely cast to UmtModel
            .Where(instance => instance != null) // Filter out null instances
            .ToArray();

        if (models.Any())
        {

            var converter = new UmtModelStjConverter(umtModelService.GetAll());

            var options = new JsonSerializerOptions
            {
                //DefaultBufferSize = 32000,
                WriteIndented = true,
                IncludeFields = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { converter }
            };

            var path = CustomPathHelper.ProjectPath ?? string.Empty;

            await using FileStream createStream = File.Create(@$"{path}\ExampleJson\data.json");
            await JsonSerializer.SerializeAsync(createStream, models, options);
        }
    }


    private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return
          assembly.GetTypes()
                  .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                  .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<ObsoleteAttribute>() == null)
                  .ToArray();
    }

    static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(UmtModelAttribute), true).Length > 0)
            {
                yield return type;
            }
        }
    }
}
