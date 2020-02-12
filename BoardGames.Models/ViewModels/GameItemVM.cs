using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Models.ViewModels
{
    public class GameItemVM
    {
        public GameItem gameItem { get; set; }
        public IEnumerable<SelectListItem> TopicList { get; set; }
        public IEnumerable<SelectListItem> GameTypeList { get; set; }
    }
}
