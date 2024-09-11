using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<Tbl_Blog>>
    {
        private readonly AppDbContext _context;
        private readonly BlogValidator _blogValidator;

        public UpdateBlogCommandHandler(AppDbContext context, BlogValidator blogValidator)
        {
            _context = context;
            _blogValidator = blogValidator;
        }

        public async Task<Result<Tbl_Blog>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Result<Tbl_Blog> result;
            try
            {
                var blog = await _context.Tbl_Blogs.FindAsync([request.BlogId, cancellationToken], cancellationToken: cancellationToken);
                if (blog is null)
                {
                    result = Result<Tbl_Blog>.NotFound();
                    goto result;
                }

                blog.BlogTitle = request.UpdateBlogRequest.BlogTitle;
                blog.BlogAuthor = request.UpdateBlogRequest.BlogAuthor;
                blog.BlogContent = request.UpdateBlogRequest.BlogContent;

                _context.Tbl_Blogs.Update(blog);
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
