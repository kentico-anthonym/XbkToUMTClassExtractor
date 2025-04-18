using CMS.DataEngine;
using CMS.FormEngine;
using System.Collections;
using System.Globalization;
using System.Text.Json;
using XbkToUMTClassExtractor.Helpers;
using XbkToUMTClassExtractor.Models;

namespace XbkToUMTClassExtractor.Extractors;

public class DataClassExtractor
{
    //private readonly IInfoProvider<DataClassInfo> dataClassProvider;
    public DataClassExtractor()
    {
        //this.dataClassProvider = dataClassProvider;
    }

    public async void ExtractDataClasses(string path = "")
    {
        var infos = DataClassInfoProvider.GetClasses();
        var classes = new List<DataClass>();
        foreach (var info in infos)
        {
            var form = FormHelper.GetFormInfo(info.ClassName, false);
            var fields = form.GetFields(true, false) ?? null;

            var dataclass = new DataClass
            {
                ClassDisplayName = info.ClassDisplayName,
                ClassWebPageHasUrl = info.ClassWebPageHasUrl,
                ClassTableName = info.ClassTableName,
                ClassType = info.ClassType,
                ClassName = info.ClassName,
                ClassLastModified = info.ClassLastModified,
                ClassGUID = info.ClassGUID,
                ClassContentTypeType = info.ClassContentTypeType,
                ClassHasUnmanagedDbSchema = info.ClassHasUnmanagedDbSchema,
                ClassShowTemplateSelection = info.ClassShowTemplateSelection,
            };
            if (fields.Any())
            {
                dataclass.Fields = fields.Select(field => new DataClassField
                {
                    AllowEmpty = field.AllowEmpty,
                    Column = field.Name,
                    ColumnType = field.DataType,
                    Guid = field.Guid,
                    ColumnSize = field.Size,
                    Enabled = field.Enabled,
                    Properties = ExtractProperties(field.Properties),
                    Settings = ExtractSettings(field.Settings)
                }).ToList();
            }

            classes.Add(dataclass);
        }

        path = path != string.Empty ? path : CustomPathHelper.ProjectPath;

        await using FileStream createStream = File.Create(@$"{path}\ExampleJson\{nameof(DataClass)}.json");
        // if the json output seems to cut off after a certain point it's recommended to adjust the buffer size
        await JsonSerializer.SerializeAsync(createStream, classes, new JsonSerializerOptions
        {
            DefaultBufferSize = 32000,
            WriteIndented = true
        });
    }

    public DataClassFieldProperties ExtractProperties(Hashtable props)
    {
        DataClassFieldProperties fieldProperties = new DataClassFieldProperties();

        foreach (string key in props.Keys)
        {
            if (key.ToLower() == "fieldcaption")
            {
                fieldProperties.FieldCaption = props[key].ToString() ?? "";
            }
            else
            {
                fieldProperties.CustomProperties.Add(key, props[key]);
            }
        }

        return fieldProperties;
    }

    public async void ExtractDataClass()
    {
        var dataclassinfo = DataClassInfoProvider.GetDataClassInfo("DancingGoat.Event");
        var form = FormHelper.GetFormInfo(dataclassinfo.ClassName, false);
        var fields = form.GetFields(true, true);
        var models = form.GetFields(true, false).Select(field => new DataClassField
        {
            AllowEmpty = field.AllowEmpty,
            Column = field.Name,
            ColumnType = field.DataType,
            Guid = field.Guid,
            ColumnSize = field.Size,
            Enabled = field.Enabled,
            Properties = new DataClassFieldProperties { FieldCaption = field.Properties["FieldCaption"] as string ?? "" },
            Settings = ExtractSettings(field.Settings)
        });
        await using FileStream createStream = File.Create(@"C:\Users\AnthonyM\source\repos\XbkToUMTClassExtractor\XbkToUMTClassExtractor\path.json");
        await JsonSerializer.SerializeAsync(createStream, models);
    }

    public DataClassFieldSettings ExtractSettings(Hashtable settings)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        // get fields from the dataclassfieldsettings
        var fieldSettings = new DataClassFieldSettings();
        var fieldSettingsType = fieldSettings.GetType();

        //foreach (string key in settings.Keys)
        //{
        //    var value = settings[key];
        //    var propName = textInfo.ToTitleCase(key);
        //    var targetClassProperty = fieldSettingsType.GetProperty(propName);
        //    targetClassProperty.SetValue(fieldSettings, value);
        //}

        foreach (var prop in fieldSettingsType.GetProperties())
        {
            var key = prop.Name.ToLower();
            var val = settings[key];
            //var propName = textInfo.ToTitleCase(key);
            if (val is not null)
            {
                if (key == "allowedcontentitemtypeidentifiers")
                {
                    prop.SetValue(fieldSettings, HandleGuidValues(val as string));
                }
                else if (key == "maximumpages")
                {
                    int number;
                    int.TryParse(val as string, out number);
                    prop.SetValue(fieldSettings, number);
                }
                else if (key == "sortable")
                {
                    bool result;
                    bool.TryParse(val as string, out result);
                    prop.SetValue(fieldSettings, result);
                }
                else
                {
                    prop.SetValue(fieldSettings, val);
                }
            }
        }

        return fieldSettings;
    }

    public List<Guid> HandleGuidValues(string guids)
    {
        return JsonSerializer.Deserialize<List<Guid>>(guids) ?? new List<Guid>();
    }
}
