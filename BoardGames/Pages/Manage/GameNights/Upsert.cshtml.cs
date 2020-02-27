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

        public IActionResult OnPost(GameNight gNight)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.GameNights.Add(gNight);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}