using Debts.Data;
using Debts.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Repositories.Concrete
{
    public class MemberRepo:IMemberRepo
    {
        private readonly ApplicationDbContext ctx;
        public MemberRepo(ApplicationDbContext applicationDbContext)
        {
            ctx = applicationDbContext;
        }
        public IEnumerable<Member> Members => ctx.Members.ToList();

    }
}
