using System.Threading.Tasks;

using RandomUser_Xamarin_MVVM.Models;

namespace RandomUser_Xamarin_MVVM.Services
{
    public interface IApiCommunicationService
    {
        Task<User[]> GetUsers(int page, int numberOfResults, string seed);
    }
}
