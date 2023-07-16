using todo.Api.Entities;

namespace todo.Api.Repositories
{
    public interface IPostRepository
    {
        Post GetPost(Guid id);
        IEnumerable<Post> GetPosts();
    }
}