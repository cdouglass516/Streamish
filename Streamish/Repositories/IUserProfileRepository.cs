using Streamish.Models;
using System.Collections.Generic;

namespace Streamish.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile user);
        void Delete(int id);
        UserProfile Edit(UserProfile user);
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
    }
}