using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Acme.SimpleTaskSystem.Users;
using Acme.SimpleTaskSystem.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        System.Threading.Tasks.Task Create(CreateTaskInput input);
        LoggedInUserDto CheckCredentials(LoginInput loginInput);
        System.Threading.Tasks.Task Register(RegisterInput input);
        // Task TaskDetails(int taskId);
        TaskDetailsDto GetTaskById(int taskId);
        Task EditTask(int taskId, EditTaskInputDto input);
    }
}
