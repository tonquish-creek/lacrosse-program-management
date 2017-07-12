using TonquishCreek.CQRS.Commands;
using TonquishCreek.CQRS.Events;
using TonquishCreek.TeamManagement.Commands;

namespace TonquishCreek.TeamManagement.CommandHandlers
{
    public sealed class CreatePlayerCommandHandler : CommandHandlerBase<CreatePlayerCommand>
    {
        #region Constructor(s)
        public CreatePlayerCommandHandler(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }
        #endregion

        #region Public Method(s)
        public override void Handle(CreatePlayerCommand command)
        {
        }
        #endregion
    }
}
