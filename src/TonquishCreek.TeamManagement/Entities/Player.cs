using System;

namespace TonquishCreek.TeamManagement.Entities
{
    public sealed class Player
    {
        #region Constructor(s)
        public Player()
        {
        }
        #endregion

        #region Public Properties
        public String FirstName { get; set; }

        public String LastName { get; set; }
        #endregion
    }
}
