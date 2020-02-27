using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITopicRepository Topic { get; }
        IGameItemRepository GameItem { get; }
        ITypeRepository Type { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IGameNightsRepository GameNights { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }

        void Save();
    }
}
