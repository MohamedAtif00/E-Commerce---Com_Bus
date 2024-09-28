using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ShipmentInformationAggre
{
    public class PickupAddress : Entity<PickAddressId>
    {
        public PickupAddress(PickAddressId id,string state, string city, string stateId, string cityId, string firstLine, string? secondLine, int? buildingNumber, int? floor, string? apartment):base(id)
        {
            this.state = state;
            this.city = city;
            this.stateId = stateId;
            this.cityId = cityId;
            this.firstLine = firstLine;
            this.secondLine = secondLine;
            this.buildingNumber = buildingNumber;
            this.floor = floor;
            this.apartment = apartment;
        }

        public string state { get; set; }
        public string stateId { get; set; }
        public string city { get; set; }
        public string cityId { get; set; }
        public string firstLine { get; set; }
        public string? secondLine { get; set; }
        public int? buildingNumber { get; set; }
        public int? floor { get; set; }
        public string? apartment { get; set; }
        public bool isActive { get; set; } = false;

        // Navigation Properties
        public ShipmentInformation ShipmentInformation { get; set; }
        public ShipmentInformationId ShipmentInformationId { get; set; }


        public static PickupAddress Create(string state, string city, string stateId, string cityId, string firstLine, string? secondLine, int buildingNumber, int floor, string apartment)
        {
            return new(PickAddressId.CreateUnique(),state, city, stateId, cityId, firstLine, secondLine, buildingNumber, floor, apartment);
        }

        public void MakeItActive()
        {
            isActive = true;
        }


    }
}
