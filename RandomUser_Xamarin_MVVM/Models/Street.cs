using Newtonsoft.Json;
using Realms;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class Street : RealmObject
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
