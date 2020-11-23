using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DataTest
    {
        static Generator generator = new Generator();
        DataRepository repository = new DataRepository(generator.Generate());

        [TestMethod]
        public void CatalogTest()
        {
            Book book3 = new Book("To", 1842, "Stephen King", BookType.Horror);
            repository.addCatalogBook(book3);

            Assert.AreEqual(repository.getCatalogBook(2109).AuthorName, "Andrzej Sapkowski");
            Assert.AreEqual(repository.getCatalogBook(3561).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getCatalogBook(1842).AuthorName, "Stephen King");
            Assert.AreEqual(repository.getCatalogBookList().Keys.ToList()[0].BookId, 2109);
            Assert.AreEqual(repository.getCatalogBookList().Keys.ToList()[1].BookId, 3561);
            Assert.AreEqual(repository.getCatalogBookList().Keys.ToList()[2].BookId, 1842);
            Assert.AreEqual(repository.getCatalogBookList().Count, 3);
        }

        [TestMethod]
        public void StateTest()
        {
            Book book1 = repository.getCatalogBook(2109);
            repository.addState(book1);

            Book book2 = repository.getCatalogBook(3561);
            repository.addState(book2);

            Assert.AreEqual(repository.getState(2109), book1);
            Assert.AreEqual(repository.getState(2109).AuthorName, "Andrzej Sapkowski");
            Assert.AreEqual(repository.getState(3561), book2);
            Assert.AreEqual(repository.getState(3561).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getStateList().Keys.ToList()[0], book1);
            Assert.AreEqual(repository.getStateList().Keys.ToList()[1], book2);
            Assert.AreEqual(repository.getStateList().Count, 2);

            repository.removeState(book1);

            Assert.AreEqual(repository.getState(3561), book2);
            Assert.AreEqual(repository.getState(3561).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getStateList().Keys.ToList()[0], book2);
            Assert.AreEqual(repository.getStateList().Count, 1);
        }

        [TestMethod]
        public void UserTest()
        {
            User user3 = new User("Robert Winiarski", 1431);
            repository.addUser(user3);

            Assert.AreEqual(repository.getUser(1643).userName, "Jan Kowalski");
            Assert.AreEqual(repository.getUser(6542).userName, "Kamil Nowak");
            Assert.AreEqual(repository.getUser(1431).userName, "Robert Winiarski");
            Assert.AreEqual(repository.getUserList().Keys.ToList()[0].userId, 1643);
            Assert.AreEqual(repository.getUserList().Keys.ToList()[1].userId, 6542);
            Assert.AreEqual(repository.getUserList().Keys.ToList()[2].userId, 1431);
            Assert.AreEqual(repository.getUserList().Count, 3);
        }
        
        [TestMethod]
        public void UserBookTest()
        {
            Book book1 = repository.getCatalogBook(2109);

            Book book2 = repository.getCatalogBook(3561);

            User user1 = repository.getUser(1643);

            User user2 = repository.getUser(6542);

            repository.addUserBook(book1, user1);
            repository.addUserBook(book2, user1);
            
            Assert.AreEqual(repository.getUserBook(2109, 1643), book1);
            Assert.AreEqual(repository.getUserBook(2109, 1643).AuthorName, "Andrzej Sapkowski");
            Assert.AreEqual(repository.getUserBook(3561, 1643), book2);
            Assert.AreEqual(repository.getUserBook(3561, 1643).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getUserBookList(1643).Count, 2);
            Assert.AreEqual(repository.getUserBookList(6542).Count, 0);
            
            repository.removeUserBook(book1, user1);

            Assert.AreEqual(repository.getUserBook(3561, 1643), book2);
            Assert.AreEqual(repository.getUserBook(3561, 1643).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getUserBookList(1643).Count, 1);
            Assert.AreEqual(repository.getUserBookList(6542).Count, 0);
            
            repository.addUserBook(book1, user2);

            Assert.AreEqual(repository.getUserBook(2109, 6542), book1);
            Assert.AreEqual(repository.getUserBook(2109, 6542).AuthorName, "Andrzej Sapkowski");
            Assert.AreEqual(repository.getUserBook(3561, 1643), book2);
            Assert.AreEqual(repository.getUserBook(3561, 1643).AuthorName, "George R.R. Martin");
            Assert.AreEqual(repository.getUserBookList(1643).Count, 1);
            Assert.AreEqual(repository.getUserBookList(6542).Count, 1);
        }
        
        [TestMethod]
        public void EventTest()
        {
            Book book1 = repository.getCatalogBook(2109);
            Book book2 = new Book("To", 1842, "Stephen King", BookType.Horror);
            User user1 = repository.getUser(1643);
            User user2 = new User("Robert Winiarski", 1431);
            Event event1 = new Event(book1, user1, StateType.lending, new System.DateTime(2020, 10, 10));
            Event event2 = new Event(book1, user1, StateType.returning, new System.DateTime(2020, 10, 10));
            Event event3 = new Event(book2, user2, StateType.lending, new System.DateTime(2020, 12, 4));
            repository.addEvent(event1);
            repository.addEvent(event2);
            repository.addEvent(event3);

            Assert.AreEqual(repository.getEventList()[0].stateType, StateType.lending);
            Assert.AreEqual(repository.getEventList()[0].Book.BookId, 2109);
            Assert.AreEqual(repository.getEventList()[0].User.userId, 1643);
            Assert.AreEqual(repository.getEventList()[1].stateType, StateType.returning);
            Assert.AreEqual(repository.getEventList()[1].Book.BookId, 2109);
            Assert.AreEqual(repository.getEventList()[1].User.userId, 1643);
            Assert.AreEqual(repository.getEventList()[2].stateType, StateType.lending);
            Assert.AreEqual(repository.getEventList()[2].Book.BookId, 1842);
            Assert.AreEqual(repository.getEventList()[2].User.userId, 1431);
            Assert.AreEqual(repository.getEventList().Count, 3);
        }
    }
}
