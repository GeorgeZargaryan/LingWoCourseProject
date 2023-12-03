using Microsoft.AspNetCore.Mvc.Rendering;

namespace LingWo.Models.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public IEnumerable<SelectListItem> RelatedBlogs { get; set; }
    }
}