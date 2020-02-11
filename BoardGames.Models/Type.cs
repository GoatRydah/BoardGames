using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoardGames.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Game Type")]
        public string Name { get; set; }
    }
}
