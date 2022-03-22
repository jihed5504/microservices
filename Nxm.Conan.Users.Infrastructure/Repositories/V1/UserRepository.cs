using MongoDB.Driver;
using Conan_1.Entities.V1;
using Nxm.Conan.Users.Infrastructure.Data.DbConfigs;

namespace Nxm.Conan.Users.Infrastructure.Repositories.V1
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IDatabaseConfigurations settings) : base(settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

    }
}
