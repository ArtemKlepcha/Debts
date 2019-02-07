using Debts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Mappings
{
    public static class DebtMapping
    {
        public static DebtElementViewModel Map(this Debt debt)
        {
            return new DebtElementViewModel
            {
                DebtId = debt.Id,
                Member1 = debt.Member1,
                Member2 = debt.Member2,
                Money = debt.Money,
                TaskId = debt.TaskId
            };
        }

        public static Debt Map(this DebtElementViewModel debtElementViewModel)
        {
            return new Debt
            {
                
                Id = debtElementViewModel.DebtId,
                Member1 = debtElementViewModel.Member1,
                Member2 = debtElementViewModel.Member2,
                Money = debtElementViewModel.Money,
                TaskId = debtElementViewModel.TaskId
            };
        }
    }
}
