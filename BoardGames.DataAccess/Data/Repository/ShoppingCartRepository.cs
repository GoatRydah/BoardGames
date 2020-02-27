using BoardGames.DataAccess.Data.Repository.IRepository;
using BoardGames.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int Count)
        {
            shoppingCart.Count -= 1;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int Count)
        {
            shoppingCart.Count += 1;
            return shoppingCart.Count;
        }
    }
}
