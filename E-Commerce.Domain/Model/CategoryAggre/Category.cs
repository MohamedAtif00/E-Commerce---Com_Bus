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
        public Category(CategoryId id, string name, SuperCategoryId? superCategoryId , CategoryId? parentCategoryId ) : base(id)
        {
            _name = name;
            SuperCategoryId = superCategoryId;
            _parentCategoryId = parentCategoryId;
        }

        public string _name { get;private set; }
        public SuperCategoryId? SuperCategoryId { get; private set; }
        public CategoryId? _parentCategoryId {  get; private set; }
        public bool _visible { get; private set; } = false;

        public IReadOnlyCollection<Category> ChildCategories => _categories;

        public static Category Create(string name, SuperCategoryId? superCategoryId , CategoryId? parentCategory)
        {
            return new(CategoryId.CreateUnique(),name,superCategoryId,parentCategory);
        }

        public void MakeItVisible()
        {
            if (!_visible) _visible = true;
        }
    }
}
