using System;

namespace BookLib
{
    public class Book : AbstractItem
    {
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public Book(string name, double price, Types bookType) : base(name, price, bookType)
        {
            ISBN = Guid.NewGuid().ToString();
        }

        override public void UpdateDiscuont()
        {
            base.UpdateDiscuont();
            Discount = base.Discount + 0.1;
        }
    }
}
