using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Entities;
using DotNet8.REPRPattern.Api.Extensions;
using DotNet8.REPRPattern.Api.Features.Blog.DeleteBlog;
using DotNet8.REPRPattern.Api.Features.PageSetting;
using DotNet8.REPRPattern.Api.Resources;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.REPRPattern.Api.Features.Blog.GetBlogList
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<GetBlogListDTO>>
    {
        private readonly AppDbContext _context;

        public GetBlogListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetBlogListDTO>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            Result<GetBlogListDTO> result;
            try
            {
                if (request.PageNo <= 0)
                {
                    result = Result<GetBlogListDTO>.Fail(MessageResource.InvalidPageNo);
                    goto result;
                }

                if (request.PageSize <= 0)
                {
                    result = Result<GetBlogListDTO>.Fail(MessageResource.InvalidPageNo);
                    goto result;
                }

                var lst = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId).Paginate(request.PageNo, request.PageSize);
                var totalCount = await lst.CountAsync(cancellationToken);
                var pageCount = totalCount / request.PageSize;

                if (totalCount % request.PageSize > 0)
                {
                    pageCount++;
                }

                var model = new GetBlogListDTO()
                {
                    Blogs = lst,
                    PageSetting = new PageSettingDTO(request.PageNo, request.PageSize, pageCount, totalCount)
                };

                result = Result<GetBlogListDTO>.Success(model);
            }
            catch (Exception ex)
            {
                result = Result<GetBlogListDTO>.Fail(ex);
            }

        result:
            return result;
        }
    }
}
