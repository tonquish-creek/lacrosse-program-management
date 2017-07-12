using System;
using TonquishCreek.CQRS.Commands;

namespace TonquishCreek.TeamManagement.Commands
{
    public sealed class CreatePlayerCommand : ICommand
    {
        #region Constructor(s)
        public CreatePlayerCommand(String firstName, String lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        #region Public Properties
        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        #endregion
    }
}
