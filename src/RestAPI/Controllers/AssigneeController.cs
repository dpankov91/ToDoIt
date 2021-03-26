using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssigneeService _assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
            _assigneeService = assigneeService;
        }
        // GET: api/<AssigneeController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok((_assigneeService.ReadAll()));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<AssigneeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if ((id > 0))
                {
                    return Ok((_assigneeService.ReadById(id)));
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<AssigneeController>
        [HttpPost]
        public IActionResult Post([FromBody] Assignee assignee)
        {
            try
            {
                if (assignee != null)
                {
                    return Ok(_assigneeService.CreateAssignee(assignee));
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<AssigneeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Assignee assignee)
        {
            try
            {
                if (id != assignee.Id)
                {
                    return BadRequest();
                }

                return Ok(_assigneeService.UpdateAssignee(id, assignee));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<AssigneeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_assigneeService.DeleteAssignee(id));
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
