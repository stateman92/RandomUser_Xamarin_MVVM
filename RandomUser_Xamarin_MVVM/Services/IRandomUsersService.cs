using System.Linq;
using System.Collections.ObjectModel;

using Realms;

namespace RandomUser_Xamarin_MVVM.Services
{
    public interface IRandomUsersService
    {
        /// <summary>
        /// Store a RealmObject into a database.
        /// </summary>
        /// <param name="realmObject">The object that will be stored.</param>
        void CreateOrUpdatePersistentValue(RealmObject realmObject);

        /// <summary>
        /// Store some RealmObjects into a database.
        /// </summary>
        /// <param name="realmObjects">The objects that will be stored.</param>
        void CreateOrUpdatePersistentValues(Collection<RealmObject> realmObjects);

        /// <summary>
        /// Retrieve the Z type elements from the database.
        /// </summary>
        IQueryable<Z> ReadPersistentValue<Z>() where Z : RealmObject;

        /// <summary>
        /// Delete the Z type element from the database.
        /// </summary>
        void DeletePersistentValue<Z>() where Z : RealmObject;
    }
}
