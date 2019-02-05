using Debts.Data;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debts.Models.Repositories.Concrete
{
    public class TaskRepo: ITaskRepo
    {
        private readonly ApplicationDbContext ctx;
        private IEnumerable<Task> Tasks => ctx.Tasks.Include(m => m.Members).ToList();

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

        public TaskViewModel GetValue(Guid taskId)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            return new TaskViewModel
            {
                Name = task.Name,
                Sum = task.Sum,
                TaskId = task.Id,
                Members = task.Members.Select(memb => new MemberViewModel
                {
                    MemberId = memb.Id,
                    TaskId = memb.TaskId,
                    Name = memb.Name,
                    Deposit = memb.Deposit,
                    Debt = memb.Debt

                }).ToList(),
                UserId = task.UserId
            };
        }
    }
}
