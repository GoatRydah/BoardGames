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

        void Save();
    }
}
