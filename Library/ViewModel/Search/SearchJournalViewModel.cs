using BookLib;
using GalaSoft.MvvmLight.Command;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ViewModel
{
    public class SearchJournalViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand SearchAction { get; set; }
        public string SearchedTitle { get; set; }
        public string SearchedAuthor { get; set; }
        public List<Months> SearchedPublishedMonth { get; set; }
        public Months SearchPublishedMonth { get; set; }
        public Types SearchedBookType { get; set; }
        public List<Types> SearchBookType { get; set; }

        public SearchJournalViewModel()
        {
            SearchBookType = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            SearchedPublishedMonth = Enum.GetValues(typeof(Months)).Cast<Months>().ToList();
            SearchAction = new RelayCommand(SearchJournal);
        }
        private void SearchJournal()
        {
            logic.SearchJournal(SearchedTitle, SearchedAuthor, SearchPublishedMonth, SearchedBookType);
        }
    }
}
