using Azure.Core;
using Module32MVCFinal2.Models.Db.Entities;
using Module32MVCFinal2.Models.Db.Repositories;
using Module32MVCFinal2.Models;
using static System.Net.WebRequestMethods;

namespace Module32MVCFinal2.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IRequestRepository _requestRepository;


        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IBlogRepository blogRepository, IRequestRepository requestRepository)
        {
            _next = next;
            _requestRepository= requestRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {

            // Добавим создание нового пользователя
            var newLog = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"New request to http://{context.Request.Host.Value + context.Request.Path}"
            };

        // Добавим в базу
            //await _blogRepository.AddUser(newUser);
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
