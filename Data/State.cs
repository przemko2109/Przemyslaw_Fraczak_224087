using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class State
    {
        private Catalog catalog;
        public Catalog BookCatalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        public State(Catalog c)
        {
            catalog = c;
        }
    }
}
