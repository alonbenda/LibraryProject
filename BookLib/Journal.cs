namespace BookLib
{
    public class Journal : AbstractItem
    {
        public Months JournalMonth { get; set; }
        public Journal(string name, double price, Types journalType) : base(name, price, journalType)
        {
        }
        public override void UpdateDiscuont()
        {
            base.UpdateDiscuont();
            Discount = base.Discount + 0.05;
        }
    }
}
