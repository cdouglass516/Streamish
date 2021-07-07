using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Streamish.Models;
using Streamish.Utils;

namespace Streamish.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserProfile> GetAll()
        {
            return new List<UserProfile>();
        }

        public UserProfile GetById(int id)
        {
            return new UserProfile();
        }

        public void Delete(int id)
        {

        }

        public void Add(UserProfile user)
        {

        }

        public UserProfile Edit(UserProfile user)
        {
            return new UserProfile();
        }
    }
}
