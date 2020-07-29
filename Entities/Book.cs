using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.API.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public string Publisher { get; set; }
        public int NoOfPages { get; set; }
        public decimal Ratings { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
