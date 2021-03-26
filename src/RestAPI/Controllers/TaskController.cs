using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taskService.ReadAllTasks());
            }
            catch (Exception e)

            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if ((id > 0))
                {
                    return Ok(_taskService.ReadTaskById(id));
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] Task task)
        {
            try
            {

                if (task.Description != null)
                {
                    return Ok(_taskService.CreateTask(task));
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            try
            {
                if (id != task.Id)
                {
                    return BadRequest($"Parameter ID({id}) and pet ID({task.Id}) have to be the same");
                }

                return Ok(_taskService.UpdateTask(id, task));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_taskService.DeleteTask(id));
                }


            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
            }
            return BadRequest();
        }
    }
}
