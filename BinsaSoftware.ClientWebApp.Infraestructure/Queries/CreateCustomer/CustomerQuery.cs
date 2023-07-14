using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context;
using BinsaSoftware.ClientWebApp.Infraestructure.Feature.Repository;
using Microsoft.EntityFrameworkCore;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Queries.CreateCustomer
{
    public class CustomerQuery : BaseRepository<BinsaSoftwareContextConnection, ClientEntity>, ICustomerQuery
    {
        private readonly BinsaSoftwareContextConnection _context;

        public CustomerQuery(BinsaSoftwareContextConnection binsaSoftwareContextConnection) : base(binsaSoftwareContextConnection)
        {
            _context = binsaSoftwareContextConnection;
        }

        public async Task<List<ClientEntity>> GetCustomerAsync()
        {
            return await _context.Clients.Where(x => !string.IsNullOrEmpty(x.Nombre)).ToListAsync();
        }

        public async Task<ClientEntity> GetCustomerByIdAsync(int id)
        {
            return await _context.Clients.Where(x => x.ClientId == id).FirstOrDefaultAsync();
        }
    }
}
