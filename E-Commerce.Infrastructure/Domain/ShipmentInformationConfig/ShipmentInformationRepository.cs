using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ShipmentInformationConfig
{
    public class ShipmentInformationRepository : GenericRepository<ShipmentInformation, ShipmentInformationId>, IShipmentInformationRepository
    {
        public ShipmentInformationRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<ShipmentInformation> GetInfo()
        {
            return _context.ShipmentInformation.FirstOrDefault();
        }
    }
}
