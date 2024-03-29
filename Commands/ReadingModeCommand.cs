﻿using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using BookWorm.Api;
using BookWorm.ModelDB;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class ReadingModeCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;
        public ReadingModeCommand(IBase mainSelectorVm)
        {
            this._mainSelectorVm = mainSelectorVm;
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                var selectedBook = parameter as ListViewItem;
                Books? book = selectedBook?.Content as Books;

                var identificator = book?.Identificator;

                if (identificator != null)
                {
                    string? bookText = await ApisClient.GetBookTextAsync(identificator);
                    if (bookText != null)
                    {
                        if (bookText.Split("CONTENTS").Length > 1)
                        {
                            this._mainSelectorVm.ReadingModeVM.BookText = bookText.Split("CONTENTS")[1];
                        }
                        else if(bookText.Split("***").Length > 1)
                        {
                            this._mainSelectorVm.ReadingModeVM.BookText = bookText.Split("***")[2];
                        }
                        else
                        {
                            this._mainSelectorVm.ReadingModeVM.BookText = bookText;
                        }
                        _mainSelectorVm.BookShelfVM.IsVisibil = false;
                        this._mainSelectorVm.SelectView = _mainSelectorVm.ReadingModeVM;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
