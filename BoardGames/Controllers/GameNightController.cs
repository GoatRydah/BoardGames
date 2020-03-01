using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameNightController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GameNightController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //We cannot have a space between Category and FoodType after the 2 nulls cuz the Delete splits the string on the comma and the space blows it up.
            return Json(new { data = _unitOfWork.GameItem.GetAll(null, null, "Topic,Type") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWork.GameNights.GetFirstOrDefault(s => s.GameNightId == id);
                if (objFromDb == null)
                    return Json(new { success = false, message = "Error while deleting." });

                _unitOfWork.GameNights.Remove(objFromDb);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            return Json(new { success = true, message = "Delete successful." });
        }
    }
}