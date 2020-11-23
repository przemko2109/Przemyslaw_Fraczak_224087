using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataRepository
    {
        private DataContext context;
        public DataRepository(DataContext dataContext)
        {
            context = dataContext;
        }
        
        //Add methods

        public void addCatalogBook(Book book)
        {
            context.bookCatalog().Add(book, book.userId);
        }
        public void addUserBook(Book book, User user)
        {
            context.userBooks(user.userId).Add(book, book.BookId);
        }
        public void addState(Book book)
        {
            context.bookState().Add(book, book.BookId);
        }
        public void addUser(User user)
        {
            context.Users().Add(user, user.userId);
        }
        public void addEvent(Event events)
        {
            context.Events().Add(events);
        }

        //Remove methods

        public void removeUserBook(Book book, User user)
        {
            context.userBooks(user.userId).Remove(book);
        }
        public void removeState(Book book)
        {
            context.bookState().Remove(book);
        }

        //Get methods

        public Book getCatalogBook(int id)
        {
            foreach (KeyValuePair<Book, int> book in context.bookCatalog())
            {
                if (book.Key.BookId == id)
                {
                    return book.Key;
                }
            }
            throw new Exception("");
        }
        public Book getUserBook(int book_id, int user_id)
        {
            foreach (KeyValuePair<Book, int> book in context.userBooks(user_id))
            {
                if (book.Key.BookId == book_id)
                {
                    return book.Key;
                }
            }
            throw new Exception("");
        }
        public Book getState(int id)
        {
            foreach (KeyValuePair<Book, int> book in context.bookState())
            {
                if (book.Key.BookId == id)
                {
                    return book.Key;
                }
            }
            throw new Exception("");
        }
        public User getUser(int id)
        {
            foreach (KeyValuePair<User, int> user in context.Users())
            {
                if (user.Key.userId == id)
                {
                    return user.Key;
                }
            }
            throw new Exception("");
        }

        //Get list methods

        public Dictionary<Book,int> getCatalogBookList()
        {
            return context.bookCatalog();
        }
        public Dictionary<Book,int> getUserBookList(int id)
        {
            return context.userBooks(id);
        }
        public Dictionary<Book,int> getStateList()
        {
            return context.bookState();
        }
        public Dictionary<User,int> getUserList()
        {
            return context.Users();
        }
        public List<Event> getEventList()
        {
            return context.Events();
        }
    }
}
