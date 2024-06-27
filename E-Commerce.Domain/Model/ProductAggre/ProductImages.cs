using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Model.ProductAggre.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class ProductImages : ValueObject
    {
        public string[] images {  get;private set; }
        public string masterImage { get; private set; }

        public ProductImages(string[] images, string masterImage)
        {
            CheckRule(new ImagesCannotBeGreaterThanFourRule(images));
            this.images = images;
            this.masterImage = masterImage;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return images;
        }
    }
}
