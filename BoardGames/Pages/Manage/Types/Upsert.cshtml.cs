using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames.Pages.Manage.Types
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Type TypeObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            TypeObj = new Models.Type();

            if (id != null) //editing
            {
                TypeObj = _unitOfWork.Type.GetFirstOrDefault(u => u.Id == id);
                if (TypeObj == null)
                    return NotFound();
            } //creating handled on post method

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (TypeObj.Id == 0) //New Category
            {
                _unitOfWork.Type.Add(TypeObj);
            }
            else //edit
            {
                _unitOfWork.Type.Update(TypeObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}