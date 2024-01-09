using Abp.Application.Services.Dto;
using Acme.SimpleTaskSystem.Common;
using Acme.SimpleTaskSystem.Tasks;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Acme.SimpleTaskSystem.Web.Models.People;
using Acme.SimpleTaskSystem.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
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
                    AssignedPersonId = taskInput.AssignedPersonId

                };
                _taskAppService.Create(input);
                return RedirectToAction("Index", "Tasks");
            }
            return View();
        }
    }
}
