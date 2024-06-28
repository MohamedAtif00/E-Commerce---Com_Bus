
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.SpecificationAggre
{
    public class Options : Entity<OptionsId>
    {
        public Options(OptionsId id, string name) : base(id)
        {
            _name = name;
        }

        public string _name { get;private set; }

        public SpecificationId specificationId { get; private set; }

        public static Options Create(string name)
        {
            return new(OptionsId.CreateUnique(),name);
        }

        public void Update(string name)
        {
            _name = name;
        }
    }
}
