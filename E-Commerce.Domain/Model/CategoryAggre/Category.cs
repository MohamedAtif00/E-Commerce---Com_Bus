using E_Commerce.SharedKernal.Domain;
using Newtonsoft.Json;


namespace E_Commerce.Domain.Model.CategoryAggre
{
    public class Category : AggregateRoot<CategoryId>
    {

        private  List<ChildCategory>? _childCategories = new();
        public Category():base(CategoryId.CreateUnique())
        {
            
        }
        public Category(CategoryId id, string name  ) : base(id)
        {
            _name = name;
        }

        public string _name { get;private set; }
        public bool _visible { get; private set; } = true;

        public virtual IReadOnlyCollection<ChildCategory>? ChildCategories => _childCategories.AsReadOnly();

        public static Category Create(string name )
        {
            return new(CategoryId.CreateUnique(),name);
        }

        public void MakeItVisible()
        {
            if (!_visible) _visible = true;
        }

        public async Task RemoveChildCategory(ChildCategory childCategory)
        {
            _childCategories.Remove(childCategory);
        }

        public async Task AddChildCategory(ChildCategory childCategory)
        {
            _childCategories.Add(childCategory);
        }


    }
}
