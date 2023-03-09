using BookLib;
using GalaSoft.MvvmLight.Command;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library.ViewModel
{
    public class UpdateBookViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand UpdatePriceAction { get; set; }
        public string NewPrice { get; set; }
        public RelayCommand AddTypeAction { get; set; }
        public Types AddedBookType { get; set; }
        public RelayCommand RemoveTypeAction { get; set; }
        public Types RemoveedBookType { get; set; }
        public List<Types> BookTypes { get; set; }

        public UpdateBookViewModel()
        {
            BookTypes = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            UpdatePriceAction = new RelayCommand(UpdatePrice);
            AddTypeAction = new RelayCommand(AddBookType);
            RemoveTypeAction = new RelayCommand(RemoveBookType);
        }

        private void UpdatePrice()
        {
            if (!double.TryParse(NewPrice.ToString(), out double price)) { MessageBox.Show("You must write only digits in the price box"); }
            else logic.UpdateBookPrice(price);
        }
        private void AddBookType()
        {
            if (AddedBookType == Types.Types) { MessageBox.Show("You must choose a book type to add it"); }
            else logic.AddBookType(AddedBookType);
        }
        private void RemoveBookType()
        {
            if (RemoveedBookType == Types.Types) { MessageBox.Show("You must choose a book type to remove it"); }
            else logic.RemoveBookType(RemoveedBookType);
        }
    }
}
