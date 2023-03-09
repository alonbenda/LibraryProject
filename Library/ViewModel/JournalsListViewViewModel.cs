using BookLib;
using GalaSoft.MvvmLight;
using LibraryLogic;
using System.Collections.ObjectModel;

namespace Library.ViewModel
{
    public class JournalsListViewViewModel : ViewModelBase
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        readonly SearchViewModel searchViewModel = new SearchViewModel();

        private Journal selectedJournal;
        public Journal SelectedJournal { get => selectedJournal; set => Set(ref selectedJournal, value); }

        public ObservableCollection<Journal> Journals { get; set; }
        public JournalsListViewViewModel()
        {
            CreateList();
            logic.AddJournalAction += AddJournal;
            logic.SearchJournalAction += SearchJournals;
            logic.SaleJournalAction += SaleJournal;
            logic.RemoveJournalAction += RemoveJournal;
            logic.ShowAllAction += ShowAllJournals;
            logic.UpdateJournalPriceAction += UpdatePrice;
            logic.AddJournalTypeAction += AddType;
            logic.RemoveJournalTypeAction += RemoveType;
        }

        private void CreateList()
        {
            Journals = new ObservableCollection<Journal>();
            ShowAllJournals();
        }

        #region Update
        private void UpdatePriceDiscount()
        {
            SelectedJournal.UpdateDiscuont();
            SelectedJournal.UpdatePrice();
        }
        private void UpdatePrice(double price)
        {
            SelectedJournal.Price = price;
            SelectedJournal.UpdatePrice();
        }
        private void AddType(Types type)
        {
            if (!SelectedJournal.Type.HasFlag(type))
            {
                SelectedJournal.Type |= type;
                UpdatePriceDiscount();
            }
        }
        private void RemoveType(Types type)
        {
            if (SelectedJournal.Type.HasFlag(type)) { SelectedJournal.Type -= type; }
            UpdatePriceDiscount();
        }
        #endregion Update

        private void ShowAllJournals()
        {
            Journals.Clear();
            foreach (AbstractItem abstractItem in logic.AbstractItems)
            {
                if (abstractItem is Journal j)
                {
                    Journals.Add(j);
                }
            }
        }

        #region Remove
        private void SaleJournal()
        {
            if (selectedJournal != null)
            {
                SelectedJournal.Copies--;
                if (selectedJournal.Copies == 0)
                {
                    RemoveJournal();
                }
            }
        }
        private void RemoveJournal()
        {
            logic.AbstractItems.Remove(SelectedJournal);
            Journals.Remove(SelectedJournal);
        }
        #endregion Remove

        private void AddJournal(Journal journal)
        {
            Journals.Add(journal);
        }

        private void SearchJournals(string title, string author, Months publishedMonth, Types Type)
        {
            Journals.Clear();
            if (string.IsNullOrEmpty(title))
            {
                title = default;
            }
            if (string.IsNullOrEmpty(author))
            {
                author = default;
            }
            foreach (Journal journal in searchViewModel.GetJournals(logic.AbstractItems, title, publishedMonth, author, Type))
            {
                Journals.Add(journal);
            }
        }
    }
}
