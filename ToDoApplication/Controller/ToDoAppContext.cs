using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Controller
{
    public class ToDoAppContext : DbContext
    {
        public DbSet<TaskDb> TaskDbs { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ToDoAppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ToDoDb;Trusted_Connection=True;");
        }
    }
}
