using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.ViewModels
{
    public class MemberViewModel
    {
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public double Deposit { get; set; }
        public double Debt { get; set; }

        public Guid TaskId { get; set; }
    }
}
