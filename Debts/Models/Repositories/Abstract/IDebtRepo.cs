using Debts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Repositories.Abstract
{
    public interface IDebtRepo
    {
        IEnumerable<Debt> Debts { get; }
    }
}
