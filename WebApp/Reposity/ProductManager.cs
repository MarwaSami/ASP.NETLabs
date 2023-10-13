using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

public class ProductManager : MainManager<Product>
{
    private MyDBContext myDB;
    public ProductManager(MyDBContext myDB) : base(myDB) { }
    public List<ViewProduct> GetAllProducts()
    {
        return GETAll().Select(P => P.ToViewDetails()).ToList();
    }
    public ViewProduct GetById(int id)
    {
        return GETAll().Where(Product => Product.ID == id).FirstOrDefault().ToViewDetails();
    }
    public EntityEntry Add(EditViewProduct product)
    {
        return base.Add(product.ToAddModel());
    }
    public void Remove(int id)
    {
        Product product = GETAll().FirstOrDefault(a => a.ID == id);
        Delete(product);
    }

    public void Edit(EditViewProduct newviewproduct)
    {
        Product newproduct = newviewproduct.ToEditModel();
        Product oldproduct = GETAll().FirstOrDefault(a => a.ID == newproduct.ID);
        oldproduct.Name = newproduct.Name;
        oldproduct.Description = newproduct.Description;
        oldproduct.CategoryID = newproduct.CategoryID;
        oldproduct.Price = newproduct.Price;
        oldproduct.Quantity = newproduct.Quantity;
        oldproduct.ProductAttachments = MappingProductAttachments(oldproduct,newproduct);

    }
    public ICollection<ProductAttachment> MappingProductAttachments(Product oldProduct, Product newProduct)
    {
        if(newProduct.ProductAttachments.Count>0)
        {
            foreach (var attachment in newProduct.ProductAttachments)
            {
                oldProduct.ProductAttachments.Add(attachment);
            }
        }
        return oldProduct.ProductAttachments;
    }
}

