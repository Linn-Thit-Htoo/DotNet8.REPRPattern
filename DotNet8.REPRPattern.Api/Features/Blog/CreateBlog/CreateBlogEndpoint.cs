using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.REPRPattern.Api.Features.Blog.CreateBlog
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBlogEndpoint : BaseController
    {
        private readonly IMediator _mediator;

        public CreateBlogEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogRequestDTO createBlogRequest, CancellationToken cancellationToken)
        {
            var command = new CreateBlogCommand(createBlogRequest);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }
    }
}
