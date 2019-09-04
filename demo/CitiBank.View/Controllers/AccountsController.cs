using System;
using System.Threading.Tasks;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Xendor.QueryModel;
using Xendor.QueryModel.AspNetCore;

namespace CitiBank.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public AccountsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        /// <summary>
        /// GET api/accounts
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpGet]
        [QueryAsyncActionFilter()]
        public async Task<IQueryResult> Get(Criteria<AccountCriteria> criteria)
        {
           var query =  await _queryDispatcher.Submit(criteria);
           return query;
        }

        /// <summary>
        /// GET api/accounts/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> Get(Guid id, Criteria<AccountCriteria> criteria)
        {

            criteria.AddFilter("id",id.ToString(), typeof(Guid));
            var query = await _queryDispatcher.Submit(criteria);
            if (query.Data.Any())
            {
               return  (AccountDto)query.Data.GetEnumerator().Current; 
            }

            return NotFound();

        }
    }
}
