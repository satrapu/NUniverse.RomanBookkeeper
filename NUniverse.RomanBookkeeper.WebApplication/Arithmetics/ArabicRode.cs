using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class ArabicRode : Rode
    {
        private static readonly List<string> allDigits = "0123456789".ToCharArray().Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList();

        public ArabicRode()
            : base(9, null)
        {
        }

        public ArabicRode(Rode upperRode)
            : base(9, upperRode)
        {
        }

        protected override bool Accepts(Bead bead)
        {
            return allDigits.All(digit => digit.Equals(bead.Symbol, StringComparison.InvariantCulture));
        }

        protected override string GetHigherRankedSymbol(string symbol)
        {
            for (int index = 0; index < allDigits.Count - 1; index++)
            {
                if (allDigits[index].Equals(symbol, StringComparison.InvariantCulture))
                {
                    return allDigits[index + 1];
                }
            }

            return null;
        }
    }
}