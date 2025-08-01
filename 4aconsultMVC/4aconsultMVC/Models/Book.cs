using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _4aconsultMVC.Models
{
    public class Book
    {
        //[Key]
        //[ForeignKey("BookInfo")]
        public Guid Id { get; set; }
        public string? Author { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Year { get; set; }
        //public BookInfo? bookInfo { get; set; }
        //public IEnumerable<BookInfo>? Books { get; set; }
    }
}
