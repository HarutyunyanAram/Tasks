using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VS.Task.API.ViewModels.Provider.Request
{
    public class CreateProviderRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Required]
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }
    }
}
