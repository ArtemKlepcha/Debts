using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Debts.Models;

namespace Debts.Controllers
{
    [Authorize]
    public class TasksController : BaseController
    {
        private readonly ITaskRepo _taskRepo;

        public TasksController(ITaskRepo taskRepository)
        {
            _taskRepo = taskRepository;
        }

        public IActionResult Index()
        {
            TaskListViewModel taskList = _taskRepo.GetAll(UserId);

            return View(taskList);
        }
        
        [HttpGet]
        public IActionResult AddOrEditTask(int? id)
        {
            TaskViewModel taskViewModel = new TaskViewModel
            {
                UserId = UserId,
                Members = new Dictionary<string, MemberViewModel>()
            };

            if (id != null)
            {
              taskViewModel =  _taskRepo.GetValue(id - 1, UserId);
            }

            return View(taskViewModel);
        }

        [HttpPost]
        public IActionResult AddOrEditTask(TaskViewModel taskViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    _taskRepo.Save(taskViewModel);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View(taskViewModel);
            //}

            CalculateDebts(ref taskViewModel);
            _taskRepo.Save(taskViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult CheckValue(double value)
        {
            var result = !(value > 0);
            return Json(result);
        }

        public void CalculateDebts(ref TaskViewModel taskViewModel)
        {
            List<MemberViewModel> memberList = taskViewModel.Members.Values.ToList();

            //calculate balance for each
            //Dictionary<string, double> balance = new Dictionary<string, double>();

            Dictionary<string, double> creditors = new Dictionary<string, double>();
            Dictionary<string, double> debtors = new Dictionary<string, double>();
            foreach (var member in memberList)
            {
                double balance = member.Debt - member.Deposit;
                if (balance > 0)
                {
                    debtors.Add(member.Name, balance);
                }
                if (balance < 0)
                {
                    creditors.Add(member.Name, balance);
                }
            }

            List<DebtElementViewModel> debtsTable = new List<DebtElementViewModel>();

            var credCount = creditors.Count;
            
            for(int credIter = 0;credIter< credCount; credIter++)
            {
                double debt;
                var creditor = creditors.ElementAt(credIter);

                var debtorIter = 0;
                while (debtors.Count != 0)
                {
                    var debtor = debtors.ElementAt(debtorIter);
                    debt = Math.Min(Math.Abs(creditor.Value), debtor.Value);
                    debtors[debtor.Key] -= debt;
                    creditors[creditor.Key] += debt;

                     debtsTable.Add(new DebtElementViewModel
                    {
                        Member1 = creditor.Key,
                        Member2 = debtor.Key,
                        Money = debt,
                        TaskId = taskViewModel.TaskId
                    });

                    if (creditors[creditor.Key] == 0)
                    {
                        DeleteDebtors(ref debtors);
                        debtorIter = 0;
                        break;
                    }
                    debtorIter++;
                }
            }

            taskViewModel.Debts = debtsTable;
        }

        private void  DeleteDebtors(ref Dictionary<string, double> debtors)
        {
            for(int debtIter = 0; debtIter < debtors.Count; debtIter++)
            {
                var debtor = debtors.ElementAt(debtIter);
                if (debtor.Value == 0)
                    debtors.Remove(debtor.Key);
                debtIter--;
            }
        }

    }
}