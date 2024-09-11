using DotNet8.REPRPattern.Api.Entities;

namespace DotNet8.REPRPattern.Api.Features.Blog.GetBlogList
{
    public class GetBlogListDTO
    {
        public IQueryable<Tbl_Blog> Blogs { get; set; }
    }
}
