using System.ComponentModel.DataAnnotations;

namespace LingWo.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogLink { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogThumb { get; set; }
        [MaxLength]
        public string BlogContent { get; set; }
        public string? RelatedIds { get; set; }
    }
}