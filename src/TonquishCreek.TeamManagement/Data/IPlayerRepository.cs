using System;
using System.Collections.Generic;
using TonquishCreek.TeamManagement.Entities;

namespace TonquishCreek.TeamManagement.Data
{
    public interface IPlayerRepository : IEnumerable<Player>
    {
        void Add(Player player);

        void Remove(Int32 id);

        Player WithId(Int32 id);
    }
}
