using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class GameItemRepository : Repository<GameItem>, IGameItemRepository
    {
        private readonly ApplicationDbContext _db;

        public GameItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GameItem gameItem)
        {
            var objFromDb = _db.GameItem.FirstOrDefault(s => s.Id == gameItem.Id);

            objFromDb.Name = gameItem.Name;
            objFromDb.Price = gameItem.Price;
            objFromDb.Description = gameItem.Description;
            objFromDb.Type = gameItem.Type;
            objFromDb.Topic = gameItem.Topic;
            if (gameItem.Image != null)
                objFromDb.Image = gameItem.Image;

            _db.SaveChanges();
        }
    }
}
