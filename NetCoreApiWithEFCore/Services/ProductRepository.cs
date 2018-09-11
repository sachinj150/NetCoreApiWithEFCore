using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Data;
using Module1.Models;

namespace Module1.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext productsDbContext;
        public ProductRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }
        public IEnumerable<Product> GetProducts(string searchProduct)
        {
            return productsDbContext.Products.Where(a => a.ProductName.StartsWith(searchProduct));
        }

        public Product GetProduct(int id)
        {
            return productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);

        }

        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
