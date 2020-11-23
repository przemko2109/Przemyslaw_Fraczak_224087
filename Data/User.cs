using System;
using System.Collections.Generic;

namespace Data
{
    public class User
    {
        private int user_id;

        public int userId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private String user_name;
        public String userName
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private Dictionary<Book,int> user_books;
        public Dictionary<Book,int> userBooks
        {
            get { return user_books; }
            set { user_books = value; }
        }

        public User(String un, int ui)
        {
            user_name = un;
            user_id = ui;
            user_books = new Dictionary<Book, int>();
        }
    }
}
