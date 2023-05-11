﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.DTO;
using BookWorm.DataAccess;

namespace BookWorm.ViewModel
{
    public class LibraryVM:BaseVM
    {
        
        private string _name;

        private List<BookLibrary> _bookslibrary;

        private IEnumerable<string?> _listOfImage;

        private List<BookDto> _libraryList;

        public List<BookLibrary> BooksLibrary
        {
            get { return _bookslibrary; } 
            set { _bookslibrary = value;
                OnPropertyChanged(nameof(BooksLibrary));
            }
        }
        public IEnumerable<string> ListOfImage
        {
            get { return _listOfImage; }

            set { _listOfImage = value;
                OnPropertyChanged(nameof(ListOfImage));
            }
        }
        public List<BookDto> LibraryList
        {
            get { return _libraryList; }

            set { _libraryList = value; 
                OnPropertyChanged(nameof(LibraryList));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public LibraryVM()
        {
            this._libraryList = new List<BookDto>();
            this._listOfImage= new List<string>();
            this._bookslibrary = new List<BookLibrary>();
        }
    }
}
