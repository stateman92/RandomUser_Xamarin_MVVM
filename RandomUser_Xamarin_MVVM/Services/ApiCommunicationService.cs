using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;

using Newtonsoft.Json;

using RandomUser_Xamarin_MVVM.Models;

namespace RandomUser_Xamarin_MVVM.Services
{
    public class ApiCommunicationService : IApiCommunicationService
    {
        private const string BaseApiURL = "https://randomuser.me/api/?inc=name,picture,gender,location,email,phone,cell";

        public async Task<User[]> GetUsers(int page, int numberOfResults, string seed)
        {
            var userResultJSON = await new HttpClient().GetStringAsync(CreateUrl(page, numberOfResults, seed));

            var userResult = JsonConvert.DeserializeObject<UserResult>(userResultJSON);

            return userResult.Results;
        }

        private string CreateUrl(int page, int numberOfResults, string seed)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("inc", "name,picture,gender,location,email,phone,cell");
            queryString.Add("page", page.ToString());
            queryString.Add("results", numberOfResults.ToString());
            queryString.Add("seed", seed);

            return BaseApiURL + queryString.ToString();
        }
    }
}
