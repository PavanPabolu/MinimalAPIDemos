using MinimalAPI.App.ToDo.Models.Entities;

namespace MinimalAPI.App.ToDo.Models.FakeDataGenerators
{
    /// <summary>
    /// To generate sample data for 20 TodoItem records, with random titles, descriptions, due dates, and completion status.
    /// The Titles and Descriptions arrays contain sample text that can be used to populate the Title and Description properties of the TodoItem objects.
    /// The GenerateSampleData method takes an optional count parameter to specify the number of records to generate(default is 20).
    /// We can use this sample data generator to populate your TodoItemService with some initial data.
    /// </summary>
    public static class TodoItem_DataGenerator
    {
        private static readonly string[] Titles = {
        "Buy groceries", "Finish project report", "Clean the house", "Go for a run", "Call mom",
        "Learn a new programming language", "Organize the garage", "Attend the conference",
        "Prepare for the interview", "Write a blog post", "Finish the book", "Plan a vacation",
        "Volunteer at the local shelter", "Organize the closet", "Attend the team meeting",
        "Practice a musical instrument", "Prepare the presentation", "Declutter the office",
        "Attend the networking event", "Finish the online course"
    };

        private static readonly string[] Descriptions = {
        "Buy milk, eggs, bread, and other essentials",
        "Complete the project report for the client",
        "Vacuum, dust, and clean the entire house",
        "Go for a 5-mile run in the park",
        "Call mom and catch up on the latest news",
        "Learn a new programming language like Python or Rust",
        "Organize the garage and get rid of unwanted items",
        "Attend the annual industry conference in the city",
        "Prepare for the upcoming job interview next week",
        "Write a blog post about the latest technology trends",
        "Finish reading the book before the book club meeting",
        "Plan a summer vacation to a new destination",
        "Volunteer at the local animal shelter for a few hours",
        "Organize and declutter the closet in the bedroom",
        "Attend the weekly team meeting to discuss project updates",
        "Practice playing the guitar for 30 minutes every day",
        "Prepare the presentation slides for the upcoming meeting",
        "Declutter and organize the office space for better productivity",
        "Attend the networking event to connect with industry peers",
        "Complete the online course on data analysis before the deadline"
    };

        public static List<TodoItem> GenerateSampleData(int count = 20)
        {
            var items = new List<TodoItem>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var item = new TodoItem
                {
                    Id = i + 1,
                    Title = Titles[random.Next(Titles.Length)],
                    Description = Descriptions[random.Next(Descriptions.Length)],
                    DueDate = DateTime.Now.AddDays(random.Next(1, 31)),
                    IsComplete = random.NextDouble() < 0.5
                };
                items.Add(item);
            }

            return items;
        }
    }
}
