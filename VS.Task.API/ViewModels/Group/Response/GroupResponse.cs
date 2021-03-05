using System.Collections.Generic;
using System.Text.Json.Serialization;
using VS.Task.API.ViewModels.Provider.Response;

namespace VS.Task.API.ViewModels.Group.Response
{
    public class GroupResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("providers")]
        public List<ProviderResponse> Providers { get; set; }
    }
}
