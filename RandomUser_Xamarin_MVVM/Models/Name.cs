using Realms;
using Newtonsoft.Json;

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
