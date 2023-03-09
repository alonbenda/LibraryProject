using GalaSoft.MvvmLight.Command;
using LibraryLogic;

namespace Library.ViewModel
{
    public class ShowAllViewModel
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        public RelayCommand ShowAllAction { get; set; }
        public ShowAllViewModel()
        {
            ShowAllAction = new RelayCommand(ShowAll);
        }

        private void ShowAll()
        {
            logic.ShowAllItems();
        }
    }
}
