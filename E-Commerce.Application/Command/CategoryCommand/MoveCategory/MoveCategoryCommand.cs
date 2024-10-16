using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.MoveCategory
{
    public class MoveCategoryCommand : ICommand
    {
        public Guid SourceCategoryId { get; set; }  // ID of the category being moved (could be a Category or ChildCategory)
        public Guid? NewParentCategoryId { get; set; } // New parent category ID

        public MoveCategoryCommand(Guid sourceCategoryId, Guid? newParentCategoryId)
        {
            SourceCategoryId = sourceCategoryId;
            NewParentCategoryId = newParentCategoryId;
        }
    }



}
