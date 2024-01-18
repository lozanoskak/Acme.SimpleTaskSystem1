using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Acme.SimpleTaskSystem.Users.Dtos;
using JetBrains.Annotations;
using Acme.SimpleTaskSystem.Users;
using System.Configuration;
using System.Diagnostics;
using Abp.Events.Bus;
using Acme.SimpleTaskSystem.Events;
using Acme.SimpleTaskSystem.Hubs;



namespace Acme.SimpleTaskSystem.Tasks
{
    public class TaskAppService:SimpleTaskSystemAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<User> _userRepository;
        //private readonly IHubContext<TaskSystemHub> _hubContext;
        public IEventBus _eventBus { get; set; }
        public TaskAppService(IRepository<Task> taskRepository, IRepository<User> userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _eventBus = NullEventBus.Instance;
            //_hubContext = hubConext;
        }
        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t=>t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks));
        }

      
        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
           
            await _taskRepository.InsertAsync(task);
        }
        public LoggedInUserDto CheckCredentials(LoginInput loginInput)
        {
         
            var userExists = _userRepository.FirstOrDefault(u => u.Username == loginInput.UserName);
            int action;
            
            if (userExists != null)
            {
                action = userExists.Password == loginInput.Password ? 1 : 2;
      
            } 
            else
            {
                action = 3;
                return new LoggedInUserDto()
                {
                    Id = null,
                    Role = action
                };
            }
    
            return new LoggedInUserDto()
            {
                Id = userExists.Id,
                Role = action
            };
            
        }

        public async System.Threading.Tasks.Task Register(RegisterInput input)
        {
            var newUser = ObjectMapper.Map<User>(input);
            await _userRepository.InsertAsync(newUser);
        }
        public TaskDetailsDto GetTaskById(int taskId)
        {
            
     
            var taskDetails = _taskRepository.FirstOrDefault(t => t.Id == taskId);
            if (taskDetails != null)
            {
                var details = new TaskDetailsDto
                {
                    Title = taskDetails.Title,
                    Description = taskDetails.Description,
                    TaskId=taskDetails.Id
                };

               
                return details;
            }

            return null;
        }
        public  Task EditTask(int taskId, EditTaskInputDto input)
        {
            var task = _taskRepository.FirstOrDefault(t => t.Id == taskId);
            Console.WriteLine($"In service {taskId}");
            if (task == null)
            {
                throw new Exception("Not found");
            }

            task.Description = input.Description;
            task.Title = input.Title;
            task.LastUpdatedTime = input.Modified;

            Console.WriteLine(task.Description);

             _taskRepository.Update(task);
            Console.WriteLine("Trigger event");

            _eventBus.Trigger(new TaskModifiedEventData(task));
            
            return task;
            
        }
        
    }
}
