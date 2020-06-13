using Newtonsoft.Json;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class UserResult
    {
        [JsonProperty("results")]
        public User[] Results { get; set; }
    }
}
