using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Models.Repositories.Abstract;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Debts.Controllers
{
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
        public IActionResult AddTask(Guid? id)
        {
            TaskViewModel taskViewModel = new TaskViewModel
            {
                UserId = UserId,
                Members = new List<MemberViewModel>()
            };

            if (id.HasValue)
            {
              taskViewModel =  _taskRepo.GetValue(id.Value);
            }
            return View(taskViewModel);
        }

        [HttpPost]
        public IActionResult AddTask(TaskViewModel taskViewModel)
        {
            _taskRepo.Save(taskViewModel);

            return RedirectToAction("Index");
        }

    }
}