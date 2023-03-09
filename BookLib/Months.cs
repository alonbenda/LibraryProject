using System;

namespace BookLib
{
    [Flags]
    public enum Months
    {
        Months = 0,
        Jan = 1,
        Feb = 2,
        Mar = 4,
        Apr = 8,
        May = 16,
        June = 32,
        Jul = 64,
        Aug = 128,
        Sep = 256,
        Oct = 512,
        November = 1024,
        December = 2048,
    }
}
