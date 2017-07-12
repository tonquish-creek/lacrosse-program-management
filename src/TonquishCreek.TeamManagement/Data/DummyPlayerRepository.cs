using System;
using System.Collections;
using System.Collections.Generic;
using TonquishCreek.TeamManagement.Entities;

namespace TonquishCreek.TeamManagement.Data
{
    public sealed class DummyPlayerRepository : IPlayerRepository
    {
        #region Private Field(s)
        private List<Player> _innerList;
        #endregion

        #region Constructor(s)
        public DummyPlayerRepository()
        {
            _innerList = new List<Player>()
            {
                new Player() { FirstName = "Matthew", LastName = "Auer" },
                new Player() { FirstName = "Wilson", LastName = "Ayers" },
                new Player() { FirstName = "Casey", LastName = "Bremer" }
            };
        }
        #endregion

        #region Public Method(s)
        public void Add(Player player)
        {
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        public void Remove(Int32 id)
        {
        }

        public Player WithId(Int32 id)
        {
            var index = id % 3;

            return _innerList[index];
        }
        #endregion

        #region IEnumerable Member(s)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
