using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssigneeController : Controller
    {
        private readonly IAssigneeService _assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
            _assigneeService = assigneeService;
        }
        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            try
            {
                if((id > 0))
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

        [HttpGet]
        public ActionResult Get()
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

        [HttpPost]
        public ActionResult Post([FromBody] String name)
        {
            try
            {
                if (name != null)
                {
                    return Ok(_assigneeService.CreateAssignee(name));
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Assignee assignee)
        {
            try
            {
                if (id != assignee.Id)
                {
                    return BadRequest();
                }

                return Ok(_assigneeService.UpdateAssignee(id));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}