using E_Commerce.Domain.Model.SuperCategoryAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    public class Category : AggregateRoot<CategoryId>
    {
        private readonly List<Category> _categories = new();  
        public Category(CategoryId id) : base(id)
        {
        }

        public string _name { get;private set; }

        public SuperCategoryId? SuperCategoryId { get; private set; }
        public CategoryId? _parentCategory {  get; private set; }

        public IReadOnlyCollection<Category> ChildCategories => _categories;
    }
}
