using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames.Pages.Manage.GameNights
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public GameNight gameNight { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int id = 0)
        {
            gameNight = new GameNight();

            if (id != 0)
            {
                gameNight = _unitOfWork.GameNights.Get(id);
            }

            return Page();
        }

        public IActionResult OnPost(int id, DateTime date, string type, int capacity, string creating)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            GameNight gNight = new GameNight();
            gNight.GameNightId = id;
            gNight.GameNightDate = date;
            gNight.GameNightType = type;
            gNight.Capacity = capacity;
            gNight.Attendees = 0;

            if (creating == "creating")
            {
                _unitOfWork.GameNights.Add(gNight);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.GameNights.Update(gNight);
                _unitOfWork.Save();
            }

            return RedirectToPage("/Manage/GameNights/Index");
        }
    }
}