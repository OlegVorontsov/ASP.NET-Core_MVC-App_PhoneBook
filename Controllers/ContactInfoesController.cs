using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_MVC_App_PhoneBook.Data;
using ASP.NET_Core_MVC_App_PhoneBook.Models;

namespace ASP.NET_Core_MVC_App_PhoneBook.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly PhoneBookContext _context;

        public ContactInfoesController(PhoneBookContext context)
        {
            _context = context;
        }

        // GET: ContactInfoes
        public async Task<IActionResult> Index()
        {
            var phoneBookContext = _context.ContactInfos.Include(c => c.Contact);
            return View(await phoneBookContext.ToListAsync());
        }

        // GET: ContactInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // GET: ContactInfoes/Create
        public IActionResult Create(int? id)
        {
            //ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id");
            ViewData["ContactId"] = id;
            return View();
        }

        // POST: ContactInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Phone,Note,ContactId")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _context.ContactInfos.Add(contactInfo);
                await _context.SaveChangesAsync();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", contactInfo.ContactId);
            //return View(contactInfo);
            return Redirect("~/Contacts/Index");
        }

        // GET: ContactInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            //ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", contactInfo.ContactId);
            return View(contactInfo);
        }

        // POST: ContactInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Phone,Note,ContactId")] ContactInfo contactInfo)
            //,ContactId")] ContactInfo contactInfo)
        {
            if (id != contactInfo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Redirect("~/Contacts/Index");
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", contactInfo.ContactId);
            return View(contactInfo);
        }

        // GET: ContactInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // POST: ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Redirect("~/Contacts/Index");
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.Id == id);
        }
    }
}
