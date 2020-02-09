using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Topic TopicObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            TopicObj = new Models.Topic();

            if (id != null) //editing
            {
                TopicObj = _unitOfWork.Topic.GetFirstOrDefault(u => u.Id == id);
                if (TopicObj == null)
                    return NotFound();
            } //creating handled on post method

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (TopicObj.Id == 0) //New Category
            {
                _unitOfWork.Topic.Add(TopicObj);
            }
            else //edit
            {
                _unitOfWork.Topic.Update(TopicObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}