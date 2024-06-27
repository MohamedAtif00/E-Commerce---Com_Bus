using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Model.ProductAggre.Rules;


namespace E_Commerce.Domain.Model.ProductAggre
{
    public class Price : ValueObject
    {
        public int _discount { get; }
        public decimal _price { get; private set; }
        public decimal? _total { get; private set; }

        private Price(decimal price, int discount = 0)
        {
            // Check group of rules
            CheckRule(new DiscountCannotBeNegativeRule(discount));
            CheckRule(new PriceCannotBeZeroOrNegativeRule(price));

            // Assigning values
            _discount = discount;
            _price = price;
            _total = CalculateTotal(price, discount);
        }

        public static Price Create(decimal price, int discount = 0)
        {
            return new Price(price, discount);
        }

        public static Price Percentage(int percentage)
        {
            CheckRule(new PercentageMustBeBetween0And100Rule(percentage));
            return new Price(percentage / 100m);
        }

        private static decimal? CalculateTotal(decimal price, int discount)
        {
            if (discount == 0) return price;
            return price - (price * discount / 100);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _discount;
            yield return _price;
            yield return _total;
        }
    }
}
