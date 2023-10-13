using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public static class ViewModelProductLogic
    {
        public static ViewProduct ToViewDetails(this Product product)
        {
            ViewProduct viewproduct = new ViewProduct();
            viewproduct.ID= product.ID;
            viewproduct.Name = product.Name;
            viewproduct.Description = product.Description;
            viewproduct.Price = product.Price;
            viewproduct.Quantity = product.Quantity;
            viewproduct.ImagePaths = product.ProductAttachments.Select(PA => PA.Image).ToList();
            viewproduct.CategoryID = product.CategoryID;
            viewproduct.CategoryName = product.Category.Name;
            return viewproduct;
        }
        // CRUD Operations
        // Add from View To model
        public static Product ToAddModel(this EditViewProduct addproduct)
        {
            Product product = new Product();
            product.Name= addproduct.Name;
            product.Description= addproduct.Description;
            product.Price= addproduct.Price;
            product.Quantity= addproduct.Quantity;
            product.CategoryID= addproduct.CategoryID;
            List<ProductAttachment> productAttachments = new List<ProductAttachment>();

            if (addproduct.Images !=null)
            {
                foreach (IFormFile file in addproduct.Images)
                {
                    string Path = Directory.GetCurrentDirectory() + "/Content/Images/" + file.FileName;
                    FileStream fileStream = new FileStream(Path, FileMode.Create);
                    productAttachments.Add(new ProductAttachment()
                    {
                        Image = file.FileName
                    });
                    addproduct.ImagePaths.Add(file.FileName);
                    file.CopyTo(fileStream);
                    fileStream.Position = 0;

                }
            }
            product.ProductAttachments= productAttachments;
            return product;
        }
        // Edit To Model from View
        public static Product ToEditModel(this EditViewProduct addproduct)
        {
            Product product = ToAddModel(addproduct);
            product.ID= addproduct.ID;
            return product;
        }
        // Edit To View from Model
        public static ViewProduct ToEditView(this Product product)
        {
            ViewProduct viewProduct = new ViewProduct();
            viewProduct.ID= product.ID;
            viewProduct.Name = product.Name;
            viewProduct.Description= product.Description;
            viewProduct.Price= product.Price;
            viewProduct.Quantity= product.Quantity;
            viewProduct.CategoryID= product.CategoryID;
            viewProduct.CategoryName = product.Category.Name;
            viewProduct.ImagePaths=product.ProductAttachments.Select(x => x.Image).ToList();
            return viewProduct;
        } 

    }
}
