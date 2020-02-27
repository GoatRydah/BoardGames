using System;
using System.Collections.Generic;
using System.Text;
using BoardGames.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topic { get; internal set; }
        public DbSet<GameItem> GameItem { get; internal set; }
        public DbSet<Models.Type> Type { get; internal set; }
        public DbSet<ApplicationUser> ApplicationUser { get; internal set; }
        public DbSet<ShoppingCart> ShoppingCart { get; internal set; }
        public DbSet<GameNight> GameNight { get; internal set; }
        public DbSet<OrderHeader> OrderHeader { get; internal set; }
        public DbSet<OrderDetails> OrderDetails { get; internal set; }
    }
}
