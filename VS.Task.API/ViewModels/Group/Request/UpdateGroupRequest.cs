using System.Text.Json.Serialization;

namespace VS.Task.API.ViewModels.Group.Request
{
    public class UpdateGroupRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
