using BookLib;
using Library.ViewModel;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemsCollection logic = ItemsCollection.Instance;
            BooksLIstViewViewModel viewModel = new BooksLIstViewViewModel();

            Book book = new Book("a", 10, Types.Drama);
            Book book2 = new Book("b", 10, Types.Comedy);
            viewModel.AddBook(book);
            viewModel.AddBook(book2);
            logic.AbstractItems.Add(book);
            logic.AbstractItems.Add(book2);
            viewModel.SearchBooks("a", book.Author, book.PublishedYear, Types.Drama, book.ISBN);
            Console.WriteLine(viewModel.Books.Count);
            //Assert.IsTrue(viewModel.Books.Count == 1);
        }
    }
}
