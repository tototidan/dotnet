using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
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
        public async Task<IActionResult> Create([Bind("rating,comment,etablishmentID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                
                comment.userID = 1;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return Content("ok");
            }
            ViewData["etablishmentID"] = new SelectList(_context.etablishment, "etablishmentID", "description", comment.etablishmentID);
            ViewData["userID"] = new SelectList(_context.user, "userID", "Login", comment.userID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["etablishmentID"] = new SelectList(_context.etablishment, "etablishmentID", "description", comment.etablishmentID);
            ViewData["userID"] = new SelectList(_context.user, "userID", "Login", comment.userID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("commentID,rating,comment,userID,etablishmentID")] Comment comment)
        {
            if (id != comment.etablishmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.etablishmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction();
            }
            ViewData["etablishmentID"] = new SelectList(_context.etablishment, "etablishmentID", "description", comment.etablishmentID);
            ViewData["userID"] = new SelectList(_context.user, "userID", "Login", comment.userID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.comment
                .Include(c => c.etablishment)
                .Include(c => c.user)
                .FirstOrDefaultAsync(m => m.etablishmentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.comment.FindAsync(id);
            _context.comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction();
        }

        private bool CommentExists(int id)
        {
            return _context.comment.Any(e => e.etablishmentID == id);
        }
    }
}
