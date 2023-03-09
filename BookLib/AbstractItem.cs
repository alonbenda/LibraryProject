namespace BookLib
{
    public abstract class AbstractItem
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public double PriceAfterDiscount { get; set; }
        public double Discount { get; set; }
        public int Copies { get; set; }
        public string Author { get; set; }
        public Types Type { get; set; }
        public AbstractItem(string name, double price, Types type)
        {
            Title = name;
            Copies = 20;
            Price = price;
            Type = type;
            UpdateDiscuont();
            UpdatePrice();
        }

        virtual public void UpdateDiscuont()
        {
            double highestDiscuont = 0;
            if (Type.HasFlag(Types.Drama))
            {
                if (highestDiscuont < 0.1)
                    highestDiscuont = 0.1;
            }
            if (Type.HasFlag(Types.Horror))
            {
                if (highestDiscuont < 0.15)
                    highestDiscuont = 0.15;
            }
            if (Type.HasFlag(Types.Comedy))
            {
                if (highestDiscuont < 0.4)
                    highestDiscuont = 0.4;
            }
            if (Type.HasFlag(Types.Fantasy))
            {
                if (highestDiscuont < 0.1)
                    highestDiscuont = 0.1;
            }
            if (Type.HasFlag(Types.ScienceFiction))
            {
                if (highestDiscuont < 0.2)
                    highestDiscuont = 0.2;
            }
            if (Type.HasFlag(Types.Novel))
            {
                if (highestDiscuont < 0.25)
                    highestDiscuont = 0.25;
            }
            if (Type.HasFlag(Types.Romance))
            {
                if (highestDiscuont < 0.4)
                    highestDiscuont = 0.4;
            }
            if (Type.HasFlag(Types.Comics))
            {
                if (highestDiscuont < 0.3)
                    highestDiscuont = 0.3;
            }
            if (Type.HasFlag(Types.Action))
            {
                if (highestDiscuont < 0.1)
                    highestDiscuont = 0.1;
            }
            Discount = highestDiscuont;
        }
        public void UpdatePrice()
        {
            PriceAfterDiscount = Price * (1 - Discount);
        }
    }
}
