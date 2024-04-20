﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah10.Models
{
    public class Product
    {

        public int   Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }


        [ForeignKey("Seller")]
        public int Sellerid { get; set; }

        [ForeignKey("Order")]
        public int Orderid { get; set; }

        public virtual Seller Seller { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<Product_Category> Product_Categories { get; set; } = new List<Product_Category>();
        public virtual ICollection<Cart_Product> Cart_Products { get; set; } = new List<Cart_Product>();

    }
}
