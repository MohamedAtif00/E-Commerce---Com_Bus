using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.SuperCategoryAggre
{
    public class SuperCategory : AggregateRoot<SuperCategoryId>
    {
        private readonly List<Category> _categories = new();
        public SuperCategory(SuperCategoryId id) : base(id)
        {
        }

        public string _name { get;private set; }
        public  IReadOnlyCollection<Category> categories => _categories;
    }
}
