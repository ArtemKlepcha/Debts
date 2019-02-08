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

        public void DeleteTask(Guid taskId)
        {
            var task = ctx.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
            if (task != null)
            {
                ctx.Tasks.Remove(task);
                ctx.SaveChanges();
            }
        }

        public void Save(TaskViewModel taskViewModel)
        {
            Task task = new Task
            {
                Id = taskViewModel.TaskId,
                Name = taskViewModel.Name,
                Sum = taskViewModel.Sum,
                UserId = taskViewModel.UserId,
                Members = taskViewModel.Members.Values.Select(e=>e.Map()).ToList(),
                Debts = taskViewModel.Debts.Select(e=>e.Map()).ToList()      
            };

            var listMembersIdForDel = ctx.Members.Where(t => t.TaskId == task.Id).Except(taskViewModel.Members.Values.Select(e => e.Map())).ToList();
            var listDebtsIdForDel = ctx.Debts.Where(t => t.TaskId == task.Id).Except(taskViewModel.Debts.Select(d => d.Map()));

            foreach (var item in listMembersIdForDel)
            {
                ctx.Members.Remove(item);
            }

            foreach(var item in listDebtsIdForDel)
            {
                ctx.Debts.Remove(item);
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

        public TaskViewModel GetValue(int? taskId, string UserId)
        {
            var task = GetAll(UserId).Tasks.ElementAt(taskId ?? 0);
            TaskViewModel taskViewModel = new TaskViewModel
            {
                Name = task.Name,
                Sum = task.Sum,
                TaskId = task.Id,
                UserId = task.UserId
            };
            taskViewModel.Members = task.Members.ToDictionary(n => n.Id.ToString(), n => n.Map());

            return taskViewModel;
        }


    }
}
