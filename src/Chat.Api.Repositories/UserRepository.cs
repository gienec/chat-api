using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Chat.Api.Repositories.Exceptions;
using Chat.Api.Repositories.Models;

namespace Chat.Api.Repositories
{
    public interface IUserRepository
    {
        void Create(string token, User user);
        User GetById(string id);
        User GetByToken(string token);
        IList<User> GetAll();
        void Remove(string contextConnectionId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<string, User> _users;

        public UserRepository()
        {
            _users = new ConcurrentDictionary<string, User>();
        }

        public void Create(string token, User user)
        {
            if (!UserExists(user))
            {
                _users.TryAdd(token, user);
            }
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public User GetById(string token)
        {
            _users.TryGetValue(token, out User user);

            if (user == null)
            {
                throw new UserNotFoundException($"User with name '{user.Name}' not found");
            }

            return user;
        }

        public User GetByToken(string token)
        {
            _users.TryGetValue(token, out User user);

            if (user == null)
            {
                throw new UserNotFoundException($"User with name '{user.Name}' not found");
            }

            return user;
        }

        public IList<User> GetAll()
        {
            return _users.Values.ToList();
        }

        public void Remove(string contextConnectionId)
        {
            throw new NotImplementedException();
        }

        private bool UserExists(User user)
        {
            return GetById(user.Id) != null;
        }
    }
}
