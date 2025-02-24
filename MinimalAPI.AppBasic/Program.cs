public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();



        var products = new Product[] {
            new(1, "Laptop", 999),
            new(2, "HeadPhones", 199),
            new(3, "SmartPhone", 699)
        };

        app.MapGet("api/products", () => products);

        //var myendpoints = app.MapGroup("/v1");
        //myendpoints.MapGet("/", () => "HEllo World!"); 
        //myendpoints.MapGet("/product/{id}", (int id) =>
        //                    products.FirstOrDefault(p => p.Id == id) is { } prod ? Results.Ok(prod) : Results.NotFound()
        //                    );

        //http://localhost:5095/api/products
        //http://localhost:5095/v1
        //http://localhost:5095/v1/product/2

        app.Run();
    }


    public record Product(int Id, string Name, int Price);

}