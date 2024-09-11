using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<Result<Tbl_Blog>>
    {
        public UpdateBlogRequestDTO UpdateBlogRequest { get; set; }
        public int BlogId { get; set; }

        public UpdateBlogCommand(UpdateBlogRequestDTO updateBlogRequest, int blogId)
        {
            UpdateBlogRequest = updateBlogRequest;
            BlogId = blogId;
        }
    }
}
