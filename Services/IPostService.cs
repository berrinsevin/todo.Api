using todo.Api.Dtos;
using todo.Api.Entities;

namespace todo.Api.Services
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(RequestPostDto createPostDto);
        Task<Post> GetPostByIdAsync(long id);
        Task<List<Post>> GetPostListAsync(RequestPostDto requestItem);
        Task<bool> UpdatePostAsync(Post post);
    }
}