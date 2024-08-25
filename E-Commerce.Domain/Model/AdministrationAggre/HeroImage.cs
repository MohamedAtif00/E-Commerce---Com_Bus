using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class HeroImage : ValueObject
    {
        public HeroImage(string path)
        {
            Path = path;
        }

        public string? Path { get; set; }

        public static HeroImage Create(string path)
        {
            return new(path);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Path };
        }
    }
}
