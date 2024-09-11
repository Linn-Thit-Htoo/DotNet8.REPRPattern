using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.REPRPattern.Api.Features.Blog.GetBlogList
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBlogListEndpoint : BaseController
    {
        private readonly IMediator _mediator;

        public GetBlogListEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogList(int pageNo, int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetBlogListQuery(pageNo, pageSize);
            var result = await _mediator.Send(query, cancellationToken);

            return Content(result);
        }
    }
}
