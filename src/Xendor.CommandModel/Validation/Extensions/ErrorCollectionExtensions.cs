using System.Collections.Generic;

namespace Xendor.CommandModel.Validation.Extensions
{
    internal static class ErrorCollectionExtensions
    {
        internal static ErrorCollection Merge(this ErrorCollection brokenDomainRuleCollection,
            ErrorCollection array)
        {
            var tempBrokenDomainRules = new List<Error>(brokenDomainRuleCollection.Errors + array.Errors);
            tempBrokenDomainRules.AddRange(brokenDomainRuleCollection.BrokenDomainRules);
            tempBrokenDomainRules.AddRange(array.BrokenDomainRules);
            var result = new ErrorCollection(tempBrokenDomainRules.ToArray());
            return result;
        }
    }
}