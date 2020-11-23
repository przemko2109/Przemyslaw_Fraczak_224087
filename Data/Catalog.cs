using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Catalog
    {
        private Dictionary<Book,int> books;
        public Dictionary<Book,int> Books
        {
            get { return books; }
            set { books = value; }
        }

        public Catalog()
        {
            books = new Dictionary<Book,int>();
        }
    }
}
