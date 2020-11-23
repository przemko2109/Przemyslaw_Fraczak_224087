using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class DataContext
    {
        private Catalog catalog = new Catalog();
        private State state = new State(new Catalog());
        private Dictionary<User, int> users = new Dictionary<User, int>();
        private List<Event> events = new List<Event>();

        public DataContext()
        {

        }
        public Dictionary<Book, int> bookCatalog()
        {
            return catalog.Books;
        }

        public Dictionary<Book, int> bookState()
        {
            return state.BookCatalog.Books;
        }

        public Dictionary<Book, int> userBooks(int id)
        {
            return users.FirstOrDefault(u => u.Key.userId == id).Key.userBooks;
        }

        public List<Event> Events()
        {
            return events;
        }

        public Dictionary<User, int> Users()
        {
            return users;
        }
    }
}
