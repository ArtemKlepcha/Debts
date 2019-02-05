using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Repositories.Abstract
{
    public class IDebtRepo
    {
        IEnumerable<Debt> Debts { get; }
    }
}
