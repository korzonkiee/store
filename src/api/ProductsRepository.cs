using System.Collections.Generic;
using System.Linq;
using core.dtos;

namespace api
{
    public static class ProductsRepository
    {
        public static List<ProductDTO> GetProducts()
        {
            var list = new List<ProductDTO>();

            for (int i = 0; i < 100; i++)
            {
                var product = new ProductDTO()
                {
                    Id = i,
                    Name = $"Product_{i}"
                };

                list.Add(product);
            }

            return list;
        }

        public static ProductDTO GetProductById(int id)
        {
            var products = GetProducts();
            return products.Where(p => p.Id == id)
                .FirstOrDefault();
        }
    }
}