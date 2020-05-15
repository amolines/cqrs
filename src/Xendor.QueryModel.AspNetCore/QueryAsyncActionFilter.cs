using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Xendor.QueryModel.QueryProcessor;

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

            if(result.Result is ObjectResult objectResult)
            {
                if (!(objectResult.Value is IQueryResponse query))
                {

                }
                else
                {
                    if (query.Data.Count > 0)
                    {
                        if (query.Header?.Value != null && query.Header.Value.Any())
                        {
                            foreach (var value in query.Header.Value)
                            {
                                if (!string.IsNullOrEmpty(value.Value))
                                    context.HttpContext.Response.Headers.Add(value.Key, value.Value);
                            }
                        }

                        objectResult.Value = query.Data;
                    }
                    else
                    {
                        objectResult.StatusCode = 404;
                        objectResult.Value = null;
                    }
                }
            }
           
            #endregion
        }
    }
}