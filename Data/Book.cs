using System;

namespace Data
{
    public class Book 
    {
        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private int book_id;
        public int BookId
        {
            get { return book_id; }
            set { book_id = value; }
        }

        private String author_name;
        public String AuthorName
        {
            get { return author_name; }
            set { title = value; }
        }

        private BookType genre;
        public BookType Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private int user_id;

        public int userId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public Book(String t, int bi, String an, BookType g)
        {
            this.title = t;
            this.book_id = bi;
            this.author_name = an;
            this.genre = g;
            this.user_id = 0;
        }
    }

    public enum BookType
    {
        Horror,
        SF,
        Scientific,
        Fantasy,
        Adventure,
        Drama,
        Poetry,
        Thriller,
        Children,
        Western,
        History
    }
}
