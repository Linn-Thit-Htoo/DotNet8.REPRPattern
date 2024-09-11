using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.CreateBlog
{
    public class CreateBlogCommand : IRequest<Result<Tbl_Blog>>
    {
        public CreateBlogRequestDTO CreateBlogRequest { get; set; }

        public CreateBlogCommand(CreateBlogRequestDTO createBlogRequest)
        {
            CreateBlogRequest = createBlogRequest;
        }
    }
}
