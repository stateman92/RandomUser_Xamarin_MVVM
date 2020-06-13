using System.Linq;
using System.Collections.ObjectModel;

using Realms;

namespace RandomUser_Xamarin_MVVM.Services
{
    public interface IRandomUsersService
    {
        void CreateOrUpdatePersistentValue(RealmObject realmObject);

        void CreateOrUpdatePersistentValues(Collection<RealmObject> realmObjects);

        IQueryable<Z> ReadPersistentValue<Z>() where Z : RealmObject;

        void DeletePersistentValue<Z>() where Z : RealmObject;
    }
}
