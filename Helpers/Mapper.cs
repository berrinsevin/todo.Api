using todo.Api.Dtos;
using todo.Api.Entities;

namespace todo.Api.Helpers
{
    public static class TodoMapper
    {
        public static PostDto Mapper(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserCode = post.UserCode,
                EntryDate = post.EntryDate,
                ChannelCode = post.ChannelCode,
                Notes = post.Notes,
                StatusCode = post.StatusCode,
                ExpireDate = post.ExpireDate
            };
        }

    }
}