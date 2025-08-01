using System.Diagnostics;
using _4aconsultMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using _4aconsultMVC.DataAccess;
using System.Data;
using Microsoft.Extensions.Options;
using System.Data.SqlTypes;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting.Server;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;


namespace _4aconsultMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
                                           BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        // get 
        public IActionResult Index()
        {
            var books = _context.Bookstable.FromSqlRaw("SelectAll").ToList();
            return View(books); 
        }


        public IActionResult IndexXML()
        {
            var books = _context.Bookstable
                .FromSqlRaw("EXEC SelectAll")
                .ToList(); 

            var serializer = new XmlSerializer(typeof(List<Book>));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, books);
            string xml = stringWriter.ToString();

            return Content(xml, "application/xml", Encoding.UTF8);
        }


        public IActionResult BookPage(Guid id)
        {
            if (ModelState.IsValid)
            {

                SqlParameter param = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                param.Value = id;
                Book? book = _context.Bookstable.FromSqlRaw("SelectOne @Id", param)
                                                            .IgnoreQueryFilters()
                                                            .ToList()
                                                            .FirstOrDefault();
                return View(book);
            }
            return NotFound();
        }



        public IActionResult BookPageXML(Guid id)
        {
            if (ModelState.IsValid)
            {

                SqlParameter param = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                param.Value = id;
                Book? book = _context.Bookstable.FromSqlRaw("SelectOne @Id", param)
                                                            .IgnoreQueryFilters()
                                                            .ToList()
                                                            .FirstOrDefault();

                var serializer = new XmlSerializer(typeof(Book));
                using var stringWriter = new StringWriter();
                serializer.Serialize(stringWriter, book);
                string xml = stringWriter.ToString();

                return Content(xml, "application/xml", Encoding.UTF8);
                //return View(book);
            }
            return NotFound();
        }


        // delete
        public async Task<IActionResult> DeleteBookPage(Guid? id)
        {
            if (ModelState.IsValid)
            {
                SqlParameter param = new("@Id", SqlDbType.UniqueIdentifier);
                param.Value = id;
                try
                {
                    _context.Bookstable.FromSqlRaw("DeleteBook @Id", param)
                                                            .IgnoreQueryFilters()
                                                            .ToList()
                                                            .FirstOrDefault();
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex);
                }
                return RedirectToAction("Index");
            }
            return NotFound();
        } 


        // update 
        [HttpGet]
        public IActionResult EditBookPage(Guid id)
        {
            if (ModelState.IsValid)
            {
                SqlParameter param = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                param.Value = id;
                Book? book = _context.Bookstable.FromSqlRaw("SelectOne @Id", param)
                                                            .IgnoreQueryFilters()
                                                            .ToList()
                                                            .FirstOrDefault();
                return View(book);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> EditBookPage(Guid Id, Book model)
        {
            if (ModelState.IsValid)
            {
                SqlParameter param1 = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                param1.Value = Id;
                SqlParameter param2 = new SqlParameter("@Price", SqlDbType.Int);
                param2.Value = model.Price;
                try
                {
                    _context.Bookstable.FromSqlRaw("UpdateBook @Id, @Price", param1, param2)
                                                                .IgnoreQueryFilters()
                                                                .ToList()
                                                                .FirstOrDefault();
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex);
                }
                return RedirectToAction("BookPage", new { Id });
            }
            else
            {
                return View("Not Found");
            }
        }


        //// create
        [HttpGet]
        public IActionResult CreateNewBook()
        {
            Book model = new ();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> CreateNewBook(Book model)
        {
            if (ModelState.IsValid)
            {
                SqlParameter paramId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                paramId.Value = Guid.NewGuid();
                SqlParameter paramAuthor = new SqlParameter("@Author", SqlDbType.Text);
                paramAuthor.Value = model.Author;
                SqlParameter paramName = new SqlParameter("@Name", SqlDbType.Text);
                paramName.Value = model.Name;
                SqlParameter paramPrice = new SqlParameter("@Price", SqlDbType.Int);
                paramPrice.Value = model.Price;
                SqlParameter paramYear = new SqlParameter("@Year", SqlDbType.Int);
                paramYear.Value = model.Year;
                try
                {
                    _context.Bookstable.FromSqlRaw("InsertBook @Id, @Author, @Name, @Price, @Year",
                                                     paramId, paramAuthor, paramName,
                                                     paramPrice, paramYear)
                                        .IgnoreQueryFilters()
                                        .ToList()
                                        .FirstOrDefault();
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine("");
                    Debug.WriteLine(ex);
                    Debug.WriteLine("");
                }
                return RedirectToAction("Index"); 
            }
            else
            {
                return View(model);
            }
        }



        ////////////////////////////////////////////////////////////
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
