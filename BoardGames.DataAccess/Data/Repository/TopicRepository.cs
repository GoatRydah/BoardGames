using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        private readonly ApplicationDbContext _db;

        public TopicRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTopicListOrDropdown()
        {
            return _db.Topic.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Topic topic)
        {
            var objFromDb = _db.Topic.FirstOrDefault(s => s.Id == topic.Id);

            objFromDb.Name = topic.Name;
            //objFromDb.DisplayOrder = topic.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
