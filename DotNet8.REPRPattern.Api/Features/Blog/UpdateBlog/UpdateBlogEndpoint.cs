using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.REPRPattern.Api.Features.Blog.UpdateBlog
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBlogEndpoint : BaseController
    {
        private readonly IMediator _mediator;

        public UpdateBlogEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogRequestDTO updateBlogRequest, int id, CancellationToken cancellationToken)
        {
            var command = new UpdateBlogCommand(updateBlogRequest, id);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }
    }
}
