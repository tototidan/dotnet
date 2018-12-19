using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using AppContext = WebApplication2.Models.AppContext;

namespace WebApplication2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AppContext _context;

        public CommentsController(AppContext context)
        {
            _context = context;
        }

        

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rating,comment,etablishmentID")] Comment pComment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pComment.userID = (int)HttpContext.Session.GetInt32("userID");
                    var t = _context.comment.Where(s => s.etablishmentID == pComment.etablishmentID && s.userID == (int)HttpContext.Session.GetInt32("userID")).FirstOrDefault();
                    if ( t != null)
                    {
                        t.rating = pComment.rating;
                        t.comment = pComment.comment;
                        _context.Update(t);
                    }
                    else
                    {
                        _context.Add(pComment);
                    }
                    await _context.SaveChangesAsync();
                 
                    return RedirectToAction("Details", "Etablishments", new { id = pComment.etablishmentID });
                }
                catch(Exception e)
                {
                   
                    return RedirectToAction("Details", "Etablishments", new { id = pComment.etablishmentID });
                }
            }
            return RedirectToAction("Details", "Etablishments", new { id = pComment.etablishmentID });


        }
       

         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("etablishmentID")] Comment pComment)
        {
            try
            {
                var comment = await _context.comment.Where(s => s.userID == HttpContext.Session.GetInt32("userID") && s.etablishmentID == pComment.etablishmentID).FirstAsync();
                _context.comment.Remove(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Etablishments", new { id = pComment.etablishmentID });
            }
            catch(Exception)
            {
                return RedirectToAction("Details", "Etablishments", new { id = pComment.etablishmentID });
            }
            
        }

        private bool CommentExists(int id)
        {
            return _context.comment.Any(e => e.etablishmentID == id);
        }
    }
}
