
using E_Commerce.Domain.Model.ProductAggre.Rules;
using E_Commerce.SharedKernal.Domain;


namespace E_Commerce.Domain.Model.ProductAggre
{
    public class Price : ValueObject
    {
        public int? _discount { get; private set; }
        public bool? _hasPercentage { get; private set; }
        public decimal _price { get; private set; }
        public decimal _total { get; private set; }

        public static explicit operator decimal(Price price) => price._total;

        private Price(decimal price, bool? hasPercentage, int? discount)
        {
            // Check group of rules
            CheckRule(new DiscountCannotBeNegativeRule(discount ?? 0));
            CheckRule(new PriceCannotBeZeroOrNegativeRule(price));

            // Assigning values
            _discount = discount;
            _price = price;
            _hasPercentage = hasPercentage;
            _total = CalculateTotal(price, discount??0,hasPercentage);
        }

        public static Price Create(decimal price, int discount = 0,bool hasPercentage = false)
        {
            return new Price(price, hasPercentage, discount);
        }

        public static Price Percentage(int percentage)
        {
            CheckRule(new PercentageMustBeBetween0And100Rule(percentage));
            return Price.Create(percentage / 100m,percentage,true);
        }

        private static decimal CalculateTotal(decimal price, int discount,bool? hasPercentage = false)
        {
            if (discount == 0) return price;
            if (hasPercentage != null && hasPercentage != false)
            {
                return price - (price * discount / 100);
            }
            return price - discount;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _discount;
            yield return _price;
            yield return _total;
        }
    }
}
