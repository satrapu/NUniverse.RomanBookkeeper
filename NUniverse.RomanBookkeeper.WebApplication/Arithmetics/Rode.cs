using System;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    /// <summary>
    /// Represents a part of an abacus which holds beads (or balls).
    /// </summary>
    public class Rode
    {
        private int numberOfPresentBeads;

        public int BeadThreshold
        {
            get;
            private set;
        }

        public string Symbol
        {
            get;
            private set;
        }

        public Rode UpperRode
        {
            get;
            private set;
        }

        public Rode(string symbol, int beadThreshold, Rode upperRode)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol was not set", "symbol");
            }

            if (beadThreshold <= 0)
            {
                throw new ArgumentOutOfRangeException("beadThreshold", beadThreshold, "Bead threshold must be a positive integer");
            }

            numberOfPresentBeads = 0;
            Symbol = symbol;
            BeadThreshold = beadThreshold;
            UpperRode = upperRode;
        }

        public void AddBead(Bead bead)
        {
            if (bead.Symbol == Symbol)
            {
                if (numberOfPresentBeads < BeadThreshold)
                {
                    numberOfPresentBeads++;
                }
                else
                {
                    ClearBeads();
                    UpperRode.AddBead(bead);
                }
            }
            else
            {
                UpperRode.AddBead(bead);
            }
        }

        public void ClearBeads()
        {
            numberOfPresentBeads = 0;
        }
    }
}