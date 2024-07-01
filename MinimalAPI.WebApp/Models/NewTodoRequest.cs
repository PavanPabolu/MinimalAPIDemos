using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.WebApp.Models
{
    //public record struct NewTodoRequest([FromForm] string Name, [FromForm] Visibility Visibility, IFormFile? Attachment);
    public record struct NewTodoRequest([FromForm] string Name,  IFormFile? Attachment);
}
