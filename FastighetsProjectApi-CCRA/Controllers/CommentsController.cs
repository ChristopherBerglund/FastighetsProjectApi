using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FastighetsProjectApi_CCRA.Areas.Identity.Data;
using FastighetsProjectApi_CCRA.DTOmodel;
using FastighetsProjectApi_CCRA.HelpClasses;
using FastighetsProjectApi_CCRA.Repository;
using FastighetsProjectApi_CCRA.Contracs;

namespace FastighetsProjectApi_CCRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly SignInManager<FastighetsProjectApi_CCRAUser> _signInManager;
        private readonly UserManager<FastighetsProjectApi_CCRAUser> _userManager;
        private readonly ICommentRepository _commentRepository;

        public CommentsController(DbContext context, SignInManager<FastighetsProjectApi_CCRAUser> signInManager, UserManager<FastighetsProjectApi_CCRAUser> userManager, ICommentRepository commentRepository)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _commentRepository = commentRepository;
        }




        // GET: api/Comments/5
        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<ActionResult<List<Comment>>> GetComments(int id)
        //{
        //    var comments = await _context.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).Take(10).ToListAsync();


        //    if (comments == null)
        //    {
        //        return NotFound();
        //    }

        //    return comments;
        //}


        // GET: api/Comments (Skip take)
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsTS(int id, [FromQuery] SkipTakeParameters skipTakeParameters)
        {

            var comments =  _commentRepository.GetCommentsTS(id, skipTakeParameters);

            return Ok(comments);
        }

        //get api/ByUser/USERNAME
        [HttpGet("byuser/{username}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByUserTS(string username, [FromQuery] SkipTakeParameters skipTakeParameters)
        {
            var comments = _commentRepository.GetCommentsByUserTS(username, skipTakeParameters);
            return Ok(comments);
        }


        //// PUT: api/Comments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutComment(int id, Comment comment)
        //{
        //    if (id != comment.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(comment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CommentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> PostComment([FromBody]Comment comment)
        {
            

            _context.Comments.Add(comment);
            comment.UserName = User.Identity.Name;

            await _context.SaveChangesAsync();

            var content = new CommentDTO(comment);

           /////////////////////////////////
           

            _context.Users.FirstOrDefault(a => a.UserName == comment.UserName).Comments++;
            _context.SaveChanges();
            /////////////////////////////////

            return Created("https//localhost:5001/api/comments", content);

        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            //////////////////////////////////
             //var username = User.Identity.Name;

            _context.Users.FirstOrDefault(a => a.UserName == comment.UserName).Comments--;
            _context.SaveChanges();
            //////////////////////////////////
            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.id == id);
        }
    }
}
