using Newtonsoft.Json;
using Realms;

namespace RandomUser_Xamarin_MVVM.Models
{
    public class User : RealmObject
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        public string FullName
        {
            get => $"{Name.Title} {Name.First} {Name.Last}";
        }

        public string Accessibilities
        {
            get => $"Contacts:\n\tEmail: {Email}\n\tCellphone: {Cell}\n\tPhone: {Phone}";
        }

        public string ExpandedLocation
        {
            get => $"Address:\n\t{Location.Country}, {Location.State}, {Location.City}\n\tStreet {Location.Street.Name} {Location.Street.Number}";
        }
    }
}
