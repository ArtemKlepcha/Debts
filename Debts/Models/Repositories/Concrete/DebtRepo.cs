using Debts.Data;
using Debts.Models.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Repositories.Concrete
{
    public class DebtRepo : IDebtRepo
    {
        private readonly ApplicationDbContext ctx;
        public DebtRepo(ApplicationDbContext applicationDbContext)
        {
            ctx = applicationDbContext;
        }
        public IEnumerable<Debt> Debts => ctx.Debts.Include(t => t.Task).ToList();
    }
}
