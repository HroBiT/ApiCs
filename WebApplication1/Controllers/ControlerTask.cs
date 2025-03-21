using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControlerTask : ControllerBase
    {
        private static readonly List<Tasks> task = new List<Tasks>();

        [HttpGet]
        public ActionResult<List<Tasks>> Get()
        {
            return Ok(task);
        }

        [HttpGet("{id}")]
        public ActionResult<Tasks> Get(int id)
        {
            var foundTask = task.FirstOrDefault(x => x.id == id);
            if (foundTask == null)
            {
                return NotFound();
            }
            return Ok(foundTask);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var foundTask = task.FirstOrDefault(x => x.id == id);
            if (foundTask == null)
            {
                return NotFound();
            }
            task.Remove(foundTask);
            return Ok();
        }

        [HttpPost]

        public ActionResult Post(Tasks tasks)
        {
            task.Add(tasks);
            return CreatedAtAction(nameof(Get), new { id = tasks.id }, tasks);
        }
    }
}
