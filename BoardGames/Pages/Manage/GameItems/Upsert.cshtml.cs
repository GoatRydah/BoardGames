using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGames.Pages.Manage.GameItems
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public GameItemVM GameItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            GameItemObj = new GameItemVM
            {
                TopicList =
                _unitOfWork.Topic.GetTopicListOrDropdown(),
                GameTypeList =
                _unitOfWork.Type.GetTypeListOrDropdown(),
                gameItem = new Models.GameItem()
            };



            if (id != null) //editing
            {
                GameItemObj.gameItem = _unitOfWork.GameItem.GetFirstOrDefault(u => u.Id == id);
                if (GameItemObj == null)
                    return NotFound();
            } //creating handled on post method

            return Page();
        }

        public IActionResult OnPost()
        {
            //Find path to wwwroot
            string webRoutePath = _hostingEnvironment.WebRootPath;
            //Grab the file(s) from the form
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
                return Page();

            if (GameItemObj.gameItem.Id == 0) //New Category
            {
                //rename the file
                string fileName = Guid.NewGuid().ToString();

                //upload file to path
                var uploads = Path.Combine(webRoutePath, @"images\gameItems");

                //preserce extension (.jpg, .png, etc)
                var extension = Path.GetExtension(files[0].FileName);

                //append new name to extension
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                GameItemObj.gameItem.Image = @"\images\gameItems\" + fileName + extension;

                _unitOfWork.GameItem.Add(GameItemObj.gameItem);
            }
            else //edit
            {
                var objFromDb = _unitOfWork.GameItem.Get(GameItemObj.gameItem.Id);
                //were there any files submitted with the post
                if (files.Count > 0)
                {
                    //rename the file
                    string fileName = Guid.NewGuid().ToString();

                    //upload file to path
                    var uploads = Path.Combine(webRoutePath, @"images\gameItems");

                    //preserce extension (.jpg, .png, etc)
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRoutePath, objFromDb.Image.Trim('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);

                        //append new name to extension
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        GameItemObj.gameItem.Image = @"\images\gameItems\" + fileName + extension;
                    }
                    else
                    {
                        GameItemObj.gameItem.Image = objFromDb.Image;
                    }
                }
                _unitOfWork.GameItem.Update(GameItemObj.gameItem);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}