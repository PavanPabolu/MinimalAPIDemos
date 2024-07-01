namespace MinimalAPI.App.ToDo.Models.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }    
}
/*
Ref:
Realistic Data Generation in .NET With Bogus
https://code-maze.com/data-generation-bogus-dotnet/

GitHub - bchavez/Bogus: :card_index: A simple fake data …
https://github.com/bchavez/Bogus

Fakery - Generate Fake Mock Data for Testing
https://fakery.dev/

Easy generation of fake/dummy data in C# with Faker.Net
https://blog.elmah.io/easy-generation-of-fake-dummy-data-in-c-with-faker-net/

*/