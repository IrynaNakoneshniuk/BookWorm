﻿using BookWorm.Api;
using BookWorm.DataAccess;
using BookWorm.DTO;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        private readonly MainVM mainVM;
       public  LibraryView()
       {
            InitializeComponent();
            mainVM= new MainVM();
            mainVM.Library.BooksLibrary = CurrentView.Bookslibrary;
            this.DataContext = mainVM;
       }
    }
}
