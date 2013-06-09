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
                throw new ArgumentNullException("symbol", "Symbol was not set");
            }

            Symbol = symbol;
        }
    }
}