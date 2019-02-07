using Debts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.ViewModels
{
    public class DebtViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Debt> Debts { get; set; }
    }

    public class DebtElementViewModel
    {
        public Guid DebtId { get; set; }

        public string Member1 { get; set; }
        public string Member2 { get; set; }
        public double Money { get; set; }

        public Guid TaskId { get; set; }
    }

    public class DebtListViewModel
    {
         public List<DebtElementViewModel> debtElementViewModels { get; set; } = new List<DebtElementViewModel>();
    }
}
