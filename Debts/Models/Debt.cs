using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models
{
    public class Debt : CommonModel
    {
        public string Member1 { get; set; }
        public string Member2 { get; set; }
        public double Money { get; set; }

        [ForeignKey("Task")]
        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
