using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Controller
{
    public class TaskController : ITaskDb
    {
        public TaskDb CreateTask(User user)
        {
            Console.WriteLine("Enter title: \n");
            var title = Console.ReadLine();
            //if (title == String.Empty)
            //{
            //    title = $"Task {user.Login}";
            //}
            Console.WriteLine("Enter short info: \n");
            var shortInfo = Console.ReadLine();
            Console.WriteLine("Enter full info: \n");
            var fullInfo = Console.ReadLine();
            Console.WriteLine("Add deadline(select days, hours, minutes): \n");
            Console.WriteLine("Days: ");
            var days = Console.ReadLine();
            Console.WriteLine("Hours: ");
            var hours = Console.ReadLine();
            Console.WriteLine("Minutes");
            var minutes = Console.ReadLine();

            return new TaskDb { Title = title, ShortInfo = shortInfo, FullInfo = fullInfo, AdditionTime = DateTime.Now, DeadLine = DateTime.Now, Status = Status.ToDo };
        }
        public void AddTask(TaskDb task, User user)
        {
            var newUser = user;
            using (ToDoAppContext db = new ToDoAppContext())
            {
                //db.TaskDbs.Add(task);
                newUser.Tasks.Add(task);


                db.Users.Update(newUser);
                db.SaveChanges();
                Console.WriteLine("Changes saved!");

                //UpdateDatabaseGettingNewTaskList(user);
                ShowAllUserTasks(user);
            }
        }

        public void ChangeStatus(int index, List<TaskDb> tasks, int taskIndex, User user)
        {
                var listTasks = user.Tasks.ToList();
                int enumLenght = Enum.GetNames(typeof(Status)).Length;
                if (index == -1)
                {
                    index = enumLenght;
                }
                if (index == enumLenght)
                {
                    index = 0;
                }
                Status sth = (Status)index;
                listTasks[taskIndex].Status = sth;
        }

        public void DeleteTask(List<TaskDb> tasks, int stringCounter, ToDoAppContext db)
        {
            int removeIndex = tasks[stringCounter].Id;
            db.TaskDbs.Remove(tasks.FirstOrDefault(x => x.Id == removeIndex));
        }

        public void GetLongInfo(List<TaskDb> tasks)
        {

            foreach (var item in tasks)
            {
                Console.WriteLine($"Title: {item.Title} " +
                                  $"Short info: {item.ShortInfo} " +
                                  $"Addition time: {item.AdditionTime} " +
                                  $"Full info: {item.FullInfo} " +
                                  $"Deadline: {item.DeadLine} " +
                                  $"Status: {item.Status}");
            }
        }

        public void GetShortInfo(List<TaskDb> tasks)
        {
            foreach (var item in tasks)
            {
                Console.WriteLine($"{item.Id}. {item.ShortInfo} | Status: {item.Status} | {item.DeadLine}");
            }
        }

        public void SelectTask()
        {
            throw new NotImplementedException();
        }

        public void ShowAllUserTasks(User user)
        {
            using (ToDoAppContext db = new ToDoAppContext())
            {
                var users = db.Users.ToList();
                var tasks = db.TaskDbs.ToList();

                var selectedUser = users.FirstOrDefault(i => i.Id == user.Id);
                List<TaskDb> userTasks = selectedUser.Tasks.ToList();

                //Console.WriteLine($"{user.Nickname}");

                //Console.WriteLine(userTasks.Count);
                if (tasks.Count == 0)
                    Console.WriteLine("empty nahoi");
                if (tasks == null)
                {
                    Console.WriteLine("No tasks yet!");
                    return;
                }
                foreach (var item in userTasks)
                {
                    Console.WriteLine($"Title: {item.Title} " +
                                  $"Short info: {item.ShortInfo} " +
                                  $"Addition time: {item.AdditionTime} " +
                                  $"Full info: {item.FullInfo} " +
                                  $"Deadline: {item.DeadLine} " +
                                  $"Status: {item.Status}");
                }
                //GetLongInfo(tasks);
            }
        }

    }
}
