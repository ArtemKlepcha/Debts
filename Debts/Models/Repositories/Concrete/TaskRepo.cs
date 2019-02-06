using Debts.Data;
using Debts.Models.Mappings;
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
        private IEnumerable<Task> Tasks => ctx.Tasks.Include(m => m.Members).Include(d => d.Debts).ToList();

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
                Id = taskViewModel.TaskId,
                Name = taskViewModel.Name,
                Sum = taskViewModel.Sum,
                UserId = taskViewModel.UserId,
                Members = taskViewModel.Members.Values.Select(e=>e.Map()).ToList()
            };

            var listMembersIdForDel = ctx.Members.Where(t => t.TaskId == task.Id).Except(taskViewModel.Members.Values.Select(e => e.Map())).ToList();

            foreach (var item in listMembersIdForDel)
            {
                ctx.Members.Remove(item);
            }


            if (task.Id == Guid.Empty)
            {
                ctx.Tasks.Add(task);
            }
            else
            {
                ctx.Tasks.Update(task);
            }
            
            ctx.SaveChanges();
        }

        public TaskViewModel GetValue(Guid taskId)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            TaskViewModel taskViewModel = new TaskViewModel
            {
                Name = task.Name,
                Sum = task.Sum,
                TaskId = task.Id,
                //task.Members.Select(memb => new MemberViewModel
                //{
                //    MemberId = memb.Id,
                //    TaskId = memb.TaskId,
                //    Name = memb.Name,
                //    Deposit = memb.Deposit,
                //    Debt = memb.Debt

                //}).ToList(),
                UserId = task.UserId
            };
            taskViewModel.Members = task.Members.ToDictionary(n => n.Id.ToString(), n => n.Map());

            return taskViewModel;
        }


    }
}
