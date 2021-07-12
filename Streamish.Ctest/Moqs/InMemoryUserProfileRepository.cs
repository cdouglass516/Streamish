using System;
using System.Collections.Generic;
using System.Linq;
using Streamish.Models;
using Streamish.Models.ViewModels;
using Streamish.Repositories;

namespace Streamish.Ctest.Moqs
{
    class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile Edit(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(x=>x.Id == id);
        }

        public UserProfileVideo GetByIdWithVideosAndComments(int id)
        {
            throw new NotImplementedException();
        }
    }
}
