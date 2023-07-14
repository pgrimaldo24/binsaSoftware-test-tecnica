using Microsoft.EntityFrameworkCore;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface IUnitOfWork
    { 
        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
        void Dispose(bool disposing); 
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContext Get();
        Task BeginTransaction();
        Task SaveChangeTransaction();
        Task Rollback();
        void Entry(Object obj); 
        ICustomerQuery CustomerQuery { get; }
        ICustomerContactQuery CustomerContactQuery { get; }
    }
}
