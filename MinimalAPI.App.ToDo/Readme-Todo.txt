



In this example:
* ITodoItemService is an interface that defines the contract for the Todo Item service, 
	including methods for getting all items, completed items, creating, updating, and deleting items.
* TodoItemService is a concrete implementation of ITodoItemService that uses an in-memory list to 
	store the Todo Items. It provides the implementation for each of the methods defined in the interface.
* TodoItem is a simple class that represents a single Todo Item, with properties for the ID, title, description, 
	due date, and completion status.

We can inject an instance of TodoItemService into your minimal API endpoints using dependency injection, like this:
app.Services.AddScoped<ITodoItemService, TodoItemService>();

This will ensure that a new instance of TodoItemService is created for each request, and it will be automatically 
injected into your endpoint methods that require an ITodoItemService parameter.



-------------------------------------------------------------------------------
Fake data Generators:
-------------------------------------------------------------------------------
{JSON} Placeholder - Free fake and reliable API for testing and prototyping.
https://jsonplaceholder.typicode.com/todos

Realistic Data Generation in .NET With Bogus
https://code-maze.com/data-generation-bogus-dotnet/

GitHub - bchavez/Bogus: :card_index: A simple fake data …
https://github.com/bchavez/Bogus

Fakery - Generate Fake Mock Data for Testing
https://fakery.dev/

Easy generation of fake/dummy data in C# with Faker.Net
https://blog.elmah.io/easy-generation-of-fake-dummy-data-in-c-with-faker-net/

-------------------------------------------------------------------------------