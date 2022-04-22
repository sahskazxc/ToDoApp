using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Controller
{
    public class UserController : IRegister
    {

        private List<string> _question = new List<string>() { "Enter your's first pet name", 
                                                              "Enter your favourite car brand",
                                                              "Enter your favourite flower",
                                                              "Enter your favourite drink",
                                                              "Enter your favourite meal"};
        Random rnd = new Random();
        public void EditProfile(User user, UserController userController)
        {
            Console.Clear();
            Console.WriteLine("\nChange 1. password: \n" + 
                              "\t 2. login: \n" +
                              "\t 3. nickname: \n" + 
                              "\t 4. sex: \n" +
                              "\t 5. age \n");
            var userDecision = Console.ReadKey();
            switch (userDecision.Key)
            {
                case ConsoleKey.D1:
                    userController.ChangePassword(user);
                    break;
                case ConsoleKey.D2:
                    userController.ChangeLogin(user);
                    break;
                case ConsoleKey.D3:
                    userController.ChangeNickName(user);
                    break;
                case ConsoleKey.D4:
                    userController.ChangeSex(user);
                    break;
                case ConsoleKey.D5:
                    userController.ChangeAge(user);
                    break;
                default:
                    break;
            }
        }

        public void ChangePassword(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                bool confirm = false;
                Console.WriteLine("\nEnter previous password: ");
                var previousPassword = Console.ReadLine();
                if (previousPassword == user.Password)
                {
                    Console.WriteLine("Good! \nEnter new password: ");
                    var newPassword = Console.ReadLine();
                    if (newPassword == user.Password)
                    {
                        Console.WriteLine("Warning: You entered the same password!");
                        Console.WriteLine("Press Enter to confirm or Esc to reject");
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                                confirm = true;
                                break;
                            case ConsoleKey.Escape:
                                confirm = false;
                                break;
                            default:
                                break;
                        }
                        if (confirm == false)
                        {
                            Console.WriteLine("Ending change session...");
                            return;
                        }

                    }

                    newUser.Password = newPassword;
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);
                }
            }
        }
        public void ChangeLogin(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                bool confirm = false;
                Console.WriteLine("\nEnter previous login: ");
                var previousLogin = Console.ReadLine();
                if (previousLogin == user.Login)
                {
                    Console.WriteLine("Good! \nEnter new login: ");
                    var newLogin = Console.ReadLine();
                    if (newLogin == user.Login)
                    {
                        Console.WriteLine("Warning: You entered the same login!");
                        Console.WriteLine("Press Enter to confirm or Esc to reject");
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                                confirm = true;
                                break;
                            case ConsoleKey.Escape:
                                confirm = false;
                                break;
                            default:
                                break;
                        }
                        if (confirm == false)
                        {
                            Console.WriteLine("Ending change session...");
                            return;
                        }

                    }

                    newUser.Login = newLogin;
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);
                }
            }
        }

        public void ChangeNickName(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                bool confirm = false;
                Console.WriteLine("\nEnter previous nickname: ");
                var previousNickname = Console.ReadLine();
                if (previousNickname == user.Nickname)
                {
                    Console.WriteLine("Good! \nEnter new nickname: ");
                    var newNickname = Console.ReadLine();
                    if (newNickname == user.Nickname)
                    {
                        Console.WriteLine("Warning: You entered the same nickname!");
                        Console.WriteLine("Press Enter to confirm or Esc to reject");
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                                confirm = true;
                                break;
                            case ConsoleKey.Escape:
                                confirm = false;
                                break;
                            default:
                                break;
                        }
                        if (confirm == false)
                        {
                            Console.WriteLine("Ending change session...");
                            return;
                        }
                    }

                    newUser.Nickname = newNickname;
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);
                }
            }
        }
        public void ChangeSex(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                string newSex;
                
                bool confirm = false;
                Console.WriteLine("\nSelect previous sex: ");
                Console.WriteLine("1. Male\n 2. Female\n"); 
                var previousSex = Console.ReadLine();

                Console.WriteLine($"Entered string: {previousSex} \n User string: {user.Sex.ToString()}");
                switch (previousSex)
                {
                    case "1":
                        previousSex = "Male";
                        break;
                    case "2":
                        previousSex = "Female";
                        break;
                    default:
                        break;
                }
                if (previousSex == user.Sex.ToString())
                {

                    Console.WriteLine("Good! \nSelect new sex: \n 1. Male\n2. Female\n");
                    newSex = Console.ReadLine();
                    switch (newSex)
                    {
                        case "1":
                            newSex = "Male";
                            break;
                        case "2":
                            newSex = "Female";
                            break;
                        default:
                            break;
                    }
                    if (newSex == user.Sex.ToString())
                    {
                        Console.WriteLine("Warning: You entered the same sex!");
                        Console.WriteLine("Press Enter to confirm or Esc to reject");
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                                confirm = true;
                                break;
                            case ConsoleKey.Escape:
                                confirm = false;
                                break;
                            default:
                                break;
                        }
                        if (confirm == false)
                        {
                            Console.WriteLine("Ending change session...");
                            return;
                        }
                    }
                    newUser.Sex = (Sex)Enum.Parse(typeof(Sex), newSex);
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);


                }
            }
        }

        public void ChangeAge(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                bool confirm = false;
                Console.WriteLine("\nEnter previous age: ");
                var previousAge = int.Parse(Console.ReadLine());
                if (previousAge == user.Age)
                {
                    Console.WriteLine("Good! \nEnter new age: ");
                    var newAge = int.Parse(Console.ReadLine());
                    if (newAge == user.Age)
                    {
                        Console.WriteLine("Warning: You entered the same age!");
                        Console.WriteLine("Press Enter to confirm or Esc to reject");
                        var key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Enter:
                                confirm = true;
                                break;
                            case ConsoleKey.Escape:
                                confirm = false;
                                break;
                            default:
                                break;
                        }
                        if (confirm == false)
                        {
                            Console.WriteLine("Ending change session...");
                            return;
                        }
                    }

                    newUser.Age = newAge;
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);
                }
            }
        }


        public void ForgetPassword(User user)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var newUser = user;
                Console.WriteLine($"Entet answer on your special question: \n{user.SpecialQuestion}: \n");
                var answer = Console.ReadLine();
                if (answer == user.SpecialAnswer)
                {
                    Console.WriteLine("Enter new password: ");
                    var newPassword = Console.ReadLine();
                    newUser.Password = newPassword;
                    db.Users.Update(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Changes saved!");
                    GoToProfile(user);
;                }
                else
                {
                    Console.WriteLine("Sorry, incorrect answer!");
                }
            }

        }
        public void GoToProfile(User user)
        {
            Console.Clear();
            Console.WriteLine($"Hi, {user.Nickname}\n" + 
                              $"It's your profile!");
            Console.WriteLine($"Your login: {user.Login}\n" + 
                              $"\t age: {user.Age}\n" + 
                              $"\t sex: {user.Sex}\n");
        }

        public User RegisterUser()
        {
            Console.Clear();
            List<string> userLogins = new List<string>();
            List<string> userNickNames = new List<string>();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var users = db.Users.ToList();
                foreach (var item in users)
                {
                    userLogins.Add(item.Login);
                }
                foreach (var item in users)
                {
                    userNickNames.Add(item.Nickname);
                }
            }
            try
            {

                Console.WriteLine("Hello, user");
                Console.WriteLine("Enter login: ");
                string login = Console.ReadLine();

                foreach (var item in userLogins)
                {
                    if (item == login)
                    {
                        Console.WriteLine("User with same login exists!");
                        System.Threading.Thread.Sleep(1000);
                        User addedUser = RegisterUser();
                        return addedUser;
                    }
                }
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                Console.WriteLine("Enter nickname: ");
                string nickname = Console.ReadLine();
                foreach (var item in userNickNames)
                {
                    if (item == nickname)
                    {
                        Console.WriteLine("User with same nickname exists!");
                        System.Threading.Thread.Sleep(1000);
                        User addedUser = RegisterUser();
                        return addedUser;
                    }
                }
                Console.WriteLine("Enter age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Select sex: 1 - male, 2 - famale");
                int sex = int.Parse(Console.ReadLine());
                while (sex != 1 && sex != 2)
                {
                    Console.WriteLine("Enter 1 or 2!");
                    sex = int.Parse(Console.ReadLine());
                }

                // get special question for user
                var question = _question[rnd.Next(0, _question.Count)];
                Console.WriteLine($"Special question: \n {question}\nEnter answer: ");
                var answer = Console.ReadLine();

                var user = new User { Login = login, Password = password, Age = age, Nickname = nickname, Sex = (Sex)sex, SpecialQuestion = question, SpecialAnswer = answer };
                return user;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void AddNewRegisteredUser(User user)
        {
            using (ToDoAppContext db = new ToDoAppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("User added!");
                //Console.WriteLine($"Hello, {user.Nickname}");
            }
        }


        public User LogInto(UserController userController)
        {
            Console.Clear();
            using (ToDoAppContext db = new ToDoAppContext())
            {
                Console.WriteLine("Enter login: ");
                string userLogin = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string userPassword = Console.ReadLine();

                

                var user = db.Users.FirstOrDefault(i => (i.Login == userLogin) && (i.Password == userPassword));

                if (user == null)
                {
                    Console.WriteLine("Incorrect login or password! Forget password?");
                    var restoredUser = db.Users.FirstOrDefault(i => i.Login == userLogin);
                    userController.ForgetPassword(restoredUser);
                    return restoredUser;
                }
                else 
                {
                    return user;
                }
            }
            Console.WriteLine();
        }
    }
}
