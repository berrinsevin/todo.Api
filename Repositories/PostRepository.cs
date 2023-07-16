using todo.Api.Entities;

namespace todo.Api.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> posts = new()
        {
            new Post { Id = Guid.NewGuid(), UserCode = "BERRINS", ChannelCode = Enums.ChannelCode.Personal, EntryDate = new DateTime(2023, 7, 1), StatusCode = Enums.StatusCode.ToDo, ExpireDate = new DateTime(2023, 7, 30), Notes = "ToDo için api yazılacak"},
            new Post { Id = Guid.NewGuid(), UserCode = "DENIZK", ChannelCode = Enums.ChannelCode.NotSpecified, EntryDate = new DateTime(2023, 7, 1), StatusCode = Enums.StatusCode.InProgress, ExpireDate = new DateTime(2023, 7, 30), Notes = "Döküman hazırlanması"}
        };

        public IEnumerable<Post> GetPosts()
        {
            return posts;
        }

        public Post GetPost(Guid id)
        {
            return posts.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}