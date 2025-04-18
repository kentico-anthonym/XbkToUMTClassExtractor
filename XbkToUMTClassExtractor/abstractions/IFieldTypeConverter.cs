namespace XbkToUMTClassExtractor.Abstractions
{
    public interface IFieldTypeConverter
    {
        string DefaultColumnType { get; set; }
        int DefaultColumnSize { get; set; }
        string DefaultControlName { get; set; }
        //string GetColumnType(TemplateField field);
        //int GetColumnSize(TemplateField field);
        //DataClassFieldSettings GetFieldSettings(TemplateField field);
        //TargetFieldValue Convert(Field field, Item item);
    }
}
