using BoardGames.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class TypeRepository : Repository<Models.Type>, ITypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTypeListOrDropdown()
        {
            return _db.Type.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Models.Type type)
        {
            var objFromDb = _db.Type.FirstOrDefault(s => s.Id == type.Id);

            objFromDb.Name = type.Name;
            //objFromDb.DisplayOrder = type.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
