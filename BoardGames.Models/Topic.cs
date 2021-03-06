﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BoardGames.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Game Topic")]
        public string Name { get; set; }
        //[Display(Name="Display Order")]
        //public int DisplayOrder { get; set; }
    }
}
