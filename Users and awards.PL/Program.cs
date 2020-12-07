using System;
using Users.Common;

namespace Users_and_awards.PL
{
    class Program
    {
        static void Main(string[] args)
        {
           
            SelectOptionByUser();
            //Console.ReadLine();
        }

        private static void SelectOptionByUser()
        {
            while (true)
            {
                Console.WriteLine("Please, select some action");
                Console.WriteLine("1: Add User");
                Console.WriteLine("2: Delete User");
                Console.WriteLine("3: Show User's info");
                Console.WriteLine("4: Show User's list");
                Console.WriteLine("5: Add awards");
                Console.WriteLine("6: Exit");

                var input = Console.ReadLine();

                if (uint.TryParse(input, out uint selectedOptions)
                    && selectedOptions > 0
                    && selectedOptions < 7)
                {
                    int usersId = -1;
                    switch (selectedOptions)
                    {
                        case 1:
                            Console.WriteLine("Enter user's Name. Name must not contain spaces");
                            string usersName = Console.ReadLine();
                            Console.WriteLine("Enter user's date of birth in the format YYYY,MM,DD");
                            DateTime dateOfBirth = new DateTime(1995, 01, 01);
                            DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                            DependensiesLogic.UsersBLL.CreateNewUser(usersName, dateOfBirth);
                            break;
                        case 2:
                            Console.WriteLine("Enter user's id. if you do not remember id, you can look at the list.");
                            int.TryParse(Console.ReadLine(), out usersId);
                            if (DependensiesLogic.UsersBLL.DeleteUser(usersId)) Console.WriteLine("True");
                            else Console.WriteLine("False");
                            break;
                        case 3:
                            Console.WriteLine("Enter user's id. if you do not remember id, you can look at the list");
                            int.TryParse(Console.ReadLine(), out usersId);
                            Console.WriteLine(DependensiesLogic.UsersBLL.ShowUser(usersId));
                            break;
                        case 4:
                            Console.WriteLine(DependensiesLogic.UsersBLL.ShowUsersList());
                            break;
                        case 5:
                            Console.WriteLine("Enter user's id. if you do not remember id, you can look at the list");
                            int.TryParse(Console.ReadLine(), out usersId);
                            Console.WriteLine("Enter user's award");
                            string usersaward = Console.ReadLine();
                            if (DependensiesLogic.UsersBLL.AppendAwards(usersId, usersaward)) Console.WriteLine("True");
                            else Console.WriteLine("False");
                            break;
                        case 6:
                            return;
                    }
                }
            }
        }
    }
}
