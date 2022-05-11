using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }

        public string Title
        {
            get
            {

                if (Book != null && Book.Id != 0)
                    return "Edit Book";

                return "New Book";
            }
        }
    }
}