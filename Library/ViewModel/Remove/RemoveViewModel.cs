using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Library.ViewModel
{
    public class RemoveViewModel : ViewModelBase
    {
        public RelayCommand RemoveBookViewAction { get; set; }
        public RelayCommand RemoveJournalViewAction { get; set; }

        private double removeBookWidth;
        public double RemoveBookWidth { get => removeBookWidth; set => Set(ref removeBookWidth, value); }

        private double removeJournalWidth;
        public double RemoveJournalWidth { get => removeJournalWidth; set => Set(ref removeJournalWidth, value); }

        public RemoveViewModel()
        {
            RemoveBookViewAction = new RelayCommand(BookViewToDisplay);
            RemoveJournalViewAction = new RelayCommand(JournalViewToDisplay);
        }

        private void BookViewToDisplay()
        {
            RemoveBookWidth = SystemParameters.PrimaryScreenWidth;
            RemoveJournalWidth = 0;
        }
        private void JournalViewToDisplay()
        {
            RemoveBookWidth = 0;
            RemoveJournalWidth = SystemParameters.PrimaryScreenWidth;
        }
    }
}
