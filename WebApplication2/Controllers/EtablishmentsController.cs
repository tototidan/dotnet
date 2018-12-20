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
    public class EtablishmentsController : Controller
    {
        private readonly AppContext _context;
        private const int admin_id = 1;

        public EtablishmentsController(AppContext context)
        {
            
            _context = context;
        }

        //TODO: Create index with the list of etablishment of the user
        // GET: Etablishments
        public async Task<IActionResult> Index()
        {
            var appContext = _context.etablishment.Include(e => e.etablishmentType).
                Where(s=> s.userEtablishment.userID == HttpContext.Session.GetInt32("userID"));
            return View(await appContext.ToListAsync());
        }

        //TODO: Create index with the list of etablishment of the user
        // GET: Etablishments
        public async Task<IActionResult> IndexAll()
        {
            var appContext = _context.etablishment.Include(e => e.etablishmentType).Where(s=> s.etablishmentID > 0);
            return View("index",await appContext.ToListAsync());
        }



        // GET: Etablishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                
                return RedirectToAction("index", "home");
            }
            try
            {
                var etablishment = await _context.etablishment
               .Include(e => e.etablishmentType).Include(e => e.userEtablishment)
               .FirstOrDefaultAsync(m => m.etablishmentID == id);
                if (etablishment == null)
                {
                    
                    return RedirectToAction("index", "home");
                }
                try
                {
                    var t = _context.comment.Where(s => s.etablishmentID == id).ToList();
                  
                    ViewData["comment"] = t;
                }
                catch(Exception e)
                {
                    
                }
                
                return View(etablishment);
            }
            catch(Exception e)
            {
                
                return RedirectToAction("index", "home");
            }
           
        }

        // GET: Etablishments/Create
        public IActionResult Create()
        {
            
            ViewData["etablishmenttypeID"] = new SelectList(_context.etablishmentType, "etablishmentTypeID", "type");
            return View();
        }

        // POST: Etablishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,description,street,postalcode,phonenumber,email,etablishmenttypeID")] Etablishment etablishment)
        {
            if (ModelState.IsValid && HttpContext.Session.GetInt32("userID") != null)
            {  
                try
                {
                    _context.Add(etablishment);
                    _context.SaveChanges();
                    UserEtablishment u = new UserEtablishment();
                    u.etablishmentID = etablishment.etablishmentID;
                    u.userID = (int)HttpContext.Session.GetInt32("userID");
                    _context.Add(u);
                    _context.SaveChanges();
                    ViewData["msg"] = "salut";
                    return RedirectToAction("index","home");
                }
                catch(Exception e)
                {

                    return View("index", "home");
                    //TODO: add viewdata qui display un message d'erreur comme quoi y'a un problème
                }
            }
            ViewData["etablishmenttypeID"] = new SelectList(_context.etablishmentType, "etablishmentTypeID", "type", etablishment.etablishmenttypeID);
            return View(etablishment);
        }

        // GET: Etablishments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index", "home");
            }

            try
            {
                var t = _context.etablishment.Where(s => s.userEtablishment.etablishmentID == id && s.userEtablishment.userID == HttpContext.Session.GetInt32("userID"))
                    .First();
                if (t == null)
                {
                    return RedirectToAction("index", "home");
                }
                ViewData["etablishmenttypeID"] = new SelectList(_context.etablishmentType, "etablishmentTypeID", "type", t.etablishmenttypeID);
                return View(t);
            }
            catch(Exception)
            {
                return RedirectToAction("index", "home");
            }
            
            
        }

        // POST: Etablishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("etablishmentID,name,description,street,postalcode,phonenumber,email,etablishmenttypeID")] Etablishment etablishment)
        {
            if (id != etablishment.etablishmentID)
            {
                return NotFound();
            }

            //TODO: quand les sessions seront up, il faut vérifier si l'utilisateur est bien propriétaire
            if (ModelState.IsValid)
            {
                try
                {
                    if(_context.etablishment.Any(s=> s.userEtablishment.etablishmentID == id && s.userEtablishment.userID == HttpContext.Session.GetInt32("userID")))
                    {
                        _context.Update(etablishment);
                        await _context.SaveChangesAsync();
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtablishmentExists(etablishment.etablishmentID))
                    {
                        return View("index", "home");
                    }
                    else
                    {
                        return View("index", "home");
                    }
                }
                return RedirectToAction();
            }
            ViewData["etablishmenttypeID"] = new SelectList(_context.etablishmentType, "etablishmentTypeID", "type", etablishment.etablishmenttypeID);
            //done
            return View(etablishment);
        }

        // GET: Etablishments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var etablishment = await _context.etablishment
                .Include(e => e.etablishmentType)
                .Where(s => s.userEtablishment.userID == HttpContext.Session.GetInt32("userID") && s.userEtablishment.etablishmentID == id).FirstAsync();
                return View(etablishment);
            }
            catch(Exception )
            {
                return View("index", "home");
            }

            
        }

        // POST: Etablishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var etablishment = await _context.etablishment.Where(e => e.userEtablishment.etablishmentID == id && e.userEtablishment.userID == HttpContext.Session.GetInt32("userID"))
                    .FirstAsync();
                if (etablishment == null)
                {
                    //failed
                    return RedirectToAction("index", "home");
                }
                _context.etablishment.Remove(etablishment);
                await _context.SaveChangesAsync();
                // done no error
                return RedirectToAction("index", "home");
            }
            catch(Exception)
            {
                //error
                return RedirectToAction("index", "home");
            }
        }

        private bool EtablishmentExists(int id)
        {
            return _context.etablishment.Any(e => e.etablishmentID == id);
        }
    }
}
