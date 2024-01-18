using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Alerts;
using Acme.SimpleTaskSystem.Common;
using Acme.SimpleTaskSystem.Migrations;
using Acme.SimpleTaskSystem.Tasks;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Acme.SimpleTaskSystem.Users;
using Acme.SimpleTaskSystem.Users.Dtos;
using Acme.SimpleTaskSystem.Web.Models.People;
using Acme.SimpleTaskSystem.Web.Models.Tasks;
using Acme.SimpleTaskSystem.Web.Models.Users;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Acme.SimpleTaskSystem.Web.Controllers
{
    public class TasksController : SimpleTaskSystemControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;

        public TasksController(ITaskAppService taskAppService, ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;

        }


        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItems));
        }
        [HttpPost]
        public ActionResult Create1(CreateTaskInput taskInput)
        {
            if (ModelState.IsValid)
            {
                var input = new CreateTaskInput
                {
                    Title = taskInput.Title,
                    Description = taskInput.Description,
                    AssignedPersonId = taskInput.AssignedPersonId,
                    CreatorId = taskInput.CreatorId
                };
                _taskAppService.Create(input);
                return RedirectToAction("Index", "Tasks");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public ActionResult Register1(RegisterInput input)
        {
            if (ModelState.IsValid)
            {
                var newUser = new RegisterInput
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Username = input.Username,
                    Password = input.Password
                };

                _taskAppService.Register(newUser);
                
                return RedirectToAction("Login", "Tasks");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Login(LoginInput loginInput)
        {
            if (ModelState.IsValid)
            {
                var input = new LoginInput
                {
                    UserName = loginInput.UserName,
                    Password = loginInput.Password
                };

                var userRole = _taskAppService.CheckCredentials(input);
                TempData["userId"] = userRole.Id;

                switch (userRole.Role)
                {
                    case 1:
                        return RedirectToAction("Create", "Tasks");

                    case 2:
                        return RedirectToAction("Index", "Tasks");

                    case 3:
                        return RedirectToAction("Register", "Tasks");
                    default:
                        Unauthorized("Something went wrong!");
                        break;
                }

            }
                return View();

            }


        
        [HttpGet]
         public IActionResult Details( int taskId)
        {          
            var details = _taskAppService.GetTaskById(taskId);

            if (details == null)
            {
                return NotFound();
            }

            var task = new DetailsViewModel
            {
                Title = details.Title,
                Description = details.Description,
                TaskId=details.TaskId
            };

            return View("Details",task);
        }

        [HttpGet] 
        public IActionResult Edit(int taskId)
        {
            if (taskId == 0)
            {
                return NotFound();
            }
            var taskDetails = _taskAppService.GetTaskById(taskId);
            var task = new EditTaskViewModel
            {
                Title = taskDetails.Title,
                Description = taskDetails.Description,
                TaskId = taskDetails.TaskId
            };
            return View("EditTask", task);
        }
        [HttpPost]
        public ActionResult Edit(int taskId, EditTaskInputDto model)
        {
            Console.Write($"task id{taskId} model task id{model.TaskId}");
            
            var task= _taskAppService.EditTask(taskId,model);
            if (task == null)
            {
                return NotFound();
            }
            var details = new DetailsViewModel
            {
                Title = task.Title,
                Description = task.Description
            };
            
            return View("Details", details);


        }
    }
}
