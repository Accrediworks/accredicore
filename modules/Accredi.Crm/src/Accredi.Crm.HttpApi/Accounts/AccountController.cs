using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.Accounts;

namespace Accredi.Crm.Accounts
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("Account")]
    [Route("api/crm/accounts")]
    public class AccountController : AbpController, IAccountsAppService
    {
        protected IAccountsAppService _accountsAppService;

        public AccountController(IAccountsAppService accountsAppService)
        {
            _accountsAppService = accountsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AccountDto>> GetListAsync(GetAccountsInput input)
        {
            return _accountsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AccountDto> GetAsync(Guid id)
        {
            return _accountsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AccountDto> CreateAsync(AccountCreateDto input)
        {
            return _accountsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AccountDto> UpdateAsync(Guid id, AccountUpdateDto input)
        {
            return _accountsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _accountsAppService.DeleteAsync(id);
        }
    }
}