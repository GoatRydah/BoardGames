using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using BoardGames.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames.Pages.Customer.GameNights
{
    public class GameNightsModel : PageModel
    {
            
        private readonly IUnitOfWork _unitOfWork;
        public GameNightVM GameNights;

        public GameNightsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     

        public void OnGet()
        {
            if (User.IsInRole("Manager"))
            {
            }

            GameNights = new GameNightVM();

            GameNights.gameNight = _unitOfWork.GameNights.GetAll().OrderBy(s => s.GameNightDate).ToList();
            GameNights.attendees = _unitOfWork.Attendees.GetAll().ToList();
        }

        public void OnPost(string userName, int gameNightId)
        {
            GameNight gn = _unitOfWork.GameNights.Get(gameNightId);

            GameNightAttendees gma = new GameNightAttendees();
            string userId = _unitOfWork.ApplicationUser.GetAll().Where(s => s.UserName == userName).Select(s => s.Id).FirstOrDefault();
            gma.User = _unitOfWork.ApplicationUser.GetAll().Where( s => s.Id == userId).ToList().FirstOrDefault();
            gma.GameNightId = gameNightId;
            gma.GameNight = gn;
            gma.username = userName;
            _unitOfWork.Attendees.Add(gma);
            _unitOfWork.Save();

            _unitOfWork.GameNights.Update(gn);
            _unitOfWork.Save();

            gma = _unitOfWork.Attendees.GetAll().Reverse().ToList().Last();

            OnGet();
        }
    }
}