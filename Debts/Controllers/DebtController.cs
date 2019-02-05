using System;
using System.Collections.Generic;
using System.Linq;
using Debts.Models;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Debts.Controllers
{
    public class DebtController : BaseController
    {
        private readonly ITaskRepo _taskRepo;

        public DebtController(ITaskRepo taskRepository)
        {
            _taskRepo = taskRepository;
        }
        public IActionResult Index(int id)
        {
            Task taskList = _taskRepo.GetAll(UserId).Tasks.ElementAt(0);

            Guid idG = Guid.Empty;

            //var memId = int.Parse(HttpContext.Request.Query["member"].ToString());
            
            ViewBag.id = id;

            //Member member = taskList.Members.ElementAt(id);

            string MemberName = taskList.Members.ElementAt(id).Name;
            ViewBag.Name = MemberName;

            TaskListViewModel task = new TaskListViewModel
            {
                Tasks = new List<Task>
                {
                    new Task
                    {
                        Name = "name1",
                        Sum = 500,
                        Debts = new List<Debt>
                        {
                           new Debt
                           {
                               Member1 = "mem1",
                               Member2 = "mem2",
                               Money = 200
                           },
                           new Debt
                           {
                               Member1 = "mem1",
                               Member2 = "mem4",
                               Money = 150
                           },
                           new Debt
                           {
                               Member1 = "mem3",
                               Member2 = "mem1",
                               Money = 100
                           },
                           new Debt
                           {
                               Member1 = "mem3",
                               Member2 = "mem2",
                               Money = 100
                           }
                        }
                    }
                }
            };

            DebtViewModel member = new DebtViewModel
            {
                Debts = taskList.Debts.Where(d => d.Member1 == MemberName || d.Member2 == MemberName)
            };

    
            return View(member);
        }
    }
}