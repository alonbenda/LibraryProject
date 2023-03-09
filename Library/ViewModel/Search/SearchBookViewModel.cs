using BookLib;
using GalaSoft.MvvmLight.Command;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library.ViewModel
{
    public class SearchBookViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand SearchAction { get; set; }
        public string SearchedTitle { get; set; }
        public string SearchedAuthor { get; set; }
        public string SearchedPublishedYear { get; set; }
        public Types SearchedBookType { get; set; }
        public List<Types> SearchBookType { get; set; }
        public string SearchedBookISBN { get; set; }

        public SearchBookViewModel()
        {
            SearchBookType = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            SearchAction = new RelayCommand(SearchBook);
        }
        private void SearchBook()
        {
            if (string.IsNullOrEmpty(SearchedPublishedYear)) SearchedPublishedYear = "0";
            if (!int.TryParse(SearchedPublishedYear.ToString(), out int year)) { MessageBox.Show("You must write only digits in the year box"); }
            else logic.SearchBook(SearchedTitle, SearchedAuthor, year, SearchedBookType, SearchedBookISBN);
        }
    }
}
