using Autofac;
using BookWorm.Commands;
using BookWorm.DataAccess;
using BookWorm.ViewModel;
using System.Collections.Generic;

namespace BookWorm.Services
{
    public static class AutofacModule
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainVM>().As<IBase>().SingleInstance();
            builder.RegisterType<List<LibraryVM>>();
            builder.RegisterType<LoadedLibraryCommad>();
            builder.RegisterType<LogginCommand>();
            builder.RegisterType<RegistrationCommand>();
            builder.RegisterType<SelectViewCommand>();
            builder.RegisterType<ValidationEmailCommand>();
            builder.RegisterType<SearchingBooksCommand>();
            builder.RegisterType<DescriptionBooKVM>().As<IDescriptionBooKVM>();
            builder.RegisterType<ValidationEmailVM>().As<IValidatioinEmailVM>();
            builder.RegisterType<UserLoginVM>().As<IUserLoginVM>();
            builder.RegisterType<RegistrationVM>().As<IRegistrationVM>();
            builder.RegisterType<LibraryVM>().As<ILibrary>();
            builder.RegisterType<BookLibrary>();
            builder.RegisterType<ViewBookCommand>();
            builder.RegisterType<AddToSelectedCommand>();
            builder.RegisterType<LoadingBookShelfCommand>();
            builder.RegisterType<BookShelfVM>().As<IBookShelfVM>();
            builder.RegisterType<ReadingModeVM>().As<IReadingModeVM>();
            builder.RegisterType<ReadingModeCommand>();
            builder.RegisterType<RemoveFromListCommand>();
            builder.RegisterType<AddToReadingListCommand>();
            builder.RegisterType<EditСommentСommand>();
            return builder.Build();
        }
    }
}
