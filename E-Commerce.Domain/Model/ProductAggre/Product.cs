using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre.Rules;
using E_Commerce.SharedKernal.Domain;
using System.Diagnostics;


namespace E_Commerce.Domain.Model.ProductAggre
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        private readonly List<Image> _images = new();
        private Product(ProductId id) : base(id)
        {
            // EF
        }

        private Product(ProductId id,
                        CategoryId categoryId,
                        string name,
                        string description,
                        Price price,
                        int stockQuantity):base(id)
        {
            _name = name;
            _price = price;
            _description = description;
            this.categoryId = categoryId;
            _stockQuantity = stockQuantity;
        }


        public string _name { get; private set; }
        public string _description { get; private set; }
        public Price _price { get; private set; }
        public int _stockQuantity { get; private set; }
        public DateTime _CreatedAt { get; private init; } = DateTime.UtcNow;
        public DateTime? _UpdatedAt { get; private set; }
        public CategoryId categoryId { get; private set; }

        public IReadOnlyCollection<Image> images => _images.AsReadOnly();

        public static Product Create(CategoryId categoryId,
                                    string name,
                                    string description,
                                    Price price,
                                    int stockQuantity)
        {
            return new(ProductId.CreateUnique(),categoryId ,name,description,price,stockQuantity);
        }

        public void UpdateDetails(string name,
                            string description,
                            int stockQuantity,
                            Price price,
                            CategoryId categoryId)
        {
            _name = name;
            _description = description;
            _stockQuantity = stockQuantity;
            _price = price;
            this.categoryId = categoryId;
        }

        public void DecreaseInventory(int number)
        {
            CheckRule(new StockQuantityCannotBeNegativeRule(_stockQuantity - number));
            _stockQuantity -= number;
        }

        public void AddMasterImage(Image image)
        {
            _images.Add(image);
        }

        public void AddImages(List<Image> images)
        {
            _images.AddRange(images);
        }

        public void DeleteAllImages()
        {
            _images.Clear();
        }

      

    }
}
