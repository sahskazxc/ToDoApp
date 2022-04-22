using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    public class TaskDb
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ShortInfo { get; set; } = null!;
        public string FullInfo { get; set; } = null!;
        public Status Status { get; set; }
        public DateTime AdditionTime { get; set; }
        public DateTime DeadLine { get; set; }
        public TaskDb() { }
        //List<TaskDb> TaskDbs = new List<TaskDb>();

    }
}
