using Kentico.Xperience.UMT.Attributes;
using Kentico.Xperience.UMT.Model;
using Kentico.Xperience.UMT.Serialization;
using Kentico.Xperience.UMT.Services.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;

namespace XbkToUMTClassExtractor.Extractors;

public class ModelInfoToJson
{
    private readonly IServiceProvider serviceProvider;
    public ModelInfoToJson(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    public void Testing()
    {
        // This method is a placeholder for testing purposes.
        // You can implement your logic here to test the functionality of the ContentItemExtractor.
        // https://stackoverflow.com/questions/949246/how-can-i-get-all-classes-within-a-namespace
        // https://stackoverflow.com/questions/607178/how-enumerate-all-classes-with-custom-class-attribute
        Type[] umtModelType = GetTypesWithHelpAttribute(Assembly.GetAssembly(typeof(UmtModelAttribute))).ToArray();
        Type[] typeList = GetTypesInNamespace(Assembly.GetAssembly(typeof(AssetFileSource)), "Kentico.Xperience.UMT.Model");

        var umtModelService = serviceProvider.GetService<UmtModelService>();

        UmtModel[] models = umtModelType
            .Select(t => (UmtModel)Activator.CreateInstance(t))
            .ToArray();


        var converter = new UmtModelStjConverter(umtModelService.GetAll());

        var serialized = JsonSerializer.Serialize(models, new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { converter }

        });
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
