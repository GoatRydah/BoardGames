using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface IAttendeesRepository: IRepository<GameNightAttendees>
    {
        void Update(GameNightAttendees attendees);
    }
}
