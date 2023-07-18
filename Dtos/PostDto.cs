using todo.Api.Enums;

namespace todo.Api.Dtos
{
    public class PostDto
    {
        public Guid Id { get; init; }
        public string UserCode { get; init; }
        public DateTime EntryDate { get; set; }
        public ChannelCode ChannelCode { get; set; }
        public string Notes { get; set; }
        public StatusCode StatusCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}