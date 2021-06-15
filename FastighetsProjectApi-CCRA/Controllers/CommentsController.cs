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

namespace FastighetsProjectApi_CCRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly SignInManager<FastighetsProjectApi_CCRAUser> _signInManager;
        private readonly UserManager<FastighetsProjectApi_CCRAUser> _userManager;

        public CommentsController(DbContext context, SignInManager<FastighetsProjectApi_CCRAUser> signInManager, UserManager<FastighetsProjectApi_CCRAUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentSkipTake(int id, int skip, int take)
        {
            
            //if (skip == null &&  take == null)
            //{ 
            //    //var commentlist = await  GetCommentSkipTake(id, skip, take);
            //    //return Ok(commentlist);
            //    return Ok(GetCommentSkipTake(id, skip, take));
            //}
            //else {
            //    var result = await GetCommentSkipTake(id, skip, take);

            //    var commentlist = await GetCommentSkipTake(id, skip, take);

            //    return Ok(commentlist);
            //}

            //return await _context.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).Skip(skip).Take(take).ToListAsync();
        }

        //get api/ByUser/USERNAME
        [HttpGet("ByUser/{username}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comment>>> GetUserComments (string username)
        {
            return await _context.Comments.Where(a => a.UserName == username).Take(10).OrderByDescending(c => c.CreatedOn).ToListAsync();       
        }
        //get api/ByUser/USERNAME skip & take
        [HttpGet("ByUser/{username}/comment")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comment>>> GetUserComments(string username, int skip, int take)
        {
            if(take > 100){ take = 100; }
            if (take <= 0) { take = 10; }

            return await _context.Comments.Where(a => a.UserName == username).Skip(skip).Take(take).OrderByDescending(c => c.CreatedOn).ToListAsync();
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
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            comment.UserName = User.Identity.Name.ToString();

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();

            var content = new CommentDTO(comment);

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

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.id == id);
        }
    }
}
