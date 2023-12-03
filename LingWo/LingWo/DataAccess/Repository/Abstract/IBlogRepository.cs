using LingWo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LingWo.DataAccess.Repository.Abstract
{
    public interface IBlogRepository : IRepository<Blog, int>
    {
        IEnumerable<SelectListItem> GetDropDown();
    }
}