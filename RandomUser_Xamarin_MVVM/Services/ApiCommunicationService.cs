using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;

using Newtonsoft.Json;

using RandomUser_Xamarin_MVVM.Models;

namespace RandomUser_Xamarin_MVVM.Services
{
    public class ApiCommunicationService : IApiCommunicationService
    {
        /// <summary>
        /// The API URL (in string format).
        /// </summary>
        private const string BaseApiURL = "https://randomuser.me/api/?inc=name,picture,gender,location,email,phone,cell";

        /// <summary>
        /// Download random users with the given parameters.
        /// </summary>
        /// <param name="page">The page that wanted to be downloaded.</param>
        /// <param name="results">The number of results in a page.</param>
        /// <param name="seed">The API use this to give back some data. For the same seed it gives back the same results.</param>
        public async Task<User[]> GetUsers(int page, int numberOfResults, string seed)
        {
            var userResultJSON = await new HttpClient().GetStringAsync(CreateUrl(page, numberOfResults, seed));
            var userResult = JsonConvert.DeserializeObject<UserResult>(userResultJSON);
            return userResult.Results;
        }

        /// <summary>
        /// Creates a string (URL) with the given query parameters.
        /// </summary>
        /// <param name="page">The page that wanted to be downloaded.</param>
        /// <param name="results">The number of results in a page.</param>
        /// <param name="seed">The API use this to give back some data. For the same seed it gives back the same results.</param>
        /// <remarks>
        /// The string stores that too, that which data will be requested.
        /// The result of this method request from the API the `name`, `picture`, `gender`, `location`, `email`, `phone` and `cell`.
        /// </remarks>
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
