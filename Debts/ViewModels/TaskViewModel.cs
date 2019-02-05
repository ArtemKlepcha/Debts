using Debts.Models;
using System;
using System.Collections.Generic;

namespace Debts.ViewModels
{
    public class TaskListViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
    }

    public class TaskViewModel
    {
        public Guid TaskId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
    }
}
