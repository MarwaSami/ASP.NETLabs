using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CategoryManager : MainManager<Category>
{
    public CategoryManager(MyDBContext myDB) : base(myDB) { }

    public Category GetById(int id)
    {
        return GETAll().Where(Category => Category.ID == id).FirstOrDefault();
    }
    public void Remove(int id)
    {
        Category category = GetById(id);
        Delete(category);
    }

    public void Edit(Category newcategory, int id)
    {
        Category oldcategory=GetById(id);
        oldcategory.Name = newcategory.Name;
    }
}

