using Microsoft.AspNetCore.Mvc;
using zad1.Models;
using zad1.Extensions;

namespace zad1.Controllers
{
    public class TodoController : Controller
    {
        private const string SessionKey = "TodoList";

        // Pobiera listę zadań z sesji lub inicjalizuje pustą listę
        private List<TodoItem> GetTodoListFromSession()
        {
            var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>(SessionKey);
            return todoList ?? new List<TodoItem>();
        }

        // Zapisuje listę zadań w sesji
        private void SaveTodoListToSession(List<TodoItem> todoList)
        {
            HttpContext.Session.SetObjectAsJson(SessionKey, todoList);
        }

        public IActionResult Index()
        {
            var todoList = GetTodoListFromSession();
            return View(todoList);
        }

        [HttpPost]
        public IActionResult Add(string task)
        {
            if (!string.IsNullOrEmpty(task))
            {
                var todoList = GetTodoListFromSession();
                int nextId = todoList.Any() ? todoList.Max(t => t.Id) + 1 : 1;
                todoList.Add(new TodoItem { Id = nextId, Task = task, IsCompleted = false });
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            var todoList = GetTodoListFromSession();
            var item = todoList.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = true;
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var todoList = GetTodoListFromSession();
            var item = todoList.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                todoList.Remove(item);
                SaveTodoListToSession(todoList);
            }
            return RedirectToAction("Index");
        }
    }
}
