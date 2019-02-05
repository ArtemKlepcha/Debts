using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.ViewModels
{
    public class MemberViewModel
    {
        public Guid MemberId { get; set; }

        [Required(ErrorMessage = "Field \"Name\" can't be empty")]
        public string Name { get; set; }

        [Remote("CheckValue", "Tasks", ErrorMessage = "Min value 0.")]
        public double Deposit { get; set; }
        public double Debt { get; set; }

        public Guid TaskId { get; set; }
    }
}
