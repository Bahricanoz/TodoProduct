using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.Interface;

namespace Todo.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try{
                string message = "[Request] Http" + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);
                
                await _next(context);
                watch.Stop();
                message = "[Response] Http" + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + "ms.";
                _loggerService.Write(message);
            }catch(Exception ex){
                watch.Stop();
                await HandleException(context,ex,watch);
            }
        }

        private Task HandleException(HttpContext context,Exception ex,Stopwatch watch){
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]   HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message : " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message },Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }
    
}