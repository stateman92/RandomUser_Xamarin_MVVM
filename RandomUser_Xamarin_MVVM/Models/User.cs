using Realms;
using Newtonsoft.Json;

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

        /// <summary>
        /// Returns the full name (firstly the first name and then the last).
        /// </summary>
        public string FullName
        {
            get => $"{Name.Title} {Name.First} {Name.Last}";
        }

        /// <summary>
        /// Returns the ways the user can be reached in a formatted string.
        /// </summary>
        public string Accessibilities
        {
            get => $"Contacts:\n\tEmail: {Email}\n\tCellphone: {Cell}\n\tPhone: {Phone}";
        }

        /// <summary>
        /// Returns the location of the user in a formatted string.
        /// </summary>
        public string ExpandedLocation
        {
            get => $"Address:\n\t{Location.Country}, {Location.State}, {Location.City}\n\tStreet {Location.Street.Name} {Location.Street.Number}";
        }
    }
}
