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
    public class AddBookViewModel : ViewModelBase
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;

        public string AddTitle { get; set; }
        public string AddAuthor { get; set; }
        public string AddPublishedYear { get; set; }
        public string AddPrice { get; set; }
        public List<Types> AddBookType { get; set; }
        public Types SelectedBookType { get; set; }
        public RelayCommand AddAction { get; set; }
        public AddBookViewModel()
        {
            AddBookType = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            AddAction = new RelayCommand(Add);
        }

        private void Add()
        {
            if (string.IsNullOrEmpty(AddTitle)) { MessageBox.Show("You must choose a title"); }

            if (SelectedBookType == Types.Types) { MessageBox.Show("You must choose a book type"); }

            if (string.IsNullOrEmpty(AddPrice)) AddPrice = "0";
            if (!double.TryParse(AddPrice.ToString(), out double price)) { MessageBox.Show("You must write only digits in the price box"); }

            if (string.IsNullOrEmpty(AddPublishedYear)) AddPublishedYear = "0";
            if (!int.TryParse(AddPublishedYear.ToString(), out int year)) { MessageBox.Show("You must write only digits in the year box"); }

            else { logic.AddBook(AddTitle, SelectedBookType, AddAuthor, year, price); }
        }
    }
}
