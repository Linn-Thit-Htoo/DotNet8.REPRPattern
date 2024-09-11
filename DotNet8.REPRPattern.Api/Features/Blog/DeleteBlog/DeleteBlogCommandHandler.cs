using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Entities;
using DotNet8.REPRPattern.Api.Resources;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<Tbl_Blog>>
    {
        private readonly AppDbContext _context;

        public DeleteBlogCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Tbl_Blog>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            Result<Tbl_Blog> result;
            try
            {
                if (request.BlogId <= 0)
                {
                    result = Result<Tbl_Blog>.Fail(MessageResource.InvalidId);
                    goto result;
                }

                var blog = await _context.Tbl_Blogs.FindAsync([request.BlogId, cancellationToken], cancellationToken: cancellationToken);
                if (blog is null)
                {
                    result = Result<Tbl_Blog>.NotFound();
                    goto result;
                }

                _context.Tbl_Blogs.Remove(blog);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<Tbl_Blog>.Success();
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
