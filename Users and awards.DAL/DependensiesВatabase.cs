using Users_and_awards.DAL;
using UsersEntities;

namespace Users.Common
{
    public static class DependensiesВatabase
    {
        public static IUsersStorage UsersStorage { get; } = new UsersData();
    }

}
