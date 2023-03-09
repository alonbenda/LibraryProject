using GalaSoft.MvvmLight.Command;
using LibraryLogic;

namespace Library.ViewModel
{
    public class RemoveBookViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand SaleItems { get; set; }
        public RelayCommand RemoveItems { get; set; }
        public RemoveBookViewModel()
        {
            SaleItems = new RelayCommand(SaleItem);
            RemoveItems = new RelayCommand(RemoveItem);
        }

        private void SaleItem()
        {
            logic.SaleBook();
        }
        private void RemoveItem()
        {
            logic.RemoveBook();
        }
    }
}
