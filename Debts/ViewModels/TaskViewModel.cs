using Debts.Models;
using Debts.ViewModels.ValidationAttribute;
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

        [Range(0, maxValue, ErrorMessage = "Min value is 0.")]
        [DepositSumCheck]
        [DebtSumCheck]
        public double Sum { get; set; }

        public Dictionary<string, MemberViewModel> Members { get; set; } = new Dictionary<string, MemberViewModel>();

        public double DepositsMember
        {
            get
            {
                double sum = 0;
                foreach (var item in Members)
                {
                    sum += item.Value.Deposit;
                }
                return sum;
            }

        }
        public double DebtsMember
        {
            get
            {
                double sum = 0;
                foreach (var item in Members)
                {
                    sum += item.Value.Debt;
                }
                return sum;
            }

        }

        public List<DebtElementViewModel> Debts { get; set; } = new List<DebtElementViewModel>();
    }

    public class EditTaskMemberViewModel
    {
        public string Key { get; set; }
        public Dictionary<string, MemberViewModel> Members { get; set; }

        public EditTaskMemberViewModel(Dictionary<string, MemberViewModel> members, string index)
        {
            
            if (members == null)
            {
                Members = new Dictionary<string, MemberViewModel>(){
                    { index , new MemberViewModel() }
                };
            }
            else
            {
                Members = members;
            }
            Key = index;
        }
    }
}
