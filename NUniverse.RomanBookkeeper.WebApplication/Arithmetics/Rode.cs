using System;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    /// <summary>
    /// Represents a part of an abacus which holds beads (or balls).
    /// </summary>
    public abstract class Rode
    {
        private int beadsCount;

        public int BeadsCount
        {
            get
            {
                return beadsCount;
            }
        }

        public int? BeadThreshold
        {
            get;
            private set;
        }

        public Rode UpperRode
        {
            get;
            private set;
        }

        protected Rode()
        {
            beadsCount = 0;
        }

        protected Rode(int? beadThreshold, Rode upperRode)
            : this()
        {
            if (beadThreshold.HasValue && beadThreshold <= 0)
            {
                throw new ArgumentOutOfRangeException("beadThreshold", beadThreshold, "Bead threshold must be null or a positive integer");
            }

            BeadThreshold = beadThreshold;
            UpperRode = upperRode;
        }

        public void Add(Bead bead)
        {
            if (Accepts(bead))
            {
                if (BeadThreshold.HasValue)
                {
                    if (beadsCount < BeadThreshold.Value)
                    {
                        beadsCount++;
                    }
                    else
                    {
                        string higherRankedSymbol = GetHigherRankedSymbol(bead.Symbol);

                        if (higherRankedSymbol == null)
                        {
                            beadsCount++;
                        }
                        else
                        {
                            beadsCount = 1;
                            UpperRode.Add(new Bead(higherRankedSymbol));
                        }
                    }
                }
                else
                {
                    beadsCount++;
                }
            }
            else if (UpperRode != null)
            {
                UpperRode.Add(bead);
            }
        }

        protected abstract bool Accepts(Bead bead);
        protected abstract string GetHigherRankedSymbol(string symbol);
    }
}