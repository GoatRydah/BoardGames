using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository.IRepository
{
    public interface IShoppingCartRepository: IRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shoppingCart, int Count);
        int DecrementCount(ShoppingCart shoppingCart, int Count);
    }
}
