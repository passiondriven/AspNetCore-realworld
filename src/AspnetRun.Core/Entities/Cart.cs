﻿using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Cart : Entity
    {        
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int productId, int quantity = 1, string color = "Black", decimal unitPrice = 0)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                Items.Add(
                    new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Color = color,
                        UnitPrice = unitPrice,
                        TotalPrice = quantity * unitPrice
                    });
            }
        }

        public void RemoveItem(int cartItemId)
        {
            var removedItem = Items.FirstOrDefault(x => x.Id == cartItemId);
            if (removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }

        public void RemoveItemWithProduct(int productId)
        {
            var removedItem = Items.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }

        public void ClearItems()
        {
            Items.Clear();       
        }
    }
}
