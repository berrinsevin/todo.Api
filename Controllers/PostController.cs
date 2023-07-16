using todo.Api.Entities;
using todo.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace todo.Api.Controllers
{
    [ApiController]
    [Route("PostController")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository repository;

        public PostController(IPostRepository repository)
        {
            this.repository = repository;
        }

        // Dependency injection olmadan, controller'ın constructor ında repository için constructor oluşturulur 

        //private readonly PostRepository repository;
        // public PostController()
        // {
        //     repository = new PostRepository();
        // }

        [HttpGet("getPosts")]
        public IEnumerable<Post> GetPosts()
        {
            var posts = repository.GetPosts();
            return posts;
        }

        [HttpGet("getPost/{id}")]
        public ActionResult<Post> GetPost(Guid id)
        {
            var post = repository.GetPost(id);
            if (post == null)
            {
                return NotFound(post);
            }
            return post;
        }
    }

}