using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Library.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public RelayCommand AddBookViewAction { get; set; }
        public RelayCommand AddJournalViewAction { get; set; }

        private double addBookWidth;
        public double AddBookWidth { get => addBookWidth; set => Set(ref addBookWidth, value); }

        private double addJournalWidth;
        public double AddJournalWidth { get => addJournalWidth; set => Set(ref addJournalWidth, value); }

        public AddViewModel()
        {
            AddBookViewAction = new RelayCommand(BookViewToDisplay);
            AddJournalViewAction = new RelayCommand(JournalViewToDisplay);
        }
        private void BookViewToDisplay()
        {
            AddBookWidth = SystemParameters.PrimaryScreenWidth;
            AddJournalWidth = 0;
        }
        private void JournalViewToDisplay()
        {
            AddBookWidth = 0;
            AddJournalWidth = SystemParameters.PrimaryScreenWidth;
        }
    }
}
