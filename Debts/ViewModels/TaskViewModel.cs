using Debts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Debts.ViewModels
{
    public class TaskListViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
    }

    public class TaskViewModel
    {
        public const double maxValue = Double.MaxValue;

        public Guid TaskId { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Field \"Name\" can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field \"Sum\" can't be empty")]
        [Range(0, maxValue, ErrorMessage = "Min value is 0.")]
        public double Sum { get; set; }

        public Dictionary<string, MemberViewModel> Members { get; set; } = new Dictionary<string, MemberViewModel>();
    }

    public class EditTaskMemberViewModel
    {
        public string Key { get; set; }
        public Dictionary<string, MemberViewModel> Members { get; set; }

        public EditTaskMemberViewModel(Dictionary<string, MemberViewModel> members, string index)
        {
            Members = members;
            Key = index;
        }
    }
}
