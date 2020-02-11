using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoardGames.Models
{
    public class GameItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Game Item")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
        public double Price { get; set; }

        [Display(Name = "Topic")]
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        [Display(Name = "Game Type")]
        public int GameTypeId { get; set; }

        [ForeignKey("GameTypeId")]
        public virtual Models.Type Type { get; set; }
    }
}
