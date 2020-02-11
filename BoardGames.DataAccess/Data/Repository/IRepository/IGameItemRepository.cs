using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface IGameItemRepository : IRepository<GameItem>
    {
        public interface IGameItemRepository : IRepository<GameItem>
        {
            void Update(GameItem gameItem);
        }
    }
}
