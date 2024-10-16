using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    public class ChildCategory : Entity<ChildCategoryId>
    {
        private readonly List<ChildCategory>? _childCategories = new();

        public ChildCategory() : base(ChildCategoryId.CreateUnique())
        {
        }

        private ChildCategory(ChildCategoryId id, string name, CategoryId? parentCategoryId, ChildCategoryId? parentChildCategoryId) : base(id)
        {
            _name = name;
            _parentCategoryId = parentCategoryId;
            _parentChildCategoryId = parentChildCategoryId;
        }

        public string _name { get; private set; }
        public CategoryId? _parentCategoryId { get; private set; }
        public Category? category { get; private set; }
        public ChildCategoryId? _parentChildCategoryId { get; private set; }
        public ChildCategory? childCategory { get; private set; }
        public bool _visible { get; private set; } = true;

        public virtual IReadOnlyCollection<ChildCategory>? ChildCategories => _childCategories;

        public static ChildCategory Create(string name, CategoryId? parentCategory = null,ChildCategoryId parentChildCategoryId = null)
        {
            return new(ChildCategoryId.CreateUnique(), name, parentCategory,parentChildCategoryId);
        }

        public async Task SetParentCategory(CategoryId? parentCategoryId)
        {
            _parentCategoryId = parentCategoryId;
        }

        public async Task SetParentChildCategory(ChildCategoryId? parentChildCategoryId)
        {
            _parentChildCategoryId = parentChildCategoryId;
        }

        public async Task RemoveChildCategory(ChildCategory category)
        {
            _childCategories.Remove(category);
        }

        public async Task AddChildCategory(ChildCategory childCategory)
        {
            _childCategories.Add(childCategory);
        }

        // New method to get child categories by Parent CategoryId or Parent ChildCategoryId
        public List<ChildCategory> GetChildCategoriesByParentId(CategoryId? parentCategoryId, ChildCategoryId? parentChildCategoryId)
        {
            if (parentCategoryId != null)
            {
                return _childCategories.Where(c => c._parentCategoryId == parentCategoryId).ToList();
            }
            else if (parentChildCategoryId != null)
            {
                return _childCategories.Where(c => c._parentChildCategoryId == parentChildCategoryId).ToList();
            }
            return new List<ChildCategory>(); // Return an empty list if no valid parent ID is provided
        }
    }
}
