/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Library"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace Library.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<MenuViewModel>();

            SimpleIoc.Default.Register<SearchViewModel>();

            SimpleIoc.Default.Register<AddViewModel>();

            SimpleIoc.Default.Register<BooksLIstViewViewModel>();

            SimpleIoc.Default.Register<JournalsListViewViewModel>();

            SimpleIoc.Default.Register<AddBookViewModel>();

            SimpleIoc.Default.Register<AddJournalViewModel>();

            SimpleIoc.Default.Register<SearchBookViewModel>();

            SimpleIoc.Default.Register<SearchJournalViewModel>();

            SimpleIoc.Default.Register<RemoveViewModel>();

            SimpleIoc.Default.Register<RemoveBookViewModel>();

            SimpleIoc.Default.Register<RemoveJournalViewModel>();

            SimpleIoc.Default.Register<ShowAllViewModel>();

            SimpleIoc.Default.Register<UpdateViewModel>();

            SimpleIoc.Default.Register<UpdateBookViewModel>();

            SimpleIoc.Default.Register<UpdateJournalViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MenuViewModel Menu => ServiceLocator.Current.GetInstance<MenuViewModel>();
        public SearchViewModel Search => ServiceLocator.Current.GetInstance<SearchViewModel>();
        public AddViewModel Add => ServiceLocator.Current.GetInstance<AddViewModel>();
        public BooksLIstViewViewModel BooksLIstView => ServiceLocator.Current.GetInstance<BooksLIstViewViewModel>();
        public JournalsListViewViewModel JournalsListView => ServiceLocator.Current.GetInstance<JournalsListViewViewModel>();
        public AddBookViewModel AddBook => ServiceLocator.Current.GetInstance<AddBookViewModel>();
        public AddJournalViewModel AddJournal => ServiceLocator.Current.GetInstance<AddJournalViewModel>();
        public SearchBookViewModel SearchBook => ServiceLocator.Current.GetInstance<SearchBookViewModel>();
        public SearchJournalViewModel SearchJournal => ServiceLocator.Current.GetInstance<SearchJournalViewModel>();
        public RemoveViewModel Remove => ServiceLocator.Current.GetInstance<RemoveViewModel>();
        public RemoveBookViewModel RemoveBook => ServiceLocator.Current.GetInstance<RemoveBookViewModel>();
        public RemoveJournalViewModel RemoveJournal => ServiceLocator.Current.GetInstance<RemoveJournalViewModel>();
        public ShowAllViewModel ShowAll => ServiceLocator.Current.GetInstance<ShowAllViewModel>();
        public UpdateViewModel Update => ServiceLocator.Current.GetInstance<UpdateViewModel>();
        public UpdateBookViewModel UpdateBook => ServiceLocator.Current.GetInstance<UpdateBookViewModel>();
        public UpdateJournalViewModel UpdateJournal => ServiceLocator.Current.GetInstance<UpdateJournalViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}