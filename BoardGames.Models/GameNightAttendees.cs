using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoardGames.Models
{
    public class GameNightAttendees
    {
        [Key]
        public int AttendeeId { get; set; }
        public int GameNightId { get; set; }

        [ForeignKey("GameNightId")]
        public virtual GameNight GameNight { get; set; }

        //public string Id { get; set; }
        public string username { get; set; }

        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }
    }
}
