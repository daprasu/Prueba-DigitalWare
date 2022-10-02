using Microsoft.AspNetCore.Mvc;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace PruebaDigitalware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var posts = await _postRepository.GetPosts();
            return Ok (posts);
        }
    }
}
