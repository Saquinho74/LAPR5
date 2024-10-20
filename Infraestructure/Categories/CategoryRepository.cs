using DDDNetCore.Domain.Categories;
using DDDNetCore.Infraestructure.Shared;

namespace DDDNetCore.Infraestructure.Categories
{
    public class CategoryRepository : BaseRepository<Category, CategoryId>, ICategoryRepository
    {
    
        public CategoryRepository(DddSample1DbContext context):base(context.Categories)
        {
           
        }


    }
}