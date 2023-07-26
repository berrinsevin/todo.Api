using System.Linq.Expressions;
using todo.Api.Dtos;
using todo.Api.Entities;
using todo.Api.Repositories;

namespace todo.Api.Services
{
    public class PostService : IPostService
    {
        private readonly ITodoRepository<Post> postRepository;

        public PostService(ITodoRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<bool> CreatePostAsync(RequestPostDto createPostDto)
        {
            if (createPostDto != null)
            {
                Post post = new()
                {
                    UserCode = createPostDto.UserCode,
                    EntryDate = DateTime.Today,
                    ChannelCode = createPostDto.ChannelCode,
                    Notes = createPostDto.Notes,
                    StatusCode = createPostDto.StatusCode,
                    ExpireDate = createPostDto.ExpireDate
                };

                await postRepository.AddAsync(post);

                return true;
            }

            throw new Exception("Request cannot be null");
        }

        public async Task<Post> GetPostByIdAsync(long id)
        {
            if (id > 0)
            {
                return await postRepository.GetById(id);
            }

            throw new Exception("Id should be greater than 0");
        }

        public async Task<List<Post>> GetPostListAsync(RequestPostDto requestItem)
        {
            if (requestItem != null)
            {
                IQueryable<Post> postList = await postRepository.Find(x =>
                        x.StatusCode == requestItem.StatusCode &&
                        x.ChannelCode == requestItem.ChannelCode &&
                        x.ExpireDate <= requestItem.ExpireDate);

                if (postList != null)
                {
                    return postList.ToList();
                }
            }

            return null;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            if (post != null)
            {
                return await postRepository.UpdateAsync(post);
            }

            throw new Exception("Request cannot be null");
        }
    }
}