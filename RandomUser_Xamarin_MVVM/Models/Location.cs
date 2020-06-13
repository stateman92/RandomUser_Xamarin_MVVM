using Realms;
using Newtonsoft.Json;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class Location : RealmObject
    {
        [JsonProperty("street")]
        public Street Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }
}
