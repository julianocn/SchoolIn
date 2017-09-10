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
    public class PostController : Controller
    {
        private readonly SchoolInContext _context;

        public PostController(SchoolInContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();        
        }

        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult GetById(int id)
        {
            var item = _context.Posts.FirstOrDefault(x => x.ID == id);
            if (item == null) return NotFound();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Post post)
        {
            if (post == null) return BadRequest();
            _context.Posts.Add(post);
            _context.SaveChanges();

            return CreatedAtRoute("GetPost", new { id = post.ID }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Post post)
        {
            if (post == null || post.ID != id) return BadRequest();

            var item = _context.Posts.FirstOrDefault(x => x.ID == id);
            if (item == null) return NotFound();

            item.Title = post.Title;
            item.PostType = post.PostType;
            item.Link = post.Link;
            item.Description = post.Description;
            item.NumberOfRate1 = post.NumberOfRate1;
            item.NumberOfRate2 = post.NumberOfRate2;
            item.NumberOfRate3 = post.NumberOfRate3;
            item.NumberOfRate4 = post.NumberOfRate4;
            item.NumberOfRate5 = post.NumberOfRate5;
            _context.Update(item);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var item = _context.Posts.FirstOrDefault(x => x.ID == id);
            if (item == null) return NotFound();

            _context.Remove(item);
            _context.SaveChanges();

            return new NoContentResult();
        }

    }
}