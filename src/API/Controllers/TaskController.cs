using System;
using System.Collections.Generic;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using Nest;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public ActionResult<Task> Get([FromQuery]int id)
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
        
        [HttpPost]
        public ActionResult <Task>Post([FromBody]Task task)
        {
            try
            {
                if (task.Description == null)
                {
                    return StatusCode(100, $"description cannot be null" );
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return task;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            try
            {
                return Ok(_taskService.ReadAllTasks());
            }
            catch (Exception e)

            {
                return BadRequest($"cannot read all workSpacePosters");
            }
        }


        [HttpDelete]
        public ActionResult  Delete(int id)
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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Task task)
        {
            try
            {
                if (id != task.Id)
                {
                    return BadRequest($"Parameter ID({id}) and pet ID({task.Id}) have to be the same");
                }

                return Ok(_taskService.UpdateTask(id, DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}