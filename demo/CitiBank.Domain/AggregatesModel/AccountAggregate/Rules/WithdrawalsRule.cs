using Xendor.CommandModel.Validation;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Rules
{
    public class WithdrawalsRule : Rule<Account, WithdrawalsRule.WithdrawalsRuleParameter>
    {
        public WithdrawalsRule(Account aggregate)
            : base(aggregate)
        {}

        public static WithdrawalsRuleParameter CreateParameter(decimal amount, decimal totalAmount)
        {
            return new WithdrawalsRuleParameter(amount, totalAmount);
        }

        protected override void ValidateInternal(WithdrawalsRuleParameter entity)
        {
            var brokenDomainRuleBuilder = new ErrorBuilder();


            if (entity.Amount.Equals(0))
            {
                var error = brokenDomainRuleBuilder
                    .SetErrorCode("0x083")
                    .SetMessage("Amount is not valid")
                    .Build();
                AddError(error);
            }
            if (entity.Amount > entity.TotalAmount)
            {
                var error = brokenDomainRuleBuilder
                    .SetErrorCode("0x084")
                    .SetMessage("The amount is greater than the money in account")
                    .Build();
                AddError(error);
            }
           
           



        }

        public struct WithdrawalsRuleParameter
        {
            public WithdrawalsRuleParameter(decimal amount, decimal totalAmount)
            {
                TotalAmount = totalAmount;
                Amount = amount;
            }

            public decimal Amount { get; }
            public decimal TotalAmount { get; }
        }
    }
}