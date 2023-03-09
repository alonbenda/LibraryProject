using GalaSoft.MvvmLight.Command;
using LibraryLogic;

namespace Library.ViewModel
{
    public class RemoveJournalViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand SaleItems { get; set; }
        public RelayCommand RemoveItems { get; set; }
        public RemoveJournalViewModel()
        {
            SaleItems = new RelayCommand(SaleItem);
            RemoveItems = new RelayCommand(RemoveItem);
        }

        private void SaleItem()
        {
            logic.SaleJournal();
        }
        private void RemoveItem()
        {
            logic.RemoveJournal();
        }
    }
}
