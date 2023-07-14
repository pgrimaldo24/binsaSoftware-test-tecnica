using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;

namespace BinsaSoftware.ClientWebApp.Application.ListCustomer.Command
{
    public class ListCustomerServices : IListCustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCustomerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task<List<DropListClientDto>> GetCustomerAsync()
        {
            var response = new List<DropListClientDto>();
            var query = await UnitOfWork.CustomerQuery.GetCustomerAsync(); 

            query.ToList().ForEach(x =>
            {
                var request = new DropListClientDto
                {
                    clientId = x.ClientId,
                    clientDesc = x.Nombre
                }; 
                response.Add(request);
            }); 
            return response;
        }

        public async Task<List<InformationCustomerDto>> GetListCustomerAsync()
        {
            var response = new List<InformationCustomerDto>();
            var query = await UnitOfWork.CustomerQuery.GetCustomerAsync(); 
            if(query.ToList().Count() > 0)
            { 
                query.ToList().ForEach(x =>
                {
                    var informationCustomer = new InformationCustomerDto
                    {
                        clientId = x.ClientId,
                        names = x.Nombre,
                        homeAddress = x.Domicilio,
                        postalCode = Int32.Parse(x.CodigoPostal),
                        population = x.Poblacion
                    };
                    response.Add(informationCustomer);
                }); 
            } 
            return response;
        }
    }
}
