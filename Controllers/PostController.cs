using todo.Api.Dtos;
using todo.Api.Helpers;
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
        public IEnumerable<PostDto> GetPosts()
        {
            var posts = repository.GetPosts().Select(x => x.Mapper());
            return posts;
        }

        [HttpGet("getPost/{id}")]
        public ActionResult<PostDto> GetPost(Guid id)
        {
            var post = repository.GetPost(id).Mapper();

            if (post == null)
            {
                return NotFound(post);
            }

            return post;
        }

        [HttpPost("createPost")]
        public ActionResult<PostDto> CreatePost(CreatePostDto createPostDto)
        {
            Post post = new()
            {
                Id = Guid.NewGuid(),
                UserCode = createPostDto.UserCode,
                EntryDate = DateTime.Today,
                ChannelCode = createPostDto.ChannelCode,
                Notes = createPostDto.Notes,
                StatusCode = createPostDto.StatusCode,
                ExpireDate = createPostDto.ExpireDate
            };

            repository.CreatePost(post);

            //döndürülen nesnenin oluşturulma bilgilerini getirir
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post.Mapper());
        }

        [HttpPut("updatePost/{id}")]
        public ActionResult<PostDto> UpdateItem(Guid id, UpdatePostDto updatePostDto)
        {
            var existingPost = repository.GetPost(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            Post post = new()
            {
                Id = id,
                UserCode = updatePostDto.UserCode,
                EntryDate = existingPost.EntryDate,
                ChannelCode = updatePostDto.ChannelCode,
                Notes = updatePostDto.Notes,
                StatusCode = updatePostDto.StatusCode,
                ExpireDate = updatePostDto.ExpireDate
            };

            repository.UpdatePost(post);

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post.Mapper());
        }
    }

}