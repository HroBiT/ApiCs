using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controler : ControllerBase
    {
        private static readonly List<user> users = [];

        [HttpGet]

        public ActionResult<List<user>> Get()
        {
            return Ok(users);
        }


        [HttpGet("{id}")]

        public ActionResult<user> Get(int id)
        {
            var user = users.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]

        public ActionResult Post(user user)
        {
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, user user)
        {
            var existingUser = users.FirstOrDefault(x => x.id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.name = user.name;
            return Ok();
        }
    }

    
}
