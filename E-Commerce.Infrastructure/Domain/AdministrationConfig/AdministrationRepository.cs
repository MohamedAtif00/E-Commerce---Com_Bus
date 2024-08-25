using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.AdministrationConfig
{
    public class AdministrationRepository : GenericRepository<Administration, AdministrationId>, IAdministrationRepository
    {
        public AdministrationRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Administration?> GetAdministration()
        {
            // Retrieve the administration entity; adjust the query as needed based on your requirements
            return await _context.administrations.SingleOrDefaultAsync();
        }

        public async Task<List<Product>> GetOrdersProductForCategory(CategoryId categoryId)
        {
            // Step 1: Retrieve products for the specified category
            var productsInCategory = await _context.products
                .Where(p => p.categoryId == categoryId)
                .ToListAsync();

            // Step 2: Retrieve orders that contain these products
            var productIds = productsInCategory.Select(p => p.Id).ToList();

            var ordersContainingProducts = await _context.orders
                .Where(o => o._orderItems.Any(oi => productIds.Contains(oi._productId)))
                .ToListAsync();

            // Step 3: Create a dictionary to track the count of each product in the orders
            var productQuantityMap = new Dictionary<ProductId, int>();

            foreach (var order in ordersContainingProducts)
            {
                foreach (var orderItem in order._orderItems)
                {
                    if (productIds.Contains(orderItem._productId))
                    {
                        if (productQuantityMap.ContainsKey(orderItem._productId))
                        {
                            productQuantityMap[orderItem._productId] += orderItem._quantity; // Assuming you have Quantity in OrderItem
                        }
                        else
                        {
                            productQuantityMap[orderItem._productId] = orderItem._quantity;
                        }
                    }
                }
            }

            // Step 4: Create a list with products duplicated according to their quantities
            var resultProducts = new List<Product>();

            foreach (var product in productsInCategory)
            {
                if (productQuantityMap.TryGetValue(product.Id, out int quantity))
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        resultProducts.Add(product);
                    }
                }
            }

            return resultProducts;
        }


    }

}
