using System;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using Realms;

using RandomUser_Xamarin_MVVM.Models;
using RandomUser_Xamarin_MVVM.Services;

namespace RandomUser_Xamarin_MVVM.ViewModels
{
    public partial class RandomUsersViewModel : BaseViewModel
    {
        /// <summary>
        /// MVVM architecture elements.
        /// </summary>
        private readonly IApiCommunicationService apiCommunicationService;
        private readonly IRandomUsersService randomUsersService;

        /// <summary>
        /// Number of users that will be downloaded at the same time.
        /// </summary>
        private int numberOfUserPerPage = 10;

        /// <summary>
        /// Returns the number of the next page.
        /// </summary>
        private int nextPage
        {
            get => Users.Count / numberOfUserPerPage + 1;
        }

        /// <summary>
        /// The initial seed value. Changed after all refresh / restart.
        /// </summary>
        private string seed = Guid.NewGuid().ToString();

        /// <summary>
        /// Self-check, that actually distinct users are fetched.
        /// </summary>
        /// <remarks>
        /// Can be used to display somewhere.
        /// </remarks>
        private int _numberOfDistinctUsers { get; set; }
        private int numberOfDistinctUsers
        {
            get => _numberOfDistinctUsers;
            set
            {
                _numberOfDistinctUsers = value;
                Changed("NumberOfDistinctUsers");
            }
        }
        public string NumberOfDistinctUsers
        {
            get => $"Users: {numberOfDistinctUsers}";
        }

        /// <summary>
        /// The so far fetched user data.
        /// </summary>
        public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();

        public bool IsRefreshing { get; set; } = false;

        /// <summary>
        /// The commands.
        /// </summary>
        public ICommand LoadMoreItemsCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public RandomUsersViewModel(IApiCommunicationService apiCommunicationService, IRandomUsersService randomUsersService)
        {
            this.apiCommunicationService = apiCommunicationService;
            this.randomUsersService = randomUsersService;
            LoadMoreItemsCommand = new Command(async () => await GetMoreUsers());
            RefreshCommand = new Command(async () => await GetMoreUsers(true));

            var users = randomUsersService.ReadPersistentValue<User>();
            if (users.Count() > 0)
            {
                users.ForEach(user =>
                    Users.Add(user)
                );
                UpdatedUsers();
            }
            else
            {
                GetMoreUsers();
            }
        }
    }

    // Private functionaly part.
    public partial class RandomUsersViewModel
    {
        /// <summary>
        /// Indicate that the user wants more data to be downloaded.
        /// </summary>
        /// <param name="refresh">Whether the user wants to refresh all data (and ask for new), or wants just some more user data.</param>
        private async Task GetMoreUsers(bool refresh = false)
        {
            await Task.Delay(50);
            if (refresh)
            {
                IsRefreshing = true;
                Users.Clear();
                ConsumeUserArray(new User[] { });
                seed = Guid.NewGuid().ToString();
                randomUsersService.DeletePersistentValue<User>();
            }
            Changed("IsRefreshing");
            var userArray = await apiCommunicationService.GetUsers(nextPage, numberOfUserPerPage, seed);
            ConsumeUserArray(userArray);
            IsRefreshing = false;
            Changed("IsRefreshing");
        }

        /// <summary>
        /// Consume the incoming array of Users. Store it persistently if necessary.
        /// </summary>
        /// <param name="userArray">The incoming array</param>
        private void ConsumeUserArray(User[] userArray)
        {
            userArray.ForEach(user =>
                Users.Add(user)
            );
            UpdatedUsers();
            var users = randomUsersService.ReadPersistentValue<User>();
            if (Users.Count > numberOfUserPerPage)
            {
                var collection = new Collection<RealmObject>();
                Users.ForEach(user =>
                    collection.Add(user)
                );
                randomUsersService.CreateOrUpdatePersistentValues(collection);
            }
        }

        /// <summary>
        /// Tell to the UI layer that the users' number is updated.
        /// </summary>
        private async void UpdatedUsers()
        {
            await Task.Delay(50);
            numberOfDistinctUsers = (from x in Users
                                     select x).Distinct().Count();
        }

        /// <summary>
        /// A wrapper, that makes a PropertyChanged call more convenient.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        private void Changed(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }
    }
}
