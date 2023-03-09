using BookLib;
using GalaSoft.MvvmLight.Command;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library.ViewModel
{
    public class UpdateJournalViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand UpdatePriceAction { get; set; }
        public string NewPrice { get; set; }
        public RelayCommand AddTypeAction { get; set; }
        public Types AddedJournalType { get; set; }
        public RelayCommand RemoveTypeAction { get; set; }
        public Types RemoveedJournalType { get; set; }
        public List<Types> JournalTypes { get; set; }

        public UpdateJournalViewModel()
        {
            JournalTypes = Enum.GetValues(typeof(Types)).Cast<Types>().ToList();
            UpdatePriceAction = new RelayCommand(UpdatePrice);
            AddTypeAction = new RelayCommand(AddJournalType);
            RemoveTypeAction = new RelayCommand(RemoveJournalType);
        }

        private void UpdatePrice()
        {
            if (!double.TryParse(NewPrice.ToString(), out double price)) { MessageBox.Show("You must write only digits in the price box"); }
            else logic.UpdateJournalPrice(price);
        }
        private void AddJournalType()
        {
            if (AddedJournalType == Types.Types) { MessageBox.Show("You must choose a book type to add it"); }
            else logic.AddJournalType(AddedJournalType);
        }
        private void RemoveJournalType()
        {
            if (RemoveedJournalType == Types.Types) { MessageBox.Show("You must choose a book type to remove it"); }
            else logic.RemoveJournalType(RemoveedJournalType);
        }
    }
}
