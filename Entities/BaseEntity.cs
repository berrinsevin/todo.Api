using System.Text.Json.Serialization;

namespace todo.Api.Entities
{
    public class BaseEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}