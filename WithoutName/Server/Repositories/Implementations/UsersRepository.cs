using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private List<User> _users = new List<User>(); 
        void IUsersRepository.AddUser(User user)
        {
            _users.Add(user);   
        }

        List<User> IUsersRepository.Get(int id)
        {
            return _users.Where(x => x.Id == id).ToList();
        }

        List<User> IUsersRepository.GetAll()
        {
            return _users;
        }
       
        void IUsersRepository.RemoveUser(int id)
        {
            _users.Remove(_users.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
