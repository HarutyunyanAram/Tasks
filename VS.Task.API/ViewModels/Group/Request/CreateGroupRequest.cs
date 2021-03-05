using System.Text.Json.Serialization;

namespace VS.Task.API.ViewModels.Group.Request
{
    public class CreateGroupRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
