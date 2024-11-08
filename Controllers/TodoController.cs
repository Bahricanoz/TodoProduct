using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Todo.Dtos;
using Todo.Interface;
using Todo.Mappers;

namespace Todo.Controllers
{
    [Route("todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly INotificationService _notificationService;
        public TodosController(ITodoRepository todoRepository,INotificationService notificationService)
        {
            _todoRepository = todoRepository;
            _notificationService = notificationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTodos(){
            try{
                var todos = await _todoRepository.GetAllTodos();
                return Ok(todos);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoDto todoDto){
            try{
                var todo = todoDto.MapToTodoItem();
                await _todoRepository.CreateTodo(todo);
                var jobId = BackgroundJob.Schedule(() => _notificationService.SendNotification("Todo Added"),TimeSpan.FromMinutes(1));
                BackgroundJob.ContinueJobWith(jobId,() => _notificationService.GenerateReport());
                return CreatedAtAction(nameof(GetTodoById), new {id = todo.Id}, todo);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodoById([FromRoute] int id){
            try{
                var todo = await _todoRepository.DeleteTodo(id);
                if(todo == null){
                    return NotFound("Todo Not Found");
                }
                BackgroundJob.Schedule(() => _notificationService.SendNotification("Todo Deleted"),TimeSpan.FromMinutes(1));
                return Ok("Todo deleted");
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }      
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById([FromRoute] int id){
            try{
                var todo = await _todoRepository.GetTodoById(id);
                if(todo == null){
                    return NotFound("Todo Not Found");
                }
                BackgroundJob.Schedule(() => _notificationService.SendNotification("Get")
                ,TimeSpan.FromMinutes(1));
                return Ok(todo);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id,[FromBody] TodoDto todoDto){
            try{
                var todo = await _todoRepository.UpdateTodo(id,todoDto.MapToTodoItem());
                if(todo == null){
                    return NotFound("Todo Not Found");
                }
                BackgroundJob.Schedule(() => _notificationService.SendNotification("Todo Updated"),TimeSpan.FromMinutes(1));
                return Ok("Update Todo");
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        } 
    }
}