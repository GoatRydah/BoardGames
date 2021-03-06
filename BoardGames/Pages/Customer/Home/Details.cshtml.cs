﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using BoardGames.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BoardGames.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        [BindProperty]
        public ShoppingCart ShoppingCartObj { get; set; }


        public void OnGet(int id)
        {
            ShoppingCartObj = new ShoppingCart()
            {
                GameItem = _unitOfWork.GameItem.GetFirstOrDefault
                (includeProperties: "Topic,Type", filter: g => g.Id == id),
                GameItemId = id
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                ShoppingCartObj.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.ApplicationUserId == ShoppingCartObj.ApplicationUserId &&
                c.GameItemId == ShoppingCartObj.GameItemId);

                //Does Shopping Cart item list exist in the DB
                if (cartFromDb == null)
                {
                    _unitOfWork.ShoppingCart.Add(ShoppingCartObj);
                }
                //already an entry with this item/user combo in DB so we just want to update the count
                else
                {
                    _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, cartFromDb.Count);
                }

                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == ShoppingCartObj.ApplicationUserId).ToList().Count;

                //new session
                HttpContext.Session.SetInt32(SD.ShoppingCart, count);
                return RedirectToPage("Index");
            }
            else // adding new item
            {
                ShoppingCartObj.GameItem = _unitOfWork.GameItem.GetFirstOrDefault(includeProperties: "Category,FoodType", filter: c => c.Id == ShoppingCartObj.GameItemId);
                return Page();
            }
        }
    }
}