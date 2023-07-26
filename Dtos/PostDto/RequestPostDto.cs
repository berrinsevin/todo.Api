using todo.Api.Enums;

namespace todo.Api.Dtos
{
    public class RequestPostDto
    {
        public string UserCode { get; init; }
        public ChannelCode ChannelCode { get; set; }
        public string Notes { get; set; }
        public StatusCode StatusCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}