using E_Commerce.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Rules
{
    public class ImagesCannotBeGreaterThanFourRule : IBusinessRule
    {
        public string[] images { get;  }
        public ImagesCannotBeGreaterThanFourRule(string[] images)
        {
            this.images = images;
        }

        public string Message => "Images Cannot be greater than 4";

        public bool IsBroken()
        {
            return images.Length > 3;
        }
    }
}
