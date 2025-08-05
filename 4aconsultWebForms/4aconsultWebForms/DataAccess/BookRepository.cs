using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4aconsultWebForms.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace _4aconsultWebForms.DataAccess
{
    public class BookRepository
    {

        private readonly BookContext _context;
        //private BookContext context = new BookContext();

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books
        {
            get { return _context.Bookstable; }
        }
    }
}