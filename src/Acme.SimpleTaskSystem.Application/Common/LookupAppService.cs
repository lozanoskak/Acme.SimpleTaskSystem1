using Acme.SimpleTaskSystem.People;
using System;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Acme.SimpleTaskSystem.Common
{
    public class LookupAppService: SimpleTaskSystemAppServiceBase,ILookupAppService
    {
        private readonly IRepository<Person, Guid> _personReposiory;
        public LookupAppService(IRepository<Person,Guid> personRepository)
        {
            _personReposiory = personRepository;
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetPeopleComboboxItems()
        {
            var people = await _personReposiory.GetAllListAsync();
            return new ListResultDto<ComboboxItemDto>(
                people.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.Name)).ToList());
        }
    }
}
