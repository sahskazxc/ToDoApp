using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = null!;
        public int Age { get; set; }
        public Sex Sex { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public string SpecialQuestion { get; set; }
        public string SpecialAnswer { get; set; }
        private List<TaskDb> _tasks = new List<TaskDb>();
        public List<TaskDb> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        //public List<TaskDb> Tasks = new List<TaskDb>();

        public User() { }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
