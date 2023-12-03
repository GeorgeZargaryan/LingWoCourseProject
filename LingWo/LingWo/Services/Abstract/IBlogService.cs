using LingWo.DataAccess.Repository.Abstract;
using LingWo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LingWo.Services.Abstract
{
    public interface IBlogService : IService<Blog, int>
    {
        IEnumerable<SelectListItem> GetDropDown();
    }

}