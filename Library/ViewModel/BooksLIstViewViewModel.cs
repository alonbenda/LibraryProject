using BookLib;
using GalaSoft.MvvmLight;
using LibraryLogic;
using System.Collections.ObjectModel;

namespace Library.ViewModel
{
    public class BooksLIstViewViewModel : ViewModelBase
    {
        readonly ItemsCollection logic = ItemsCollection.Instance;
        readonly SearchViewModel searchViewModel = new SearchViewModel();

        private Book selectedBook;
        public Book SelectedBook { get => selectedBook; set => Set(ref selectedBook, value); }

        public ObservableCollection<Book> Books { get; set; }
        public BooksLIstViewViewModel()
        {
            CreateList();
            logic.AddBookAction += AddBook;
            logic.SearchBookAction += SearchBooks;
            logic.SaleBookAction += SaleBook;
            logic.RemoveBookAction += RemoveBook;
            logic.ShowAllAction += ShowAllBooks;
            logic.UpdateBookPriceAction += UpdatePrice;
            logic.AddBookTypeAction += AddType;
            logic.RemoveBookTypeAction += RemoveType;
        }
        //indexer, polymorphysm
        private void CreateList()
        {
            Books = new ObservableCollection<Book>();
            ShowAllBooks();
        }

        #region Update
        /// <summary>
        /// Update a selected book's price and discount.
        /// </summary>
        private void UpdatePriceDiscount()
        {
            SelectedBook.UpdateDiscuont();
            SelectedBook.UpdatePrice();
        }
        private void UpdatePrice(double price)
        {
            selectedBook.Price = price;
            SelectedBook.UpdatePrice();
        }
        private void AddType(Types type)
        {
            if (!selectedBook.Type.HasFlag(type))
            {
                SelectedBook.Type |= type;
                UpdatePriceDiscount();
            }
        }
        private void RemoveType(Types type)
        {
            if (SelectedBook.Type.HasFlag(type))
            {
                SelectedBook.Type -= type;
                UpdatePriceDiscount();
            }            
        }
        #endregion Update

        /// <summary>
        /// Show all the books in the library.
        /// </summary>
        private void ShowAllBooks()
        {
            Books.Clear();
            foreach (AbstractItem abstractItem in logic.AbstractItems)
            {
                if (abstractItem is Book b)
                {
                    Books.Add(b);
                }
            }
        }

        #region Remove
        /// <summary>
        /// Reduce the amount of copies of a selected book.
        /// </summary>
        private void SaleBook()
        {
            if (selectedBook != null)
            {
                SelectedBook.Copies--;
                if (selectedBook.Copies == 0)
                {
                    RemoveBook();
                }
            }
        }

        /// <summary>
        /// Remove a selected book from the books list.
        /// </summary>
        private void RemoveBook()
        {
            logic.AbstractItems.Remove(selectedBook);
            Books.Remove(SelectedBook);
        }
        #endregion Remove

        private void AddBook(Book book)
        {
            Books.Add(book);
        }

        /// <summary>
        /// Search all the books by title, author, published year, book type and ISBN.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publishedYear"></param>
        /// <param name="bookType"></param>
        /// <param name="ISBN"></param>
        private void SearchBooks(string title, string author, int publishedYear, Types bookType, string ISBN)
        {
            Books.Clear();
            if (string.IsNullOrEmpty(title))
            {
                title = default;
            }
            if (string.IsNullOrEmpty(author))
            {
                author = default;
            }
            if (string.IsNullOrEmpty(ISBN))
            {
                ISBN = default;
            }
            foreach (Book book in searchViewModel.GetBooks(logic.AbstractItems, title, publishedYear, author, bookType, ISBN))
            {
                AddBook(book);
            }
        }
    }
}
