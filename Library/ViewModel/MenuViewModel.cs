using GalaSoft.MvvmLight.Command;
using Library.Views;

namespace Library.ViewModel
{
    public class MenuViewModel
    {
        public RelayCommand SearchAction { get; set; }
        public RelayCommand AddBookAction { get; set; }
        public RelayCommand RemoveBookAction { get; set; }
        public RelayCommand ShowAllItemsAction { get; set; }
        public RelayCommand UpdateAction { get; set; }

        public MenuViewModel()
        {
            SearchAction = new RelayCommand(OpenSearch);
            AddBookAction = new RelayCommand(OpenAdd);
            RemoveBookAction = new RelayCommand(OpenRemove);
            ShowAllItemsAction = new RelayCommand(OpenShowAll);
            UpdateAction = new RelayCommand(OpenUpdate);
        }

        private void OpenAdd()
        {
            AddView addView = new AddView();
            addView.Show();
        }
        private void OpenSearch()
        {
            SearchView searchView = new SearchView();
            searchView.Show();
        }
        private void OpenRemove()
        {
            RemoveView removeView = new RemoveView();
            removeView.Show();
        }
        private void OpenShowAll()
        {
            ShowAllWindow showView = new ShowAllWindow();
            showView.Show();
        }
        private void OpenUpdate()
        {
            UpdateView updateView = new UpdateView();
            updateView.Show();
        }
    }
}
