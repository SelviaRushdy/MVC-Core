using MVC_Core.Entities;

namespace MVC_Core.Services
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
