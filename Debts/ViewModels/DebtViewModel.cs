﻿using Debts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.ViewModels
{
    public class DebtViewModel
    {
        public IEnumerable<Debt> Debts { get; set; }
    }
}
