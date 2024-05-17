using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class User

    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "email")]

        public string Email { get; set; }
        
    }
}
