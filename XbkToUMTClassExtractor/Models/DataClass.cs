using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models;

[Serializable]
public class DataClass
{
    [JsonPropertyName("$type")]
    public string Type => "DataClass";
    public string ClassDisplayName { get; set; }
    public string ClassName { get; set; }
    public string ClassTableName { get; set; }
    public bool ClassShowTemplateSelection { get; set; }
    public DateTime ClassLastModified { get; set; }
    public Guid ClassGUID { get; set; }
    public bool ClassHasUnmanagedDbSchema { get; set; }
    public string ClassType { get; set; }
    public string ClassContentTypeType { get; set; }
    public bool ClassWebPageHasUrl { get; set; }
    public List<DataClassField> Fields { get; set; }

}

[Serializable]
public class DataClassField
{
    public bool AllowEmpty { get; set; }
    public string Column { get; set; }
    public int ColumnSize { get; set; }
    public string ColumnType { get; set; }
    public bool Enabled { get; set; }
    public Guid Guid { get; set; }
    public bool Visible { get; set; }
    public DataClassFieldProperties Properties { get; set; }
    public DataClassFieldSettings Settings { get; set; }
}

[Serializable]
public class DataClassFieldProperties
{
    public string FieldCaption { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = [];
}

[Serializable]
public class DataClassFieldSettings
{
    public string ControlName { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object?> CustomProperties { get; set; } = [];
    //public string AllowedExtensions { get; set; }
    //public List<Guid> AllowedContentItemTypeIdentifiers { get; set; }
    //public int MaximumPages { get; set; }
    //public string TreePath { get; set; }
    //public bool Sortable { get; set; }
}
