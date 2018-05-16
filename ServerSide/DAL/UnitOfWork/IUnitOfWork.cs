using ServerSide.DAL.Models;
using ServerSide.DAL.Repositories;

namespace ServerSide.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Attachment> AttachmentRepository { get; }
        IGenericRepository<Todo> TodoRepository { get; }
        void Save();
    }
}
