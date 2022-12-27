// See https://aka.ms/new-console-template for more information
using BLL;

string? validateResult = OrderValidator.Validate(
    new OrderContract { Total = 10, OrderItems = new List<OrderItemContract> { 
        new OrderItemContract { SubTotal = 6 }, new OrderItemContract { SubTotal = 5 } 
    }});
Console.WriteLine(validateResult);