using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.MoveCategory
{
    public class MoveCategoryCommandHandler : ICommandHandler<MoveCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoveCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(MoveCategoryCommand command, CancellationToken cancellationToken)
        {
            var isChildCategory = await _unitOfWork.ChildCategoryRepository.GetById(ChildCategoryId.Create( command.SourceCategoryId)) != null;
            if (isChildCategory)
            {
                // Fetch the child category to move
                var childCategory = await _unitOfWork.ChildCategoryRepository.GetById(ChildCategoryId.Create(command.SourceCategoryId),true);
                if (childCategory == null)
                {
                    return Result.Error("Child category not found.");
                }


                // If a new parent is provided, add the child category to it
                if (command.NewParentCategoryId != null)
                {
                    var category = await _unitOfWork.CategoryRepository.GetById(CategoryId.Create( (Guid)command.NewParentCategoryId));

                    if (category != null)
                    {
                        var newParentCategory = await _unitOfWork.CategoryRepository.GetById(CategoryId.Create((Guid)command.NewParentCategoryId));
                        await newParentCategory.AddChildCategory(childCategory);
                        await childCategory.SetParentCategory(newParentCategory.Id);

                        await _unitOfWork.CategoryRepository.Update(newParentCategory);


                    }
                    else {
                        var newParentCategory = await _unitOfWork.ChildCategoryRepository.GetById(ChildCategoryId.Create((Guid)command.NewParentCategoryId));
                        await newParentCategory.AddChildCategory(childCategory);
                        await childCategory.SetParentChildCategory(newParentCategory.Id);

                        await _unitOfWork.ChildCategoryRepository.Update(newParentCategory);

                        await _unitOfWork.ChildCategoryRepository.Delete(childCategory);
                    }

                }
                else
                {
                    // If no new parent, make it standalone (no parent)
                    await _unitOfWork.ChildCategoryRepository.Delete(childCategory);
                    await _unitOfWork.CategoryRepository.Add(Category.Create(childCategory._name));
                }
            }
            else
            {
                // Fetch the category to move (Categories have no parent, only children)
                var category = await _unitOfWork.CategoryRepository.GetById(CategoryId.Create(command.SourceCategoryId));
                if (category == null)
                {
                    return Result.Error("Category not found.");
                }

                // Handle converting a Category to a ChildCategory if needed
                if (command.NewParentCategoryId != null)
                {
                    Guid newParentCategoryId = command.NewParentCategoryId.Value; // Safely extract the value

                    var newParentCategory = await _unitOfWork.CategoryRepository.GetById(CategoryId.Create(newParentCategoryId),true);

                    if (newParentCategory != null)
                    {
                        // Convert the Category into a ChildCategory and assign the parent
                        ChildCategory newChildCategory = ChildCategory.Create(category._name);
                        await newChildCategory.SetParentCategory(newParentCategory.Id);

                        // Add the new child category and remove the old category
                        await newParentCategory.AddChildCategory(newChildCategory);
                        await _unitOfWork.CategoryRepository.Delete(category);

                        var update = await _unitOfWork.CategoryRepository.Update(newParentCategory);

                        //await _unitOfWork.save();


                    }
                    else {
                        var newParebtChildCategory = await _unitOfWork.ChildCategoryRepository.GetById(ChildCategoryId.Create(newParentCategoryId), true);

                        // Convert the Category into a ChildCategory and assign the parent
                        ChildCategory newChildCategory = ChildCategory.Create(category._name);
                        //await newParebtChildCategory.SetParentCategory(newParentCategory.Id);
                        await newChildCategory.SetParentChildCategory(newParebtChildCategory.Id);

                        // Add the new child category and remove the old category
                        await newParebtChildCategory.AddChildCategory(newChildCategory);
                        await _unitOfWork.CategoryRepository.Delete(category);

                        var update = await _unitOfWork.ChildCategoryRepository.Update(newParebtChildCategory);
                    }
                }
                else
                {
                    // If no new parent, nothing happens for categories (they don't have a parent)
                    return Result.Error("Categories cannot be moved without a parent.");
                }
            }

            // Save changes in the unit of work
            await _unitOfWork.save();

            return Result.Success();
        }

    }


}
