using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre.Rules;
using E_Commerce.SharedKernal.Domain;
using System.Diagnostics;


namespace E_Commerce.Domain.Model.ProductAggre
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        private readonly List<Image> _images = new();
        private readonly List<Review> _reviews = new();
        private Product(ProductId id) : base(id)
        {
            // EF
        }

        private Product(ProductId id,
                        CategoryId categoryId,
                        string name,
                        string nameArab,
                        string description,
                        string descriptionArab,
                        Price price,
                        int stockQuantity
            ) : base(id)
        {
            _name = name;
            _price = price;
            _description = description;
            this.categoryId = categoryId;
            _stockQuantity = stockQuantity;
            _name_arab = nameArab;
            _description_arab = descriptionArab;
        }


        public string _name { get; private set; }
        public string _name_arab { get;private set; }
        public string _description { get; private set; }
        public string _description_arab { get; private set; }
        public Price _price { get; private set; }
        public int _stockQuantity { get; private set; }
        public decimal _totalReviews { get; private set; } = 0;
        public DateTime _CreatedAt { get; private init; } = DateTime.UtcNow;
        public DateTime? _UpdatedAt { get; private set; }
        public CategoryId categoryId { get; private set; }
        public bool IsSpecial { get; private set; } = false;
        public GroupId? _groupId { get; private set; }
         

        public IReadOnlyCollection<Image> images => _images.AsReadOnly();
        public IReadOnlyCollection<Review> reviews => _reviews.AsReadOnly();

        public static Product Create(CategoryId categoryId,
                                    string name,
                                    string nameArab,
                                    string description,
                                    string descriptionArab,
                                    Price price,
                                    int stockQuantity)
        {
            return new(ProductId.CreateUnique(),categoryId ,name,nameArab,description,descriptionArab,price,stockQuantity);
        }

        public void UpdateDetails(string name,
                                string nameArab,
                            string description,
                            string descriptionArab,
                            int stockQuantity,
                            Price price,
                            CategoryId categoryId)
        {
            _name = name;
            _name_arab = nameArab;
            _description = description;
            _description_arab = descriptionArab;
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

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public void MakeSpecial(GroupId groupId)
        {
            IsSpecial = true;
            _groupId = groupId;
        }

        public void AddTotalReviews(decimal totalReviews)
        {
            _totalReviews = totalReviews;
        }


    }
}
