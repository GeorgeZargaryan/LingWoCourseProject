namespace LingWo.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }
        public DateTime UploadDate { get; set; }
    }
}