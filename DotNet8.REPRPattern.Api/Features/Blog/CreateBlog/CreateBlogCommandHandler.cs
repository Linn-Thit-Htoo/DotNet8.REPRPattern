using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Entities;
using DotNet8.REPRPattern.Api.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNet8.REPRPattern.Api.Features.Blog.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<Tbl_Blog>>
    {
        private readonly AppDbContext _context;
        private readonly BlogValidator _blogValidator;

        public CreateBlogCommandHandler(AppDbContext context, BlogValidator createBlogValidator)
        {
            _context = context;
            _blogValidator = createBlogValidator;
        }

        public async Task<Result<Tbl_Blog>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Result<Tbl_Blog> result;
            try
            {
                var validationResult = await _blogValidator.ValidateAsync(request.CreateBlogRequest, cancellationToken);
                if (!validationResult.IsValid)
                {
                    string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
                    result = Result<Tbl_Blog>.Fail(errors);
                    goto result;
                }

                await _context.Tbl_Blogs.AddAsync(request.CreateBlogRequest.ToEntity(), cancellationToken);
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
