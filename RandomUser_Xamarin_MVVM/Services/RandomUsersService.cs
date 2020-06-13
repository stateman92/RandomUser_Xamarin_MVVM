using System.Linq;
using System.Collections.ObjectModel;

using Xamarin.Forms.Internals;

using Realms;

namespace RandomUser_Xamarin_MVVM.Services
{
    public class RandomUsersService : IRandomUsersService
    {
        public void CreateOrUpdatePersistentValue(RealmObject realmObject)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(realmObject, true);
            });
        }

        public void CreateOrUpdatePersistentValues(Collection<RealmObject> realmObjects)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realmObjects.ForEach(realmObject =>
                    realm.Add(realmObject, true)
                );
            });
        }

        public IQueryable<Z> ReadPersistentValue<Z>() where Z : RealmObject
        {
            var realm = Realm.GetInstance();
            return realm.All<Z>();
        }

        public void DeletePersistentValue<Z>() where Z : RealmObject
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.RemoveAll<Z>();
            });
        }
    }
}
