using System;
using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.AccountAggregate;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.CommandModel;

namespace CitiBank.Domain.Handlers
{
    public class AccountTransferedEventHanlder : IDomainEventHandler<AccountTransferedEvent>
    {
        private readonly IAggregateRootRepository _aggregateRootRepository;
        public AccountTransferedEventHanlder(IAggregateRootRepository aggregateRootRepository)
        {
            _aggregateRootRepository = aggregateRootRepository ?? throw new ArgumentNullException(nameof(aggregateRootRepository));
        }

        public async Task HandleAsync(AccountTransferedEvent @event)
        {
            var client = await _aggregateRootRepository.Get<Account>(@event.Id);
            client.Deposit( @event.Amount, @event.Description);
            await _aggregateRootRepository.Save(client);
        }

  
    }
}