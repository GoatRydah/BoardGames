using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class AttendeesRepository: Repository<GameNightAttendees>, IAttendeesRepository
    {
        private readonly ApplicationDbContext _db;

        public AttendeesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GameNightAttendees attendees)
        {
            //var objFromDb = _db.GameNightAttendees.FirstOrDefault(s => s.Id == attendees.Id);

            //objFromDb.Id = attendees.Id;

            _db.SaveChanges();
        }
    }
}
