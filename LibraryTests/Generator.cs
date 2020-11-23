using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Tests
{
    public class Generator : IGenerator
    {
        public DataContext Generate()
        {
            DataContext context = new DataContext();

            Book book1 = new Book("Wiedźmin", 2109, "Andrzej Sapkowski", BookType.Fantasy);
            context.bookCatalog().Add(book1, book1.BookId);

            User user1 = new User("Jan Kowalski", 1643);
            context.Users().Add(user1, user1.userId);

            Book book2 = new Book("Gra o tron", 3561, "George R.R. Martin", BookType.Fantasy);
            context.bookCatalog().Add(book2, book2.BookId);

            User user2 = new User("Kamil Nowak", 6542);
            context.Users().Add(user2, user2.userId);

            return context;
        }
    }
}
