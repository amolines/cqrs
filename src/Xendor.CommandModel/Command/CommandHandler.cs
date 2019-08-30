using System;
using System.Threading.Tasks;
using Xendor.Data;

namespace Xendor.CommandModel.Command
{

    public abstract class CommandHandler<TCommand, TAggregateRoot> : IApplicationLogic, ICommandHandler<TCommand>
        where TAggregateRoot : AggregateRoot
        where TCommand : ICommand
    {
        private readonly IAggregateRootRepository _aggregateRootRepository;
        private readonly IUnitOfWork _unitOfWork;

        protected CommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository)
        {
            if (unitOfWorkManager == null)
                throw new ArgumentNullException(nameof(unitOfWorkManager));
            _aggregateRootRepository = aggregateRootRepository ?? throw new ArgumentNullException(nameof(aggregateRootRepository));
            _unitOfWork = unitOfWorkManager.CurrentUnitOfWork();
        }
        public abstract Task<ICommandResult> Handle(TCommand command);
        protected async Task<TAggregateRoot> Get(Guid aggregateId)
        {
            return await _aggregateRootRepository.Get<TAggregateRoot>(aggregateId);
        }
        protected async Task<T> Get<T>(Guid aggregateId)
            where T : AggregateRoot
        {
            return await _aggregateRootRepository.Get<T>(aggregateId);
        }
        protected async Task<CommandResult> SaveAndCommit(TAggregateRoot aggregate)
        {
            if (aggregate.Notification.HasErrors)
            {
                return new CommandResult(aggregate.Id, aggregate.Notification.Errors);
            }
            await _aggregateRootRepository.Save(aggregate);
            _unitOfWork.Commit();
            return new CommandResult(aggregate.Id);
        }
        protected void RollBack()
        {
            _unitOfWork.RollBack();
        }

    }

}