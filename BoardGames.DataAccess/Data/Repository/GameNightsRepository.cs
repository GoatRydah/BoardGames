using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class GameNightsRepository : Repository<GameNight>, IGameNightsRepository
    {
        private readonly ApplicationDbContext _db;
 
        public GameNightsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GameNight gameNight)
        {
            var objFromDb = _db.GameNight.FirstOrDefault(s => s.GameNightId == gameNight.GameNightId);

            objFromDb.Attendees = _db.GameNightAttendees.Where(s => s.GameNightId == gameNight.GameNightId).Select(s => s.username).Count();
            objFromDb.GameNightDate = gameNight.GameNightDate;
            objFromDb.GameNightType = gameNight.GameNightType;

            _db.SaveChanges();
        }
    }
}
