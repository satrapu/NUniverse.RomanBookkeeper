using System;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class Bead
    {
        public string Symbol
        {
            get;
            private set;
        }

        public Bead(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol must not be null, empty or whitespace string", "symbol");
            }

            Symbol = symbol;
        }
    }
}