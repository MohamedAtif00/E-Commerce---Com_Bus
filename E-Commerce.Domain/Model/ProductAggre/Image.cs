using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class Image : Entity<ImageId>
    {
        public Image(ImageId id, string name, bool isMaster, ProductId productId, string path) : base(id)
        {
            Name = name;
            IsMaster = isMaster;
            ProductId = productId;
            Path = path;
        }

        public string Name { get; set; }
        public bool IsMaster { get; set; } = false;
        public bool IsRemoved { get; set; } = false;
        public string Path { get; set; }
        public DateTime Created { get; private init; } = DateTime.Now;
        public ProductId ProductId { get;private set; }
        public Product Product { get; private set; }    

        public static Image Create(string name,ProductId productId,string path,bool isMaster = false)
        {
            return new(ImageId.CreateUnique(),name,isMaster,productId,path);
        }

    }
}
