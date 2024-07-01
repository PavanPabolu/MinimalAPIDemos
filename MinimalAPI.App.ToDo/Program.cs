using MinimalAPI.App.ToDo.EndPoints;
using MinimalAPI.App.ToDo.Models.FakeDataGenerators;
using MinimalAPI.App.ToDo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//-------------------------------------------------------------

builder.Services.AddSingleton<ITodoItemService, TodoItemService>();

// Register the IHttpContextAccessor service
//builder.Services.AddHttpContextAccessor();
//-------------------------------------------------------------




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//-------------------------------------------------------------

// Seed the TodoItemService with sample data
var todoService = app.Services.GetRequiredService<ITodoItemService>();
var sampledata = TodoItem_DataGenerator.GenerateSampleData();  //must be "AddSingleton<ITodoItemService, TodoItemService>()"
foreach (var item in sampledata)
{
    todoService.CreateTodoItem(item);
}

app.MapTodoItemsEndpoints(); //using WebApi.MinimalAPI.ToDo.EndPoints;

//-------------------------------------------------------------

/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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
*/
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
