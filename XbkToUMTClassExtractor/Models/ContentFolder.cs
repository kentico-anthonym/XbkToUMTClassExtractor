using System.Text.Json.Serialization;

namespace XbkToUMTClassExtractor.Models
{
    [Serializable]
    public class ContentFolder
    {
        [JsonPropertyName("$type")]
        public string Type => "ContentFolder";
        public Guid ContentFolderGUID { get; set; }
        public Guid? ContentFolderParentFolderGUID { get; set; }
        public string ContentFolderName { get; set; }
        public string ContentFolderDisplayName { get; set; }
        public string ContentFolderTreePath { get; set; }
    }
}