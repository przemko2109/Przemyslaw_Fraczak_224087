using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Logic
{
    public class DataService
    {
        private DataRepository repository;
        public DataService(DataRepository Repository)
        {
            repository = Repository;
        }

        //Add methods

        public void addCatalogBook(string title, int book_id, string author_name, BookType genre)
        {
            repository.addCatalogBook(new Book(title, book_id, author_name, genre));
        }
        public void addUserBook(int book_id, int user_id)
        {
            repository.addUserBook(getCatalogBookList().FirstOrDefault(b => b.Value == book_id).Key, getUserList().FirstOrDefault(u => u.Value == user_id).Key);
        }
        public void addState(int book_id)
        {
            repository.addState(getCatalogBookList().FirstOrDefault(b => b.Value == book_id).Key);
        }
        public void addUser(string user_name, int user_id)
        {
            repository.addUser(new User(user_name, user_id));
        }
        public void addEvent(Book books, User users, StateType state_type, DateTime date)
        {
            repository.addEvent(new Event(books, users, state_type, date));
        }

        //Remove methods

        public void removeUserBook(int book_id, int user_id)
        {
            repository.removeUserBook(getUserBookList(user_id).FirstOrDefault(b => b.Value == book_id).Key, getUserList().FirstOrDefault(u => u.Value == user_id).Key);
        }
        public void removeState(int book_id)
        {
            repository.removeState(getStateList().FirstOrDefault(b => b.Value == book_id).Key);
        }

        //Get methods

        public Book getCatalogBook(int id)
        {
            return repository.getCatalogBook(id);
        }
        public Book getState(int id)
        {
            return repository.getState(id);
        }
        public Book getUserBook(int book_id, int user_id)
        {
            return repository.getUserBook(book_id, user_id);
        }
        public User getUser(int id)
        {
            return repository.getUser(id);
        }

        //Get list methods

        public Dictionary<Book,int> getCatalogBookList()
        {
            return repository.getCatalogBookList();
        }
        public Dictionary<Book,int> getStateList()
        {
            return repository.getStateList();
        }
        public Dictionary<Book,int> getUserBookList(int id)
        {
            return repository.getUserBookList(id);
        }
        public Dictionary<User,int> getUserList()
        {
            return repository.getUserList();
        }
        public List<Event> getEventList()
        {
            return repository.getEventList();
        }

        //Other methods

        public bool checkUser(int id)
        {
            return getUserList().ContainsValue(id) ? true : false; 
        }
        public bool checkCatalogBook(int id)
        {
            return getCatalogBookList().ContainsValue(id) ? true : false;
        }
        public bool checkState(int id)
        {
            return getStateList().ContainsValue(id) ? true : false;
        }
        public bool checkUserBook(int book_id, int user_id)
        {
            return getUserBookList(user_id).ContainsValue(book_id) ? true : false;
        }
        public bool checkUserId(User user, Book book)
        {
            user = new User(user.userName, user.userId);
            book = new Book(book.Title, book.BookId, book.AuthorName, book.Genre);
            if (getStateList().FirstOrDefault(b => b.Key == book).Key.userId == user.userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addUserToList(int id)
        {
            User user = getUser(id);
            if (!checkUser(id))
            {
                addUser(user.userName, user.userId);
            }
        }
        public void addBookToList(Book book)
        {
            if (!checkState(book.BookId) && !(checkCatalogBook(book.BookId)))
            {
                addCatalogBook(book.Title, book.BookId, book.AuthorName, book.Genre);
                addState(book.BookId);
            }
        }
        public void lendBook(int book_id, int user_id, DateTime time)
        {
            Book book = getCatalogBook(book_id);
            User user = getUser(user_id);
            if (!checkUserBook(book_id, user_id))
            {
                //getCatalogBookList().FirstOrDefault(b => b.Value == book_id).Key.userId = getUserList().FirstOrDefault(u => u.Value == user_id).Value;
                removeState(book.BookId);
                addUserBook(book.BookId, user.userId);
                addEvent(book, user, StateType.lending, time);
            }
        }
        public void returnBook(int book_id, int user_id, DateTime time)
        {
            Book book = getCatalogBook(book_id);
            User user = getUser(user_id);
            if (checkUserBook(book_id, user_id))
            {
                addState(book.BookId);
                removeUserBook(book.BookId, user.userId);
                Event e1 = getEventList().FindLast(x => (x.Book == book && x.User == user));
                addEvent(book, user, StateType.returning, time);
                Event e2 = getEventList().FindLast(x => (x.Book == book && x.User == user));
                if (e1 != null)
                {
                    double period = (e2.Day - e1.Day).TotalDays;
                    if (period > 30)
                    {
                        for (double i = 0; i < (period - 30); i++)
                        {
                            e2.penaltyPrice += 1;
                        }
                    }
                }
            }
            
        }
        
        public bool checkIfUserExists(int id)
        {
            if(getUserList().Any(u => u.Value == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkIfBookExists(Book book)
        {
            if (getStateList().Any(b => b.Value == book.BookId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
