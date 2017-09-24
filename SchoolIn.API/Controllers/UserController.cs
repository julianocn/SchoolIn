using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolIn.API.EF;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolIn.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SchoolInContext _context;

        public UserController(SchoolInContext context)
        {
            _context = context;

		}

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

		[HttpGet("username/{Username}", Name = "GetUserByUsername")]
		public IActionResult GetByID(string username)
		{
			var item = _context.Users.FirstOrDefault(x => x.Username.Equals(username));
			if (item == null)
			{
				return NotFound();
			}

			return new ObjectResult(item);
		}


		[HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetByID(int id)
        {
            var item = _context.Users.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null) return BadRequest();

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, [FromBody] User user)
        {
            if (user == null || user.ID != id) return BadRequest();

            var item = _context.Users.FirstOrDefault(x => x.ID == id);
            if (item == null) return NotFound();

            item.Username = user.Username;
            item.Password = user.Password;
            item.Email = user.Email;

            _context.Users.Update(item);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var item = _context.Users.FirstOrDefault(x => x.ID == id);
            if (item == null) return NotFound();

            _context.Users.Remove(item);
            _context.SaveChanges();

            return new NoContentResult();

        }
    }
}
