using E_Commerce.Domain.Model.ProductAggre.Rules;
using E_Commerce.SharedKernal.Domain;


namespace E_Commerce.Domain.Model.ProductAggre
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        private Product(ProductId id,
                        string name,
                        string description,
                        Price price,
                        int stockQuantity) : base(id)
        {
            _name = name;
            _description = description;
            _price = price;
            _stockQuantity = stockQuantity;
        }



        public string _name { get; private set; }
        public string _description { get; private set; }
        public Price _price { get; private set; }
        public int _stockQuantity { get; private set; }
        public DateTime _CreatedAt { get; private init; } = DateTime.Now;
        public DateTime _UpdatedAt { get; private set; }


        public static Product Create(string name,
                                    string description,
                                    Price price,
                                    int stockQuantity)
        {
            return new(ProductId.CreateUnique(),name,description,price,stockQuantity);
        }

        public void Update(string name,
                            string description,
                            Price price,
                            int stockQuantity)
        {
            _name = name;
            _description = description;
            _price = price;
            _stockQuantity = stockQuantity;
        }

        public void DecreaseInventory(int number)
        {
            CheckRule(new StockQuantityCannotBeNegativeRule(_stockQuantity - number));
            _stockQuantity -= number;
        }

         

    }
}
