using Microsoft.AspNetCore.Mvc;
using Module32MVCFinal2.Models.Db.Repositories;
using Module32MVCFinal2.Models.Db.Entities;

namespace Module32MVCFinal2.Controllers
{
    public class UsersController : Controller
    {
        private IBlogRepository _blogRepository;
        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
       
        public async Task<IActionResult> Index()
        {
            var authors = await _blogRepository.GetUsers();
            return View(authors);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            
            // Добавим в базу
            await _blogRepository.AddUser(user);
            // Выведем результат
            Console.WriteLine($"User with id {user.Id}, named {user.FirstName} was successfully added on {user.JoinDate}");
            return View(user);
        }
    }
}
