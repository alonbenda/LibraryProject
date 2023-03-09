using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library.ViewModel
{
    public class AddJournalViewModel : ViewModelBase
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;

        public string AddTitle { get; set; }
        public string AddAuthor { get; set; }
        public string AddPrice { get; set; }
        public List<Months> AddPublishedMonth { get; set; }
        public Months SelectedJournalMonth { get; set; }
        public List<Types> AddJournalType { get; set; }
        public Types SelectedJournalType { get; set; }
        public RelayCommand AddAction { get; set; }
        public AddJournalViewModel()
        {
            AddJournalType = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            AddPublishedMonth = Enum.GetValues(typeof(Months)).Cast<Months>().ToList();
            AddAction = new RelayCommand(Add);
        }

        private void Add()
        {
            if (string.IsNullOrEmpty(AddPrice)) AddPrice = "0";
            if (string.IsNullOrEmpty(AddTitle)) { MessageBox.Show("You must choose a title"); }
            if (SelectedJournalType == Types.Types) { MessageBox.Show("You must choose a type"); }
            if (SelectedJournalMonth == Months.Months) { MessageBox.Show("You must choose a month"); }
            if (!double.TryParse(AddPrice.ToString(), out double price)) { MessageBox.Show("You must write only digits in the price box"); }
            else { logic.AddJournal(AddTitle, SelectedJournalMonth, AddAuthor, SelectedJournalType, price); }
        }
    }
}
