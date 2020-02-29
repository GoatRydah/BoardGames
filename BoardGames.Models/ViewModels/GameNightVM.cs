using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Models.ViewModels
{
    public class GameNightVM
    {
        public List<GameNight> gameNight { get; set; }
        public List<GameNightAttendees> attendees { get; set; }
    }
}
