using MinimalAPI.App.ToDo.Models.Entities;
using MinimalAPI.App.ToDo.Models.FakeDataGenerators;

namespace MinimalAPI.App.ToDo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly List<TodoItem> _items = new();
        private int _nextId = 1;

        public TodoItemService()
        {
            //_items = TodoItem_DataGenerator.GenerateSampleData();
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _items.ToList();
        }

        public IEnumerable<TodoItem> GetCompletedTodoItems()
        {
            return _items.Where(i => i.IsComplete).ToList();
        }

        public TodoItem? GetTodoItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public TodoItem CreateTodoItem(TodoItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }

        public bool UpdateTodoItem(int id, TodoItem item)
        {
            var existingItem = GetTodoItemById(id);
            if (existingItem == null)
                return false;

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.DueDate = item.DueDate;
            existingItem.IsComplete = item.IsComplete;
            return true;
        }

        public bool DeleteTodoItem(int id)
        {
            var item = GetTodoItemById(id);
            if (item == null)
                return false;
            _items.Remove(item);
            return true;
        }

        //private object data()
        //{
        //    var jsonData = "[
        //            {
        //                        'userId': 1,
        //                'id': 1,
        //                'title': 'delectus aut autem',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 2,
        //                'title': 'quis ut nam facilis et officia qui',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 3,
        //                'title': 'fugiat veniam minus',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 4,
        //                'title': 'et porro tempora',
        //                'completed': true
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 5,
        //                'title': 'laboriosam mollitia et enim quasi adipisci quia provident illum',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 6,
        //                'title': 'qui ullam ratione quibusdam voluptatem quia omnis',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 7,
        //                'title': 'illo expedita consequatur quia in',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 8,
        //                'title': 'quo adipisci enim quam ut ab',
        //                'completed': true
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 9,
        //                'title': 'molestiae perspiciatis ipsa',
        //                'completed': false
        //            },
        //            {
        //                        'userId': 1,
        //                'id': 10,
        //                'title': 'illo est ratione doloremque quia maiores aut',
        //                'completed': true
        //            }
        //        ]";
        //}
    }

    //https://jsonplaceholder.typicode.com/todos
}
