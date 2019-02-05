using Debts.Data;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Debts.Models.Repositories.Concrete
{
    public class TaskRepo: ITaskRepo
    {
        private readonly ApplicationDbContext ctx;
        private IEnumerable<Task> Tasks => ctx.Tasks;

        public TaskRepo(ApplicationDbContext applicationDbContext)
        {
            ctx = applicationDbContext;
        }


        public TaskListViewModel GetAll(string userId)
        {
            return new TaskListViewModel { Tasks = Tasks.Where(s => s.UserId == userId).ToList() };
        }

        public void Save(TaskViewModel taskViewModel)
        {
            Task task = new Task
            {
                Name = taskViewModel.Name,
                Sum = taskViewModel.Sum,
                UserId = taskViewModel.UserId
            };
            ctx.Tasks.Add(task);
            ctx.SaveChanges();
        }
    }
}
