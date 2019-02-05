using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Debts.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITaskRepo _taskRepo;

        public TasksController(ITaskRepo taskRepository)
        {
            _taskRepo = taskRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            TaskListViewModel taskList = _taskRepo.GetAll(UserId);

            return View(taskList);
        }
        
        [HttpGet]
        public IActionResult AddOrEditTask(Guid? id)
        {
            TaskViewModel taskViewModel = new TaskViewModel
            {
                UserId = UserId,
                Members = new Dictionary<string, MemberViewModel>()
            };

            if (id.HasValue)
            {
              taskViewModel =  _taskRepo.GetValue(id.Value);
            }
            return View(taskViewModel);
        }

        [HttpPost]
        public IActionResult AddOrEditTask(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.Save(taskViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(taskViewModel);
            }

            
        }

        [HttpGet]
        public JsonResult CheckValue(double value)
        {
            var result = !(value > 0);
            return Json(result);
        }

    }
}