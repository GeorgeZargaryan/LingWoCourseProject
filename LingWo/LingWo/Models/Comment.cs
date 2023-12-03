using System.Net.Mime;
using System.ComponentModel.DataAnnotations;

namespace LingWo.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [MaxLength]
        public string CommentBody { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
    }
}