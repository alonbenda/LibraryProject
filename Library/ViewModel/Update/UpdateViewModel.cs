using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Library.ViewModel
{
    public class UpdateViewModel : ViewModelBase
    {
        public RelayCommand UpdateBookViewAction { get; set; }
        public RelayCommand UpdateJournalViewAction { get; set; }

        private double updateBooksWidth;
        public double UpdateBooksWidth { get => updateBooksWidth; set => Set(ref updateBooksWidth, value); }

        private double updateJournalsWidth;
        public double UpdateJournalsWidth { get => updateJournalsWidth; set => Set(ref updateJournalsWidth, value); }

        public UpdateViewModel()
        {
            UpdateBookViewAction = new RelayCommand(BookViewToDisplay);
            UpdateJournalViewAction = new RelayCommand(JournalViewToDisplay);
        }
        private void BookViewToDisplay()
        {
            UpdateBooksWidth = SystemParameters.PrimaryScreenWidth;
            UpdateJournalsWidth = 0;
        }
        private void JournalViewToDisplay()
        {
            UpdateBooksWidth = 0;
            UpdateJournalsWidth = SystemParameters.PrimaryScreenWidth;
        }
    }
}
