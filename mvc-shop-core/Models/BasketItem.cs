﻿namespace mvc_shop_core.Models
{
    public class BasketItem:BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}