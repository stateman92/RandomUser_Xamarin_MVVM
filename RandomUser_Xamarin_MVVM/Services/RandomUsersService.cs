using System.Linq;
using System.Collections.ObjectModel;

using Xamarin.Forms.Internals;

using Realms;

namespace RandomUser_Xamarin_MVVM.Services
{
    public class RandomUsersService : IRandomUsersService
    {
        /// <summary>
        /// Store a RealmObject into a database.
        /// </summary>
        /// <param name="realmObject">The object that will be stored.</param>
        public void CreateOrUpdatePersistentValue(RealmObject realmObject)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(realmObject, true);
            });
        }

        /// <summary>
        /// Store some RealmObjects into a database.
        /// </summary>
        /// <param name="realmObjects">The objects that will be stored.</param>
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

        /// <summary>
        /// Retrieve the Z type elements from the database.
        /// </summary>
        public IQueryable<Z> ReadPersistentValue<Z>() where Z : RealmObject
        {
            var realm = Realm.GetInstance();
            return realm.All<Z>();
        }

        /// <summary>
        /// Delete the Z type element from the database.
        /// </summary>
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
