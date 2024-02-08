﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_MVC_App_PhoneBook.Data;
using ASP.NET_Core_MVC_App_PhoneBook.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Core_MVC_App_PhoneBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly PhoneBookContext _context;

        public ContactsController(PhoneBookContext context)
        {
            _context = context;
        }

        // GET: Contacts
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Contacts.ToListAsync());
        //}

        //sorting
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //sorting
            ViewData["FNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewData["LNameSortParm"] = sortOrder == "LName" ? "lname_desc" : "LName";
            //searching
            ViewData["CurrentFilter"] = searchString;

            var contacts = from c in _context.Contacts
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(c => c.LName.Contains(searchString)
                                       || c.FName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fname_desc":
                    contacts = contacts.OrderByDescending(c => c.FName);
                    break;
                case "LName":
                    contacts = contacts.OrderBy(c => c.LName);
                    break;
                case "lname_desc":
                    contacts = contacts.OrderByDescending(c => c.LName);
                    break;
                default:
                    contacts = contacts.OrderBy(c => c.FName);
                    break;
            }
            return View(await contacts.AsNoTracking().ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                        .Include(c => c.Infos)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FName,LName,MName")] Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("Id,FName,LName,MName")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
