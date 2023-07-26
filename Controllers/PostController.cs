using todo.Api.Dtos;
using todo.Api.Helpers;
using todo.Api.Services;
using todo.Api.Entities;
using todo.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace todo.Api.Controllers
{
    [ApiController]
    [Route("PostController")]
    public class PostController : ControllerBase
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet("GetPostListAsync")]
        public async Task<IActionResult> GetPostListAsync(RequestPostDto listRequest)
        {
            if (listRequest != null)
            {
                var postList = await service.GetPostListAsync(listRequest);

                if (postList != null)
                {
                    return Ok(listRequest);
                }
            }

            return BadRequest("There is no post matching the search criteria");
        }

        [HttpGet("GetPostAsync/{id}")]
        public async Task<ActionResult> GetPostAsync(long id)
        {
            var post = await service.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound("There is no post suitable for this id");
            }

            return Ok(post.MappingPostDto());
        }

        [HttpPost("CreatePostAsync")]
        public async Task<ActionResult> CreatePostAsync(RequestPostDto postRequest)
        {
            ValidationResult validationResult = await new PostRequestValidator().ValidateAsync(postRequest);

            if (validationResult.IsValid)
            {
                if (await service.CreatePostAsync(postRequest))
                {
                    return Ok();
                    //berrins oluşturulan post döndürülsün
                    //return CreatedAtAction(nameof(GetPost), new { id = createPostDto.Id }, post.MappingPostDto());
                }
            }

            return BadRequest();
        }

        [HttpPut("UpdatePostAsync/{id}")]
        public async Task<ActionResult> UpdatePostAsync(long id, RequestPostDto updateRequest)
        {
            ValidationResult validationResult = await new PostRequestValidator().ValidateAsync(updateRequest);

            var currentPost = await service.GetPostByIdAsync(id);
            if (currentPost == null)
            {
                return NotFound("There is no post suitable for this id");
            }

            Post post = new()
            {
                Id = id,
                UserCode = updateRequest.UserCode,
                ChannelCode = updateRequest.ChannelCode,
                Notes = updateRequest.Notes,
                StatusCode = updateRequest.StatusCode,
                ExpireDate = updateRequest.ExpireDate
            };

            if (!await service.UpdatePostAsync(post))
            {
                return BadRequest();
            }

            return Ok();
            //berrins oluşturulan post döndürülsün
            //return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post.MappingPostDto());
        }
    }

}