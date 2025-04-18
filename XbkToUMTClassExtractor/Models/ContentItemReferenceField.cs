namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentItemReferenceField
    {
        public ContentItemReferenceField(Guid identifier)
        {
            Identifier = identifier;
        }

        public Guid Identifier { get; set; }
    }
}