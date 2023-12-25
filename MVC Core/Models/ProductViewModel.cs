using MVC_Core.Entities;

namespace MVC_Core.Models
{
    public class ProductViewModel
    {
        public List<Products> ProductsList { get; set; }
        public Guid CateogryID { get; set; }
    }
}
