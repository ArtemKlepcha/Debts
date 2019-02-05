using Debts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models.Mappings
{
    public static class MemberMappings
    {
        public static MemberViewModel Map(this Member member)
        {
            return new MemberViewModel
            {
                MemberId = member.Id,
                Name = member.Name,
                Deposit = member.Deposit,
                Debt = member.Debt,
                TaskId = member.TaskId
            };
        }

        public static Member Map(this MemberViewModel memberViewModel)
        {
            return new Member
            {
                Id = memberViewModel.MemberId,
                Name = memberViewModel.Name,
                Deposit = memberViewModel.Deposit,
                Debt = memberViewModel.Debt,
                TaskId = memberViewModel.TaskId
            };
        }
    }
    
}
