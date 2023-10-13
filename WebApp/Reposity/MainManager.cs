using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public  class MainManager<T> where T : class
{
    private MyDBContext dbContext;
    private DbSet<T> dbSet;
    public MainManager(MyDBContext _dbContext)
    {
        dbContext = _dbContext;
        dbSet = dbContext.Set<T>();
    }
    public IQueryable<T> GETAll()
    {
        return dbSet.AsQueryable();
    }
    public EntityEntry<T> Add(T item)
    {
       return dbSet.Add(item);
    }
    public void Update(T elem)
    {
        dbSet.Update(elem);
    }
    public void Delete(T elem)
    {
        dbSet.Remove(elem);
    }

}

