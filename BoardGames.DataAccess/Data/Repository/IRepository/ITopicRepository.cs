using BoardGames.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        IEnumerable<SelectListItem> GetTopicListOrDropdown();

        void Update(Topic topic);
    }
}
