using MVC_Core.Entities;

namespace MVC_Core.Services
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductByID(Guid productId);
        IEnumerable<Products> GetProductsByCategoryID(Guid categoryId);
        bool ProductExists(Guid categoryrId);
        public void AddProduct(Products product);
        public void UpdateProduct(Products product);
        public void DeleteProduct(Products product);
        public bool Save();
        
    }
}
