using Users_and_awards.BLL;
using UsersEntities;

namespace Users.Common
{
    public class DependensiesLogic
    {
        public static IUsersBLL UsersBLL { get; } = new UsersManager();
    }
}
