using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileWebApp.Services;
using FileWebApp.Migrations;
using FileWebApp.Models;
using FileWebApp.Data;
using FileWebApp.Controllers;

namespace FileWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        private readonly IStorageService _storageService;

        public FileUploadController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content("<html><form method='post' enctype='multipart/form-data' asp-action='Upload'><div class='form-group'><div class='col-md-10'><p>Upload one or more files using this form:</p><input type='file' name='file' multiple=''></div></div><div class='form-group'><div class='col-md-10'><input type='submit' value='Upload'></div></div></form></html>", "text/html");
        }

        [HttpPost]
        [ActionName("Upload")]
        public IActionResult Upload(IFormFile file, [FromServices] FileWebAppContext _context)
        {
            FileDetails newfile = _storageService.Extract(file);
            if (_context.FileDetails.Any(e => e.Id == newfile.Id))
            {
                newfile.Status = "Processed";
            }
            _context.Add(newfile);
            _context.SaveChangesAsync();
            _storageService.Upload(file);
            return RedirectToAction(nameof(Index), "FileDetails");
        }

    }
}
