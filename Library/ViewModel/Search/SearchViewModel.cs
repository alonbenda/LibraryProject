using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        public RelayCommand SearchBookViewAction { get; set; }
        public RelayCommand SearchJournalViewAction { get; set; }

        private double searchBookWidth;
        public double SearchBookWidth { get => searchBookWidth; set => Set(ref searchBookWidth, value); }

        private double searchJournalWidth;
        public double SearchJournalWidth { get => searchJournalWidth; set => Set(ref searchJournalWidth, value); }

        public SearchViewModel()
        {
            SearchBookViewAction = new RelayCommand(BookViewToDisplay);
            SearchJournalViewAction = new RelayCommand(JournalViewToDisplay);
        }

        private void BookViewToDisplay()
        {
            SearchBookWidth = SystemParameters.PrimaryScreenWidth;
            SearchJournalWidth = 0;
        }
        private void JournalViewToDisplay()
        {
            SearchBookWidth = 0;
            SearchJournalWidth = SystemParameters.PrimaryScreenWidth;
        }


        #region Get Items
        private IEnumerable<AbstractItem> GetItemByName(List<AbstractItem> abstractItems, string title)
        {
            if (title == default) { return abstractItems; }
            return abstractItems.Where(abstractItem => abstractItem.Title.ToLower().Contains(title.ToLower()));
        }
        private IEnumerable<AbstractItem> GetBookByYear(IEnumerable<AbstractItem> abstractItems, int year)
        {
            if (year == default) { return abstractItems; }
            return abstractItems.OfType<Book>().Where(book => book.PublishedYear == year);
        }
        private IEnumerable<AbstractItem> GetJournalByMonth(IEnumerable<AbstractItem> abstractItems, Months month)
        {
            if (month == default) { return abstractItems; }          
            return abstractItems.OfType<Journal>().Where(journal => journal.JournalMonth == month);
        }
        private IEnumerable<AbstractItem> GetItemByAuthor(IEnumerable<AbstractItem> abstractItems, string author)
        {
            if (author == default) { return abstractItems; }
            return abstractItems.Where(abstractItem => abstractItem.Author.ToLower().Contains(author.ToLower()));
        }
        private IEnumerable<AbstractItem> GetItemByType(IEnumerable<AbstractItem> abstractItems, Types type)
        {
            if (type == Types.Types) { return abstractItems; }
            return abstractItems.Where(abstractItem => abstractItem.Type == type);
        }
        private IEnumerable<AbstractItem> GetItemByISBN(IEnumerable<AbstractItem> abstractItems, string isbn)
        {
            if (isbn == default) { return abstractItems; }
            return abstractItems.OfType<Book>().Where(book => book.ISBN.ToLower().Contains(isbn.ToLower()));
        }
        /// <summary>
        /// Get a list by the title, by the published month, by the author and by the type.
        /// </summary>
        /// <param name="abstractItems"></param>
        /// <param name="title"></param>
        /// <param name="month"></param>
        /// <param name="author"></param>
        /// <param name="bookType"></param>
        /// <returns>List of Journal items</returns>
        public IEnumerable<Journal> GetJournals(List<AbstractItem> abstractItems, string title, Months month, string author, Types bookType)
        {
            var byName = GetItemByName(abstractItems, title);
            var byYear = GetJournalByMonth(byName, month);
            var byAuthor = GetItemByAuthor(byYear, author);
            var byType = GetItemByType(byAuthor, bookType);
            return byType.OfType<Journal>();
        }
        /// <summary>
        /// Get a list by the title, by the published year, by the author, by the type and by the ISBN.
        /// </summary>
        /// <param name="abstractItems"></param>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="author"></param>
        /// <param name="bookType"></param>
        /// <param name="ISBN"></param>
        /// <returns>List of Book items</returns>
        public IEnumerable<Book> GetBooks(List<AbstractItem> abstractItems, string title, int year, string author, Types bookType, string ISBN)
        {
            var byName = GetItemByName(abstractItems, title);
            var byYear = GetBookByYear(byName, year);
            var byAuthor = GetItemByAuthor(byYear, author);
            var byType = GetItemByType(byAuthor, bookType);
            var byISBN = GetItemByISBN(byType, ISBN);
            return byISBN.OfType<Book>();
        }
        #endregion Get Items
    }
}
