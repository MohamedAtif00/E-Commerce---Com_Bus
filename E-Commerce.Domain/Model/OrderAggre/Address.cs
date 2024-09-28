using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class Address : ValueObject
    {
        public Address(string state, string city, string stateId, string cityId, string firstLine, string? secondLine, int buildingNumber, int floor, string apartment)
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
        public int buildingNumber { get; set; }
        public int floor {  get; set; }
        public string apartment {  get; set; }

        public static Address Create(string state, string city, string stateId, string cityId, string firstLine, string? secondLine, int buildingNumber, int floor, string apartment)
        {
            return new(state,city, stateId,cityId,firstLine,secondLine,buildingNumber,floor,apartment);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return this;
        }
    }
}
