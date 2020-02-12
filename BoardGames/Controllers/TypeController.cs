using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Type.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Type.GetFirstOrDefault(s => s.Id == id);
            if (objFromDb == null)
                return Json(new { success = false, message = "Error while deleting." });

            _unitOfWork.Type.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful." });
        }
    }
}