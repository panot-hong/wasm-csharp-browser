using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OrderValidator
    {
        public static string? Validate(OrderContract order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (order.OrderItems.Any() && order.Total != order.OrderItems.Sum(oi => oi.SubTotal))
            {
                return $"order total is not equal to the sum of order items subtotal";
            }
            // TODO: perform check other cases

            return null;
        }
    }
}
