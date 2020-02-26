﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames
{
    public class GameNightsModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<GameNight> GameNights;

        public GameNightsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     

        public void OnGet()
        {
            GameNights = _unitOfWork.GameNights.GetAll(null, g => g.OrderBy(n => n.GameNightDate), null);
        }
    }
}