﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter product description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please enter product Manufacturer")]
        public string MANUFACTURER { get; set; }
        [Required(ErrorMessage = "Please enter product price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter product stock")]
        public int quantity { get; set; }
        

        [Required(ErrorMessage="please enter the product image URL")]
        
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Please enter product category")]
        public int CategoryId { get; set; }

       /* [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }*/
    }
}
