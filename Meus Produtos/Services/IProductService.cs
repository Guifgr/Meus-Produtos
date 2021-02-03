using Meus_Produtos.Models;
using System.Collections.Generic;

namespace Meus_Produtos.Services
{
    public interface IProductService
    {
        Product Create(Product product);
        Product FindById(long Id);
        List<Product> FindAll();
        Product Update(Product product);
        void Delete(long Id);
    }
}
