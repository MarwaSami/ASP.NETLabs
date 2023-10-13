

using Microsoft.AspNetCore.Http;

public class ViewProduct
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryID { get; set; }
    // for Category Name
    public string CategoryName { get; set; }
    //  For Image path
    public List<string> ImagePaths { get; set; }
}