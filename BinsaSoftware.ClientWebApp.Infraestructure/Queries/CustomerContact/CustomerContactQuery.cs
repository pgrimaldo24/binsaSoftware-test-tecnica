using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context;
using BinsaSoftware.ClientWebApp.Infraestructure.Feature.Repository;
using Microsoft.EntityFrameworkCore;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Queries.CustomerContact
{
    public class CustomerContactQuery : BaseRepository<BinsaSoftwareContextConnection, CustomerContactEntity>, ICustomerContactQuery
    {
        private readonly BinsaSoftwareContextConnection _context;
        public CustomerContactQuery(BinsaSoftwareContextConnection binsaSoftwareContextConnection) : base(binsaSoftwareContextConnection)
        {
            _context = binsaSoftwareContextConnection;
        }

        public async Task<CustomerContactEntity> GetCustomerContactAsync(int id)
        {
            return await _context.CustomerContacts.Where(x => x.IdCustomer == id).FirstOrDefaultAsync();
        }

        public async Task<List<CustomerContactEntity>> GetCustomerContactsAsync(int id)
        {
            return await _context.CustomerContacts.Where(x => x.ClientId == id).ToListAsync();
        }
    }
}
