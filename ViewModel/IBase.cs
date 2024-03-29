﻿using BookWorm.ModelDB;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IBase
    {
        IBase Base { get; set; }
        bool IsControlAVisible { get; set; }
        ILibrary Library { get; set; }
        IUserLoginVM LogginUser { get; set; }
        IRegistrationVM Registration { get; set; }
        IBaseVM SelectView { get; set; }
        ICommand SelectViewCommand { get; set; }
        ICommand LoadingShelfCommand { get; set; }
        ICommand ExitCommand { get; set; }
        Users User { get; set; }
        IValidatioinEmailVM ValidationVM { get; set; }
        IDescriptionBooKVM DescriptionBooKVm { get; set; }
        IBookShelfVM BookShelfVM { get; set; }
        IReadingModeVM ReadingModeVM { get; set; }
        public IRecoveryPasswordVM RecoveryPasswordVM { get; set; }
        string ExecutionState { get; set; }
    }
}