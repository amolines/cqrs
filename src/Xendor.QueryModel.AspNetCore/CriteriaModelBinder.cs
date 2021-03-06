using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.AspNetCore
{
    public class CriteriaModelBinder<TFilter> : IModelBinder
        where TFilter : IMetaDataExpression
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var path = bindingContext.HttpContext.Request.Path;
            var criteria = new Criteria<TFilter>(path, bindingContext.HttpContext.Request.Query);
            bindingContext.Result = ModelBindingResult.Success(criteria);
            return Task.CompletedTask;
        }
    }
}