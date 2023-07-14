using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context;
using BinsaSoftware.ClientWebApp.Infraestructure.Queries.CreateCustomer;
using BinsaSoftware.ClientWebApp.Infraestructure.Queries.CustomerContact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Feature.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BinsaSoftwareContextConnection _dbContext;
        private bool _disposed;
        private IDbContextTransaction _transaction; 
        private ICustomerQuery _CustomerQuery;
        private ICustomerContactQuery _CustomerContactQuery;

        public UnitOfWork(
            BinsaSoftwareContextConnection binsaSoftwareContextConnection,
            ICustomerQuery customerQuerie,
            ICustomerContactQuery customerContactQuery)
        {
            _dbContext = binsaSoftwareContextConnection;
            _CustomerQuery = customerQuerie;
            _CustomerContactQuery = customerContactQuery;
        }

        public ICustomerQuery CustomerQuery
        {
            get
            {
                _CustomerQuery ??= new CustomerQuery(_dbContext);
                return _CustomerQuery;
            }
        }

        public ICustomerContactQuery CustomerContactQuery
        {
            get
            {
                _CustomerContactQuery ??= new CustomerContactQuery(_dbContext);
                return _CustomerContactQuery;
            }
        }

        public async Task BeginTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<int> CompletedAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Entry(object obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public DbContext Get()
        {
            return _dbContext;
        }
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangeTransaction()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _dbContext.Dispose();
                }

            _disposed = true;
        }
    }
}
