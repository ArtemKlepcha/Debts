using Debts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Repositories.Abstract
{
    public interface ITaskRepo
    {
        //IEnumerable<Task> Tasks { get; }

        TaskListViewModel GetAll(string userId);
        TaskViewModel GetValue(int? taskId, string UserId);
        void Save(TaskViewModel taskViewModel);
        void DeleteTask(Guid taskId);
    }
}
