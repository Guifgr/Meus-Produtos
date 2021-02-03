using Meus_Produtos.Models;
using Meus_Produtos.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Produtos.Services.Implementations
{
    public class ProductServiceImplementation : IProductService
    {
        private MySqlContext _context;
        public ProductServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public void Delete(long Id)
        {
            var result = _context.Products.SingleOrDefault(p => p.Id.Equals(Id));
            if (result != null)
            {
                try
                {
                    _context.Products.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public Product FindById(long Id)
        {
            return _context.Products.SingleOrDefault(p => p.Id.Equals(Id));
        }
        public Product Update(Product product)
        {
            if (!Exists(product.Id)) return null;
            var result = _context.Products.SingleOrDefault(p => p.Id.Equals(product.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(product);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return product;
        }


        private bool Exists(long id)
        {
            return _context.Products.Any(p => p.Id.Equals(id));
        }
    }
}
