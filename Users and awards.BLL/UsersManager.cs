using System;
using Users.Common;
using UsersEntities;


namespace Users_and_awards.BLL
{
    public class UsersManager : IUsersBLL
    {
        public void CreateNewUser(string _name, DateTime _dateOfBirth)
        {
            User newUser = new User
            {
                Name = _name,
                DateOfBirth = _dateOfBirth
            };
            newUser.Id = DependensiesВatabase.UsersStorage.GetId();
            DependensiesВatabase.UsersStorage.AddUser(newUser);
        }
        public bool DeleteUser(int usersId)
        {
            if (DependensiesВatabase.UsersStorage.RemoveUser(usersId)) return true;
            else return false;
        }
        public string ShowUser(int usersId)
        {
            User myUser = DependensiesВatabase.UsersStorage.GetUserById(usersId);
            if (myUser != null) return myUser.ToString();
            else return "Null";
        }
        public string ShowUsersList()
        {
            return DependensiesВatabase.UsersStorage.GetUsersList();
        }
        public bool AppendAwards(int usersId, string award)
        {
            User myUser = DependensiesВatabase.UsersStorage.GetUserById(usersId);
            if (myUser != null)
            {
                myUser.AddAward(award);
                return true;
            }
            else return false;
        }
    }
}
