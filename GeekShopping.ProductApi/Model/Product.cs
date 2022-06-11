﻿using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
        [Column("Price")]
        [Required]
        [Range(0,10000)]
        public decimal Price { get; set; }

        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("CategoryName")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("ImageUrl")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

    }
}
