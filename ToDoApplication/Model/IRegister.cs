using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Controller;

namespace ToDoApplication.Model
{
    public interface IRegister
    {
        public User RegisterUser();
        public void AddNewRegisteredUser(User user);
        public User LogInto(UserController userController);
        public void ChangePassword(User user);
        public void ForgetPassword(User user);
    }
}
