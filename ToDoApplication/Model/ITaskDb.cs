using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Controller;

namespace ToDoApplication.Model
{
    public interface ITaskDb
    {
        public void SelectTask();
        public void GetShortInfo(List<TaskDb> tasks);
        public void GetLongInfo(List<TaskDb> tasks);
        public void DeleteTask(List<TaskDb> tasks, int stringCounter, ToDoAppContext db);
        public void ChangeStatus(int index, List<TaskDb> tasks, int taskIndex, User user);
        //public void PaintString(List<TaskDb> tasks, int index);
        //public List<TaskDb> UpdateDatabaseGettingNewTaskList(User user);
    }
}
