using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface ITypeRepository : IRepository<Models.Type>
    {
        IEnumerable<SelectListItem> GetTypeListOrDropdown();

        void Update(Models.Type type);
    }
}

