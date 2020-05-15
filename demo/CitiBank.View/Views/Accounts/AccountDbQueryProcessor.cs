using System;
using System.Collections.Generic;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.Dtos;
using Xendor.QueryModel;
using Xendor.QueryModel.Expressions.EmbedCollection;
using Xendor.QueryModel.QueryProcessor;
using Xendor.QueryModel.QueryProcessor.Infrastructure;

namespace CitiBank.View.Views.Accounts
{
    public class AccountDbQueryProcessor : DbQueryProcessor<AccountCriteria, AccountQuery, AccountDto>
    {
        public AccountDbQueryProcessor(IRepository<AccountDto> repository, IQueryProcessorRegistry queryProcessorRegistry)
            : base(repository, queryProcessorRegistry)
        {
        }

        protected override void SetEmbeds(IEmbedCollectionExpression embeds, AccountDto root)
        {
            foreach (var embed in embeds.Embeds)
            {
                switch (embed.Name)
                {
                    case "operations":
                        var criteria = new Criteria<OperationCriteria>();
                        criteria.AddFilter("accountId", root.Id.ToString(), typeof(Guid));
                        root.Operations =(IEnumerable<OperationDto>) ProcessAsync(criteria).Result;
                        break;
                }
            }
        }
    }
}