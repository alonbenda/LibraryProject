using System;

namespace BookLib
{
    [Flags]
    public enum Types
    {
        Types = 0,
        Drama = 1,
        Horror = 2,
        Comedy = 4,
        Fantasy = 8,
        ScienceFiction = 16,
        Novel = 32,
        Romance = 64,
        Comics = 128,
        Action = 256
    }
}
