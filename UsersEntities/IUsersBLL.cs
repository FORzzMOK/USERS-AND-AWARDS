using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersEntities
{
    public interface IUsersBLL
    {
        void CreateNewUser(string _name, DateTime _dateOfBirth);
        bool DeleteUser(int usersId);
        string ShowUser(int usersId);
        string ShowUsersList();
        bool AppendAwards(int usersId, string award);
    }
}
