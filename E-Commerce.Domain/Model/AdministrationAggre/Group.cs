using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class Group : Entity<GroupId>
    {
        public Group(GroupId id, string groupName) : base(id)
        {
            GroupName = groupName;
        }

        public string GroupName { get;private set; }

        public static Group Create(string groupName)
        {
            return new(GroupId.CreateUnique(),groupName);
        }

        public void Update(string name)
        {
            GroupName = name;
        }
    }
}
