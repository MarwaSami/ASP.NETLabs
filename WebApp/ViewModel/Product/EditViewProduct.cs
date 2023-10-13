using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EditViewProduct
{
    public int ID { get; set; }
    [Required(ErrorMessage = "Please Enter Valid Name")]
    [MaxLength(250, ErrorMessage = "You can't add Name More than 250 character")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please Enter Description")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Please Enter Valid Price")]
    public double Price { get; set; }
    [Required(ErrorMessage = "Please Enter Valid Quantity",AllowEmptyStrings =false)]
    [Column(TypeName = "number")] 
    public int Quantity { get; set; }
    [Display(Name = "Choose Category ")]
    public int CategoryID { get; set; }
    // For Image Attachment
    //[Required(ErrorMessage ="You must add An image")]
    public IFormFileCollection Images { get; set; }
    public List<string> ImagePaths { get; set; } = new List<string>();

}

