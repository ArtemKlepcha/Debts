using System.Collections.Generic;

namespace Debts.Models
{
    public class Task:CommonModel
    {
        public string Name { get; set; }
        public double Sum { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
