﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Models
{
    public class GameNight
    {
        public int GameNightId { get; set; }
        public DateTime GameNightDate { get; set; }
        public string GameNightType { get; set; }
        public int Attendees { get; set; }
    }
}
