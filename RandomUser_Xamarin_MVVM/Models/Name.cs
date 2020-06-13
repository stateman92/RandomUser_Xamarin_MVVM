using Newtonsoft.Json;
using Realms;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class Name : RealmObject
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}
