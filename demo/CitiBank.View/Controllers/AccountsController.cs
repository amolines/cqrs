using System;
using System.Threading.Tasks;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xendor.QueryModel;
using Xendor.QueryModel.AspNetCore;
using Xendor.QueryModel.QueryProcessor;

namespace CitiBank.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IQueryProcessorRegistry _queryProcessorRegistry;
        public AccountsController(IQueryProcessorRegistry queryProcessorRegistry)
        {
            _queryProcessorRegistry = queryProcessorRegistry ?? throw new ArgumentNullException(nameof(queryProcessorRegistry));
        }

        /// <summary>
        /// GET api/accounts
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpGet]
        [QueryAsyncActionFilter()]
        public async Task<IQueryResponse> Get(Criteria<AccountCriteria> criteria)
        {
           var query =   _queryProcessorRegistry.FindQueryProcessor<AccountCriteria>();
           var response = await query.ProcessAsync(new QueryRequest<AccountCriteria>(criteria));
           return response;
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

            var query = _queryProcessorRegistry.FindQueryProcessor<AccountCriteria>();
            var response = await query.ProcessAsync(new QueryRequest<AccountCriteria>(criteria));


         
            if (response.Data.Any())
            {
               return  (AccountDto)response.Data.GetEnumerator().Current; 
            }

            return NotFound();

        }


        [HttpGet("{id}/operations")]
        public async Task<IQueryResponse> GetOperations(Guid id, Criteria<OperationCriteria> criteria)
        {

            criteria.AddFilter("accountId", id.ToString(), typeof(Guid));

            var query = _queryProcessorRegistry.FindQueryProcessor<OperationCriteria>();
            var response = await query.ProcessAsync(new QueryRequest<OperationCriteria>(criteria));

            return response; ;

   

        }
    }
}
