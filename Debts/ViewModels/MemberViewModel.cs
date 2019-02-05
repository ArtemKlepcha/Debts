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
        public const double maxValue = Double.MaxValue;
        public Guid MemberId { get; set; }

        [Required(ErrorMessage = "Field \"Name\" can't be empty")]
        public string Name { get; set; }

        [Range( 0, maxValue, ErrorMessage = "Min value is 0.")]
        public double Deposit { get; set; }

        [Range(0, maxValue, ErrorMessage = "Min value is 0.")]
        public double Debt { get; set; }

        public Guid TaskId { get; set; }
    }
}
