using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class ArabicAbacus : Abacus
    {
        private const string digits = "0123456789";
        private readonly List<Rode> rodes;
        private readonly int digitThreshold;

        public ArabicAbacus(int digitThreshold)
        {
            if (digitThreshold < 1)
            {
                throw new ArgumentOutOfRangeException("digitThreshold", "Digit threshold must be a positive integer");
            }

            this.digitThreshold = digitThreshold;
            rodes = new List<Rode>(this.digitThreshold);
            Rode lastRode = new ArabicRode();

            for (int index = this.digitThreshold; index > 0; index--)
            {
                Rode rode = new ArabicRode(lastRode);
                rodes.Add(rode);
                lastRode = rode;
            }

            rodes.Reverse();
        }

        public override bool TryParse(string input, out List<Bead> beads)
        {
            beads = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string normalizedInput = input.TrimStart('0');
            beads = new List<Bead>();
            int digitCount = 1;
            int index;

            for (index = 0; index < normalizedInput.Length; index++)
            {
                char currentSymbol = normalizedInput[index];

                if (!digits.Contains(currentSymbol))
                {
                    return false;
                }

                if (digitCount > digitThreshold)
                {
                    return false; // the given input contains more digits than this abacus can handle
                }

                digitCount++;
                beads.Add(new Bead(string.Format("{0}{1}", currentSymbol, new string('0', normalizedInput.Length - index - 1))));
            }

            return true;
        }

        protected override Rode GetInitialRode()
        {
            return rodes.First();
        }

        protected override string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            for (int rodeIndex = rodes.Count - 1; rodeIndex >= 0; rodeIndex--)
            {
                Rode rode = rodes[rodeIndex];
                sb.Append(rode.BeadsCount);
            }

            string result = sb.ToString();
            return result;
        }
    }
}