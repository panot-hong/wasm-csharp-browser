using System;
using System.Collections.Generic;

namespace BLL
{
    public class OrderContract
    {
        public string Currency { get; set; }
        public decimal Total { get; set; }
        public string CustomerNotes { get; set; }
        public string Status { get; set; }
        // TODO: add deals, discounts, payment, etc.
        public ICollection<OrderItemContract> OrderItems { get; set; }
    }

    /// <summary>
    /// OrderItemContract DTO/Contract mainly used for creating a new order
    /// </summary>
    public class OrderItemContract
    {
        public Guid OrderItemID { get; set; }
        public Guid OrderID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Information provided by the customer about the preparation of the item.
        /// </summary>
        public string CustomerNotes { get; set; }

        public ICollection<OrderItemOptionContract> OrderItemOptions { get; set; }
    }

    /// <summary>
    /// OrderItemOptionContract DTO/Contract mainly used for creating a new order
    /// </summary>
    public class OrderItemOptionContract
    {
        public Guid OrderItemOptionID { get; set; }
        public string Name { get; set; }
        public string Ref { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        /// <summary>
        /// True if customer wish to Remove current option.
        /// </summary>
        public bool Removed { get; set; } = false;
        public Guid OrderItemID { get; set; }
    }

    public class UpdateOrderStatus
    {
        /// <summary>
        /// Order Status
        /// </summary>
        public string Status { get; set; }
    }
}
