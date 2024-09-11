using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<Tbl_Blog>>
    {
        private readonly AppDbContext _context;

        public CreateBlogCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public Task<Result<Tbl_Blog>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Result<Tbl_Blog> result;
            try
            {

            }
            catch (Exception ex)
            {
                result = Result<Tbl_Blog>.Fail(ex);
            }

        result:
            return result;
        }
    }
}
