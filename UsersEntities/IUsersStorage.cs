namespace UsersEntities
{
    public interface IUsersStorage
    {
        void AddUser(User newUser);
        bool RemoveUser(int usersId);
        int GetId();
        User GetUserById(int usersId);
        string GetUsersList();
    }
}
