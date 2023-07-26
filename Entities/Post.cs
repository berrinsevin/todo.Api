using todo.Api.Enums;

namespace todo.Api.Entities
{
    public class Post : BaseEntity
    {
        public string UserCode { get; init; }
        public DateTime EntryDate { get; set; }
        public ChannelCode ChannelCode { get; set; }
        public string Notes { get; set; }
        public StatusCode StatusCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}