using DotNet8.REPRPattern.Api.Entities;
using MediatR;

namespace DotNet8.REPRPattern.Api.Features.Blog.GetBlogList
{
    public class GetBlogListQuery : IRequest<Result<GetBlogListDTO>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public GetBlogListQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }
    }
}
