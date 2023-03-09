using BookLib;
using Library.ViewModel;
using LibraryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace lIbraryTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        readonly BooksLIstViewViewModel viewModel = new BooksLIstViewViewModel();
        Book book = new Book("a", 10, Types.Drama);
        Book book2 = new Book("b", 10, Types.Comedy);

        [TestMethod]
        public void TestAdd()
        {
            logic.AddBookAction(book);
            Assert.IsTrue(viewModel.Books.Count == 1);
        }

        [TestMethod]
        public void TestSearch()
        {
            logic.AbstractItems.Add(book);
            logic.AbstractItems.Add(book2);
            logic.SearchBookAction("a", book.Author, book.PublishedYear, Types.Drama, book.ISBN);
            Assert.IsTrue(viewModel.Books.Count == 1);
        }

        [TestMethod]
        public void TestSale()
        {
            logic.AbstractItems.Add(book);
            viewModel.SelectedBook = book;
            logic.SaleBookAction();
            Assert.IsTrue(book.Copies < 20);
        }

        [TestMethod]
        public void TestRemove()
        {
            logic.AbstractItems.Add(book);
            viewModel.SelectedBook = book;
            logic.RemoveBookAction();
            Assert.IsTrue(viewModel.Books.Count == 0);
        }

        [TestMethod]
        public void TestUpdateType()
        {
            logic.AbstractItems.Add(book);
            viewModel.SelectedBook = book;
            logic.AddBookTypeAction(Types.Action);
            logic.RemoveBookTypeAction(Types.Drama);
            Assert.IsTrue(book.Type == Types.Action);
        }

        [TestMethod]
        public void TestUpdatePrice()
        {
            logic.AbstractItems.Add(book);
            viewModel.SelectedBook = book;
            logic.UpdateBookPriceAction(20);
            Assert.IsTrue(book.Price == 20);
        }
    }
}
