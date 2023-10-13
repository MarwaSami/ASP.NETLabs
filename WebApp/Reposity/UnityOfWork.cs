using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnityOfWork
{
    private MyDBContext dBContext;
    public UnityOfWork(MyDBContext _dBContext)
    {
        dBContext = _dBContext;
    }
    public void commit()
    {
        dBContext.SaveChanges();
    }
}

