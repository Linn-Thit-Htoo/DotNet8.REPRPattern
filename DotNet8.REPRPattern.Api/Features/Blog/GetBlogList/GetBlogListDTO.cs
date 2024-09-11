using DotNet8.REPRPattern.Api.Entities;
using DotNet8.REPRPattern.Api.Features.PageSetting;

namespace DotNet8.REPRPattern.Api.Features.Blog.GetBlogList
{
    public class GetBlogListDTO
    {
        public IQueryable<Tbl_Blog> Blogs { get; set; }
        public PageSettingDTO PageSetting { get; set; }
    }
}
