using DDDNetCore.Domain.Products;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Products
{
    public class ProductRepository : BaseRepository<Product, ProductId>,IProductRepository
    {
        public ProductRepository(DddSample1DbContext context):base(context.Products)
        {
           
        }
    }
}