using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Models;

namespace Module1.Services
{
    public interface IProduct
    {
        //Crud Operations

        IEnumerable<Product> GetProducts(string searchProduct);
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
