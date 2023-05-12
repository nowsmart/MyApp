using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
  public class ProductRepository : Repository<Product>, IProductRepository
  {
    private ApplicationDBContext _context;
    public ProductRepository(ApplicationDBContext context):base(context)
    {
      _context = context;
    }//03334119255

    public void Update(Product product)
    {
      var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
      if (productDB != null)
      {
        productDB.Name = product.Name;
        productDB.Description = product.Description;
        productDB.Price = product.Price;
        if(product.ImageUrl != null)
        {
          productDB.ImageUrl=product.ImageUrl;

        }
      }
    }
  }
}
