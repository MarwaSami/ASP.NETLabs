using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProductAttachmentManager : MainManager<ProductAttachment>
{
    public ProductAttachmentManager(MyDBContext myDB) : base(myDB) { }
    public ProductAttachment GetIDByImageName(string Image,int ProductID)
    {
        return GETAll().Where(attach => (attach.Image == Image) &&(attach.ProductID== ProductID)).FirstOrDefault();
    }

}

