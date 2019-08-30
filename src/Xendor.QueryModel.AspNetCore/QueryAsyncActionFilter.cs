using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Xendor.QueryModel.AspNetCore
{
    public class QueryAsyncActionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            #region execute any code before the action executes
            #endregion
            var result = await next();
            #region execute any code after the action executes
            var objectResult = result.Result as ObjectResult;
            var query = objectResult.Value as IQueryResult;
            foreach (var value in query.Header.Value)
            {
                if(!string.IsNullOrEmpty(value.Value))
                    context.HttpContext.Response.Headers.Add(value.Key, value.Value);
            }
            objectResult.Value = query.Data;
            #endregion
        }
    }
}