using BookLib;
using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class ItemsCollection
    {
        public Action<Book> AddBookAction { get; set; }
        public Action<Journal> AddJournalAction { get; set; }

        public Action<string, string, int, Types, string> SearchBookAction { get; set; }
        public Action<string, string, Months, Types> SearchJournalAction { get; set; }

        public Action SaleBookAction { get; set; }
        public Action SaleJournalAction { get; set; }

        public Action RemoveBookAction { get; set; }
        public Action RemoveJournalAction { get; set; }

        public Action ShowAllAction { get; set; }

        public Action<double> UpdateBookPriceAction { get; set; }
        public Action<Types> AddBookTypeAction { get; set; }
        public Action<Types> RemoveBookTypeAction { get; set; }

        public Action<double> UpdateJournalPriceAction { get; set; }
        public Action<Types> AddJournalTypeAction { get; set; }
        public Action<Types> RemoveJournalTypeAction { get; set; }

        public List<AbstractItem> AbstractItems { get; set; }

        #region Adding
        public void AddBook(string title, Types bookType = default, string author = "", int publishedYear = 0, double price = 0)
        {
            if (string.IsNullOrEmpty(title) || bookType == Types.Types)
            {
                return;
            }
            AbstractItems.Add(new Book(title, price, bookType) { Author = author, PublishedYear = publishedYear });
            AddBookAction(new Book(title, price, bookType) { Author = author, PublishedYear = publishedYear });
        }

        public void AddJournal(string title, Months publishedMonth, string writer = "", Types journalType = default, double price = 0)
        {
            if (string.IsNullOrEmpty(title) || publishedMonth == Months.Months || journalType == Types.Types)
            {
                return;
            }
            AbstractItems.Add(new Journal(title, price, journalType) { Author = writer, JournalMonth = publishedMonth });
            AddJournalAction(new Journal(title, price, journalType) { Author = writer, JournalMonth = publishedMonth });
        }

        #endregion Adding

        #region Searching
        public void SearchBook(string title, string author, int publishedYear, Types bookType, string ISBN)
        {
            SearchBookAction(title, author, publishedYear, bookType, ISBN);
        }
        public void SearchJournal(string title, string author, Months publishedMonth, Types type)
        {
            SearchJournalAction(title, author, publishedMonth, type);
        }
        #endregion Searching

        #region Removing
        public void SaleBook()
        {
            SaleBookAction();
        }
        public void SaleJournal()
        {
            SaleJournalAction();
        }
        public void RemoveBook()
        {
            RemoveBookAction();
        }
        public void RemoveJournal()
        {
            RemoveJournalAction();
        }
        #endregion Removing

        public void ShowAllItems()
        {
            ShowAllAction();
        }

        #region Updating

        #region Books
        public void UpdateBookPrice(double price)
        {
            UpdateBookPriceAction(price);
        }
        public void AddBookType(Types addedBookType)
        {
            AddBookTypeAction(addedBookType);
        }
        public void RemoveBookType(Types removeedBookType)
        {
            RemoveBookTypeAction(removeedBookType);
        }
        #endregion Books

        #region Journals
        public void UpdateJournalPrice(double price)
        {
            UpdateJournalPriceAction(price);
        }
        public void AddJournalType(Types addedBookType)
        {
            AddJournalTypeAction(addedBookType);
        }
        public void RemoveJournalType(Types removeedBookType)
        {
            RemoveJournalTypeAction(removeedBookType);
        }
        #endregion Journals

        #endregion Updating

        private ItemsCollection() => AbstractItems = new List<AbstractItem>();

        private static ItemsCollection instance;
        public static ItemsCollection Instance => instance ?? (instance = new ItemsCollection());
    }
}
