using BLL;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

Console.WriteLine("Hello, Browser!");

public partial class MyWasm
{
    [JSExport]
    [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(String, JsonSerializerOptions)")]
    internal static string ValidateOrder(string serializedOrder)
    {
        var order = JsonSerializer.Deserialize<OrderContract>(serializedOrder, serializeOptions);
        var validateOutput = OrderValidator.Validate(order);
        Console.WriteLine(validateOutput);
        return validateOutput;
    }

    private static readonly JsonSerializerOptions serializeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  
        WriteIndented = true
    };
}
