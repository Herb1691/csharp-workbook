using System;
using System.Collections.Generic;
using System.Text;

namespace Week7_BookInventory
{
    class BookLibrary
    {
        public int Id { get; private set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public BookLibrary(String title, String author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
