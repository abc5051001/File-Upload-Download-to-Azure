#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileWebApp.Data;
using FileWebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace FileWebApp.Controllers
{
    [Authorize]
    public class FileDetailsController : Controller
    {
        private readonly FileWebAppContext _context;

        public FileDetailsController(FileWebAppContext context)
        {
            _context = context;
        }

        // GET: FileDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileDetails.ToListAsync());
        }

        // GET: Search
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Search Results
        public async Task<IActionResult> ShowSearchResults(String SearchFileName, String SearchStatus, 
        String SearchFileUploadedBy, String SearchFileOwner)
        {
            // Search function validates for null and set blanks for like condition in where 
            if (SearchFileName == null) SearchFileName = "";
            if (SearchStatus == null) SearchStatus = "";
            if (SearchFileUploadedBy == null) SearchFileUploadedBy = "";
            if (SearchFileOwner == null) SearchFileOwner = "";
            return View("Index", await _context.FileDetails.Where(j => j.FileName.Contains(SearchFileName)
            && j.Status.Contains(SearchStatus) && j.FileUploadedBy.Contains(SearchFileUploadedBy)
            && j.FileOwner.Contains(SearchFileOwner)).ToListAsync());
        }

        // GET: FileDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDetails = await _context.FileDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDetails == null)
            {
                return NotFound();
            }

            return View(fileDetails);
        }

        // GET: FileDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,FileName,Status,FileType,FilePath,FileSize,FileOwner,FileCreationDate,FileModifiedDate,FileUploadedBy,RecordCreationDate,RecordModifiedDate,FileContents")] FileDetails fileDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileDetails);
        }

        // GET: FileDetails/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDetails = await _context.FileDetails.FindAsync(id);
            if (fileDetails == null)
            {
                return NotFound();
            }
            return View(fileDetails);
        }

        // POST: FileDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName,Status,FileType,FilePath,FileSize,FileOwner,FileCreationDate,FileModifiedDate,FileUploadedBy,RecordCreationDate,RecordModifiedDate,FileContents")] FileDetails fileDetails)
        {
            if (id != fileDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileDetailsExists(fileDetails.Id))
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
            return View(fileDetails);
        }

        // GET: FileDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileDetails = await _context.FileDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileDetails == null)
            {
                return NotFound();
            }

            return View(fileDetails);
        }

        // POST: FileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileDetails = await _context.FileDetails.FindAsync(id);
            _context.FileDetails.Remove(fileDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileDetailsExists(int id)
        {
            return _context.FileDetails.Any(e => e.Id == id);
        }
    }
}
