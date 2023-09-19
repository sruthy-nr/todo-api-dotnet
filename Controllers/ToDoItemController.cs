using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ToDoAPI
{
    [Route("api")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private static List<ToDoItem> todoList = new List<ToDoItem>();

        [HttpGet]
        public ActionResult <IEnumerable<ToDoItem>> Get()
        {
            return Ok(todoList);
        }

        // [HttpGet("{id}")]
        // public IActionResult Get(int id)
        // {
        //     var todoItem = todoList.FirstOrDefault(item => item.Id == id);
        //     if (todoItem == null)
        //         return NotFound();

        //     return Ok(todoItem);
        // }

        [HttpPost]
        public ActionResult <ToDoItem> Post(ToDoItem todoItem)
        {
            
            todoItem.Id = todoList.Count + 1;
            todoList.Add(todoItem);
            return Ok(todoList);
            // return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public ActionResult <ToDoItem> Put(int id, [FromBody] ToDoItem todoItem)
        {
            var existingItem = todoList?.FirstOrDefault(item => item.Id == id);
            if (existingItem == null)
                return NotFound();

            existingItem.Text = todoItem.Text;
            existingItem.Fromtime = todoItem.Fromtime;
            existingItem.Totime = todoItem.Totime;
            existingItem.Completed = todoItem.Completed;
            existingItem.Date = todoItem.Date;

            return Ok(todoList);
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id)
        {
            var existingItem = todoList?.FirstOrDefault(item => item.Id == id);
            if (existingItem == null)
                return NotFound();

            existingItem.Completed =!existingItem.Completed;
            return Ok(todoList);
        }
    }
}