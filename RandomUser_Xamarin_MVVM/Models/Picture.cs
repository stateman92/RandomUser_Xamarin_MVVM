using System;

using Newtonsoft.Json;
using Realms;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class Picture : RealmObject
    {
        [JsonProperty("large")]
        public String Large { get; set; }

        [JsonProperty("medium")]
        public String Medium { get; set; }

        [JsonProperty("thumbnail")]
        public String Thumbnail { get; set; }
    }
}
