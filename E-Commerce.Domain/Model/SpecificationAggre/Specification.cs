using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.SpecificationAggre
{
    public class Specification : AggregateRoot<SpecificationId>
    {
        private readonly List<Options> _options = new();
        public Specification(SpecificationId id, string name, CategoryId categoryId) : base(id)
        {
            _name = name;
            CategoryId = categoryId;
        }

        public string _name { get;private set; }
        public CategoryId CategoryId { get; private set; }
        public IReadOnlyCollection<Options> options => _options.AsReadOnly();

        public static Specification Create(string name,CategoryId categoryId)
        {
            return new(SpecificationId.CreateUnique(),name,categoryId);
        }

        public void Update(string name)
        {
            _name = name;
        }
    }
}
