using System;
using ServerSide.DAL.Models;
using ServerSide.DAL.Repositories;

namespace ServerSide.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Attachment> _attachmentRepository;
        private IGenericRepository<Todo> _todoRepository;
        private readonly TaskListContext _context = new TaskListContext();
        private bool _disposed;

        public IGenericRepository<Attachment> AttachmentRepository => _attachmentRepository
                                                                      ?? (_attachmentRepository =
                                                                          new EfGenericRepository<Attachment>(_context)
                                                                      );

        public IGenericRepository<Todo> TodoRepository =>
            _todoRepository ?? (_todoRepository = new EfGenericRepository<Todo>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
