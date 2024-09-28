using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ShipmentInformationAggre
{
    public class ShipmentInformation : AggregateRoot<ShipmentInformationId>
    {
        public ShipmentInformation(ShipmentInformationId id, string email, string fullName) : base(id)
        {
            Email = email;
            FullName = fullName;
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string? Token { get; set; }
        public ICollection<PickupAddress> pickupAddresses { get; set; }

        public static ShipmentInformation Create(string email,string fullName)
        {
            return new(ShipmentInformationId.CreateUnique(),email,fullName);
        }

        public void Update(string email,string fullName)
        {
            Email = email;
            FullName = fullName;
        }

        public void SetToken(string token) 
        {
            Token = token;  
        }

        public void AddPickupAddress(PickupAddress address)
        {
            pickupAddresses.Add(address);
        }
    }
}
