using System;
using Xendor.QueryModel.Attributes;
using Xendor.QueryModel.Expressions;

namespace CitiBank.View.Views.Accounts.Criterias
{
    public class OperationCriteria : IMetaDataExpression
    {
        [Field("id")]
        public Guid AccountId { get; set; }
    }
}