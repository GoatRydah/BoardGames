﻿using BoardGames.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITopicRepository Topic { get; private set; }
        public IGameItemRepository GameItem { get; private set; }
        public ITypeRepository Type { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        //Grabs a connection to the actual db to connect to this class
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Topic = new TopicRepository(_db);
            GameItem = new GameItemRepository(_db);
            Type = new TypeRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
