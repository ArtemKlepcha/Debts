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

            _taskRepo.Save(taskViewModel);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public JsonResult CheckValue(double value)
        {
            var result = !(value > 0);
            return Json(result);
        }

    }
}