using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Primitives;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);


//--------------------------------------------------
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.IncludeFields = true;
});
//--------------------------------------------------


// Add services to the container.
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
//app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/{controller}/{action}/{id?}",
//    defaults: new { controller = "Person", action = "GetPersons" });




var summaries = new[]{"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

//---------------------------

app.MapGet("/test1", () =>
{
    return "test-1 method called.";
});

app.MapGet("/test2", () => "test-2 method called.");

app.MapGet("/test3", () => new { message = "test-3 method called." }); //JSON


app.MapGet("/test4", context =>
{

    return Task.Run(() => context.Response.Redirect("/test-3")); //"/Account/Login"
});

app.MapGet("/test5", (HttpContext context) =>
{
    return context.Response.WriteAsJsonAsync(new { message = "Hello World!" }); //JSON
});

app.MapGet("/test6", async (HttpResponse response) =>
{

    await response.WriteAsync("test-6 method called.");
});

app.MapGet("/test7", async (HttpResponse response) =>
{

    await response.WriteAsJsonAsync("test-7 method called.");
});


app.MapGet("/test8", () => Results.Json(new { Id = 1, Name = "john Smith" },
                                        new JsonSerializerOptions(JsonSerializerDefaults.Web)
                                        {
                                            WriteIndented = true,
                                            PropertyNameCaseInsensitive = true
                                        }));


app.MapGet("/test9", () => Results.Ok(new { message = "Hello World!" })).Produces<string>();

app.MapGet("/test10", () => TypedResults.Ok(new { message = "Hello World!" })); //JSON


app.MapGet("/sample-badrequest-1", () =>
{

    return Results.BadRequest("/sample-badrequest-1 called.");
});

app.MapGet("/sample-badrequest-2", () =>
{

    return Results.BadRequest(new { message = "/sample-badrequest-1 called." });
});

app.MapGet("/GetPersona{id:int}", (int id) =>
{

    return id <= 0 ? Results.BadRequest() : Results.Ok(new { id = id, name = "john" });
});

//stream
app.MapGet("/externalapi", async () =>
{

    var url = "https://jsonplaceholder.typicode.com/todos";
    var client = new HttpClient();
    var stream = await client.GetStreamAsync(url);

    return Results.Stream(stream, "application/json");
});







//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0#bind-arrays-and-string-values-from-headers-and-query-strings
// Bind query string values to a primitive type array.
// GET  /tags?q=1&q=2&q=3
app.MapGet("/tags", (int[] q) =>
                      $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");

// Bind to a string array.
// GET /tags2?names=john&names=jack&names=jane
app.MapGet("/tags2", (string[] names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

// Bind to StringValues.
// GET /tags3?names=john&names=jack&names=jane
app.MapGet("/tags3", (StringValues names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");




app.MapGet("/exception", () =>
{
    throw new InvalidOperationException("Sample Exception");
});

//app.MapFallbackToFile("index.html");

app.UseExceptionHandler(exceptionHAndlerapp =>
    exceptionHAndlerapp.Run(async context =>
    {
        await Results.Problem().ExecuteAsync(context);
    })
);










app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
