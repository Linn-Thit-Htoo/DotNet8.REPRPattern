using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<Result<Tbl_Blog>>
    {
        public int BlogId { get; set; }

        public DeleteBlogCommand(int blogId)
        {
            BlogId = blogId;
        }
    }
}
