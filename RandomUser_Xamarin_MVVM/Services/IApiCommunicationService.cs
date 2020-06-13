using System.Threading.Tasks;

using RandomUser_Xamarin_MVVM.Models;

namespace RandomUser_Xamarin_MVVM.Services
{
    public interface IApiCommunicationService
    {
        /// Download random users with the given parameters.
        /// - Parameters:
        ///   - page: the page that wanted to be downloaded.
        ///   - results: the number of results in a page.
        ///   - seed: the API use this to give back some data. For the same seed it gives back the same results.
        ///   - completion: will be called after the data is ready in an array, or an error occured. Both parameters in the same time couldn't be `nil`.
        Task<User[]> GetUsers(int page, int numberOfResults, string seed);
    }
}
