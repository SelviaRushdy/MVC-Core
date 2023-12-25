using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core.Entities;
using MVC_Core.Models;
using MVC_Core.Services;

namespace MVC_Core.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;
        private ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductsRepository productsRepository
            , IMapper mapper
            , ICategoriesRepository categoriesRepository)
        {
            this.productsRepository = productsRepository;
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                ProductViewModel model = new ProductViewModel();
                var categoryList = mapper.Map<List<CategoriesDto>>(categoriesRepository.GetAllCategories());
                ViewBag.Categories = GetAllCategories(categoryList);
                model.CateogryID = categoryList.FirstOrDefault().ID;
                model.ProductsList = productsRepository.GetProductsByCategoryID(model.CateogryID).ToList();
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult Index(ProductViewModel productViewModel)
        {
            ProductViewModel model = new ProductViewModel();
            var categoryList = mapper.Map<List<CategoriesDto>>(categoriesRepository.GetAllCategories());
            ViewBag.Categories = GetAllCategories(categoryList);
            if (productViewModel.CateogryID == Guid.Empty)
                model.ProductsList = productsRepository.GetAllProducts().ToList();
            else
                model.ProductsList = productsRepository.GetProductsByCategoryID(productViewModel.CateogryID).ToList();
            return View(model);
        }
        public List<SelectListItem> GetAllCategories(List<CategoriesDto> categoryList)
        {
            return categoryList.Select(emp => new SelectListItem()
            {
                Text = emp.CatName,
                Value = emp.ID.ToString()
            }).ToList();
        }
        public IActionResult Details(Guid id)
        {
            var product = mapper.Map<ProductsDto>(productsRepository.GetProductByID(id));

            return View(product);
        }
        public IActionResult Edit(Guid id)
        {
            var product = mapper.Map<ProductsDto>(productsRepository.GetProductByID(id));
            var categoryList = mapper.Map<List<CategoriesDto>>(categoriesRepository.GetAllCategories());
            ViewBag.Categories = GetAllCategories(categoryList);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductsDto model)
        {
            var product = mapper.Map<Products>(model);
            var uploadResult= UploadFile(model.Image);

            if (uploadResult)
            {
                product.ImgURL = "/Images/"+ Path.GetFileName(model.Image.FileName);
            }
            productsRepository.UpdateProduct(product);
            var categoryList = mapper.Map<List<CategoriesDto>>(categoriesRepository.GetAllCategories());
            ViewBag.Categories = GetAllCategories(categoryList);
            ViewBag.SucessMessage = "Success!";
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            var product = productsRepository.GetProductByID(id);
            productsRepository.DeleteProduct(product);
            return RedirectToAction("Index");
        }
        private bool UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                var fileName = Path.GetFileName(ufile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ufile.CopyTo(fileStream);
                }
                return true;
            }
            return false;
        }

    }
}
