using Microsoft.AspNetCore.Mvc;
using Module32MVCFinal2.Models.Db.Repositories;

namespace Module32MVCFinal2.Controllers
{
    public class LogsController : Controller
    {
        // ссылка на репозиторий
        private IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }
        
        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();

            return View(requests);
        }


    }
}
