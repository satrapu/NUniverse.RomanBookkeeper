using System;
using System.Globalization;
using System.Linq;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class RomanRode : Rode
    {
        private const string romanSymbols = "MDCLXVI";

        public RomanRode(string symbol, int? beadThreshold, Rode upperRode)
            : base(beadThreshold, upperRode)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Roman symbol was not set", "symbol");
            }

            bool isRomanSymbol = romanSymbols.Any(romanSymbol => romanSymbol.ToString(CultureInfo.InvariantCulture).Equals(symbol));

            if (!isRomanSymbol)
            {
                throw new ArgumentException(string.Format("{0} is not a valid Roman symbol", symbol), "symbol");
            }

            Symbol = symbol;
        }

        protected override bool Accepts(Bead bead)
        {
            return Symbol.Equals(bead.Symbol, StringComparison.InvariantCulture);
        }

        protected override string GetHigherRankedSymbol(string symbol)
        {
            for (int index = 1; index < romanSymbols.Length; index++)
            {
                if (romanSymbols[index].ToString(CultureInfo.InvariantCulture).Equals(symbol, StringComparison.InvariantCulture))
                {
                    return romanSymbols[index - 1].ToString(CultureInfo.InvariantCulture);
                }
            }

            return null;
        }

        public string Symbol
        {
            get;
            private set;
        }
    }
}