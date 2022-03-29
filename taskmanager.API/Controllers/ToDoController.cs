using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using taskmanager.API.DATA.Repositories;
using taskmanager.API.Models;
using taskmanager.API.Models.InputMOdels;

namespace taskmanager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private IToDoRepository toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }



        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {

            var todos = toDoRepository.get();

            return Ok(todos);
        }

        // GET api/<ToDoController>/5 {id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
         
            var todo = toDoRepository.get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ActionResult Post([FromBody] ToDoDTO newTodo )
        {

            var todo = new ToDo(newTodo.Name, newTodo.Description);

            toDoRepository.Add(todo);

            return Created("", todo );
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ToDoDTO todoUpdate)
        {
            var todoExistent = toDoRepository.get(id);

            if (todoExistent == null)
            
                return NotFound();
            

            todoExistent.UpdateToDo(todoUpdate.Name, todoUpdate.Description, todoUpdate.IsCompleted);

            toDoRepository.Update(id, todoExistent);

            return Ok(todoExistent);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todoExistent = toDoRepository.get(id);


            if (todoExistent == null)

                return NotFound();

               toDoRepository.delete(id);

            return NoContent();
        }
    }
}
