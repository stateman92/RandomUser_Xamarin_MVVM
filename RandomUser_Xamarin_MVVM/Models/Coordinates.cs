using Newtonsoft.Json;
using Realms;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class Coordinates : RealmObject
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
