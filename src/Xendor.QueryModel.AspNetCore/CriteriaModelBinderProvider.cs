using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Xendor.QueryModel.AspNetCore
{
    public class CriteriaModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (!context.Metadata.ModelType.IsGenericType ||
                context.Metadata.ModelType.GetGenericTypeDefinition() != typeof(Criteria<>)) return null;

            var criteriaType = context.Metadata.ModelType.GenericTypeArguments[0];
            var modelBinderType = typeof(CriteriaModelBinder<>).MakeGenericType(criteriaType);
            return new BinderTypeModelBinder(modelBinderType);
        }
    }
}