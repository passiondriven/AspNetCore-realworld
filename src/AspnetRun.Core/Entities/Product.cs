﻿using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Core.Entities
{
    public class Product : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public double Star { get; set; }

        // n-1 relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // 1-n relationships
        public List<Specification> Specifications { get; set; } = new List<Specification>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        // n-n relationships
        public List<ProductWishlist> ProductWishlists { get; set; } = new List<ProductWishlist>();
        public List<ProductCompare> ProductCompares { get; set; } = new List<ProductCompare>();
        public List<ProductList> ProductLists { get; set; } = new List<ProductList>();
        public List<ProductRelatedProduct> ProductRelatedProducts { get; set; } = new List<ProductRelatedProduct>();


        public static Product Create(int productId, int categoryId, string name, decimal unitPrice = 0, short? unitsInStock = null)
        {
            var product = new Product
            {
                Id = productId,
                CategoryId = categoryId,
                Name = name,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock
            };
            return product;
        }

    }
}
