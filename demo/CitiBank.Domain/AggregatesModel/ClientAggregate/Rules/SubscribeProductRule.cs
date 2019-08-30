using System;
using System.Linq;
using Xendor.CommandModel.Validation;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Rules
{
    public class SubscribeProductRule : Rule<Client, SubscribeProductRule.SubscribeProductRuleParameter>
    {
        public SubscribeProductRule(Client aggregate)
            : base(aggregate)
        {}

        public static SubscribeProductRuleParameter CreateParameter(Guid serviceId, string number)
        {
            return new SubscribeProductRuleParameter(serviceId , number);
        }

        protected override void ValidateInternal(SubscribeProductRuleParameter entity)
        {
            var brokenDomainRuleBuilder = new ErrorBuilder();
            
            FailIfNullOrBlank(entity.Number, brokenDomainRuleBuilder
                .SetErrorCode("0x001")
                .SetMessage("The number of account is required")
                .Build());
            

            if (Entity.Products.Any(p => p.Id.Equals(entity.ServiceId)))
            {
                var error = brokenDomainRuleBuilder
                    .SetErrorCode("0x002")
                    .SetMessage("The customer already has an associated service")
                    .Build();
                AddError(error);
            }

            if (!Entity.Products.Any(p => p.Number.Equals(entity.Number))) return;
            {
                var error = brokenDomainRuleBuilder
                    .SetErrorCode("0x003")
                    .SetMessage("the account number is registered")
                    .Build();
                AddError(error);
            }
        }

        public struct SubscribeProductRuleParameter
        {
            public SubscribeProductRuleParameter(Guid serviceId, string number)
            {
                ServiceId = serviceId;
                Number = number;
            }

            public Guid ServiceId { get; }
            public string Number { get; }
        }
    }
}