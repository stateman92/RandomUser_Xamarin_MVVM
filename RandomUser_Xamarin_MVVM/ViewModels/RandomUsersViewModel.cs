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
        private readonly IApiCommunicationService apiCommunicationService;

        private readonly IRandomUsersService randomUsersService;

        private int numberOfUserPerPage = 10;

        private int nextPage
        {
            get => Users.Count / numberOfUserPerPage + 1;
        }

        private string seed = Guid.NewGuid().ToString();

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

        public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();

        public bool IsRefreshing { get; set; } = false;

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

    public partial class RandomUsersViewModel
    {
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

        private async void UpdatedUsers()
        {
            await Task.Delay(50);
            numberOfDistinctUsers = (from x in Users
                                     select x).Distinct().Count();
        }

        private void Changed(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }
    }
}
