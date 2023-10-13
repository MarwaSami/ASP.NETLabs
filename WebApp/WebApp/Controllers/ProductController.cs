using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private UnityOfWork unityOfWork;
        private ProductManager productManager;
        private CategoryManager categoryManager;
        
        public ProductController(UnityOfWork _unityOfWork , ProductManager _productManager,
            CategoryManager _categoryManager)
        {
            unityOfWork = _unityOfWork;
            productManager = _productManager;
            categoryManager= _categoryManager;
        }

        public IActionResult Index()
        {
            List<ViewProduct> products =productManager.GetAllProducts();
            ViewData["products"]=products;
            return View();
        }
        public ViewResult GetDetails(int id )
        {
            
            ViewProduct product=productManager.GetById(id);
            if (product == null ||id==null)
            {
                return View("NotFound");
            }
            ViewData["product"]=product;
            return View(); 
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["categories"] = GetAllCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Add(EditViewProduct viewproduct)
        {
            if (ModelState.IsValid)
            {
                var temp = productManager.Add(viewproduct);
                unityOfWork.commit();
                ViewData["msq"] = "Succeessfully added";
                return Redirect("Index");
            }
            else
            {
                ViewData["categories"] = GetAllCategories();
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            productManager.Remove(id);
            unityOfWork.commit();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewProduct product = productManager.GetById(id);
            ViewData["categories"] = GetAllCategories();
            ViewData["product"]=product;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(EditViewProduct editedproduct,string[] OlddeletedImages)
        {
            if(ModelState.IsValid)
            {
                productManager.Edit(editedproduct);
                unityOfWork.commit();
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        public  List<SelectListItem> GetAllCategories()
        {
            List<SelectListItem> categories = categoryManager.GETAll().Select(C => new SelectListItem()
            {
                Value = C.ID.ToString(),
                Text = C.Name,
            }).ToList();
            return categories;
        }
    }
}
