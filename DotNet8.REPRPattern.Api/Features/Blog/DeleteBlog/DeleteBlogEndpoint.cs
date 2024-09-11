using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.REPRPattern.Api.Features.Blog.DeleteBlog
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBlogEndpoint : BaseController
    {
        private readonly IMediator _mediator;

        public DeleteBlogEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteBlogCommand(id);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }
    }
}
