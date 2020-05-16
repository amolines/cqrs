using System;

using System.Threading.Tasks;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.AspNetCore.Mvc;
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

     
        [HttpGet]
        [QueryAsyncActionFilter()]
        public async Task<IQueryResponse> Get(Criteria<AccountCriteria> criteria)
        {
           var query =   _queryProcessorRegistry.FindQueryProcessor<AccountCriteria>();
           var response = await query.ProcessAsync(new QueryRequest<AccountCriteria>(criteria));
           return response;
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> Get(Guid id, Criteria<AccountCriteria> criteria)
        {

            criteria.AddFilter("id",id.ToString(), typeof(Guid));

            var query = _queryProcessorRegistry.FindQueryProcessor<AccountCriteria>();
            var response = await query.ProcessAsync(new QueryRequest<AccountCriteria>(criteria));


         
            if (response.Data.Count.Equals(0))
            {
               return  (AccountDto)response.Data.GetEnumerator().Current; 
            }

            return NotFound();

        }


        [HttpGet("{id}/operations")]
        [QueryAsyncActionFilter()]
        public async Task<IQueryResponse> GetOperations(Guid id, Criteria<OperationCriteria> criteria)
        {

            criteria.AddFilter("accountId", id.ToString(), typeof(Guid));

            var query = _queryProcessorRegistry.FindQueryProcessor<OperationCriteria>();
            var response = await query.ProcessAsync(new QueryRequest<OperationCriteria>(criteria));

            return response; ;

   

        }
    }
}
