
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace WebApplication3.Middlewares
{
    /// <summary>
    /// Класс для обработки ошибок
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        /// <summary>
        /// Конструктор middleware 
        /// </summary>
        /// <param name="next">Делегат со всеми middleware</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        /// <summary>
        /// Метод для обработки ошибок или перехода к следующему middleware 
        /// </summary>
        /// <param name="context">Контекст http запроса</param>
        /// <returns>Асинхронная операция</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }            
            catch (Exception ex)
            {
                await Invoke(context, ex);
            }
        }

        /// <summary>
        /// Метод обработки ошибок в данном middleware
        /// </summary>
        /// <param name="context">Контекст http запроса</param>
        /// <param name="ex">Пойманная ошибка</param>
        /// <returns>Асинхронная операция</returns>
        public static Task Invoke(HttpContext context, Exception ex )
        {
            string errorType = ex.GetType().Name;
            string errorMassage = ex.Message;
            var statusCode = HttpStatusCode.BadRequest;
            switch (ex) 
            {
                case ArgumentNullException:
                    var argException = ex as ArgumentNullException;
                    errorType = argException.GetType().Name;
                    errorMassage = argException.Message;
                    break;
               /* case ValidationException:
                    var validException = ex as ValidationException;
                    errorType = validException.GetType().Name;
                    errorMassage = "";
                    foreach (var i in validException.Errors)
                    {
                        errorMassage +="\n"+ i.ErrorMessage;
                    }
                    break;*/
            }
            var message = new
            {
                ErrorType = errorType,
                Massege = errorMassage
            };
            var json = JsonSerializer.Serialize(message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                return context.Response.WriteAsync(json);
            
        }
    }
}

