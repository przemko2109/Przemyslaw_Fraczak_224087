using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Event
    {
        private Catalog state;

        public Catalog State
        {
            get { return state; }
            set { state = value; }
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private StateType state_type;
        public StateType stateType
        {
            get { return state_type; }
            set { state_type = value; }
        }

        private Book book;
        public Book Book
        {
            get { return book; }
            set { book = value; }
        }

        private DateTime day;
        public DateTime Day
        {
            get { return day; }
            set { day = value; }
        }
        private int price;
        public int penaltyPrice
        {
            get { return price; }
            set { price = value; }
        }
        public Event(Book b, User u, StateType st, DateTime d)
        {
            this.book = b;
            this.user = u;
            this.state_type = st;
            this.day = d;
            this.price = 0;
        }
    }
    public enum StateType
    {
        returning,
        lending
    }
}
