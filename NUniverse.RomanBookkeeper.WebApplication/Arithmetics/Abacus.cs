using System;
using System.Collections.Generic;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public abstract class Abacus
    {
        public string Add(string leftOperand, string rightOperand)
        {
            Rode initialRode = GetInitialRode();

            if (initialRode == null)
            {
                throw new InvalidOperationException("This abacus has no rodes, thus is unable to perform any additions");
            }

            List<Bead> leftOperandBeads;
            List<Bead> rightOperandBeads;

            if (!TryParse(leftOperand, out leftOperandBeads))
            {
                throw new ArgumentException(string.Format("{0} is not a valid numeral", leftOperand), "leftOperand");
            }

            if (!TryParse(rightOperand, out rightOperandBeads))
            {
                throw new ArgumentException(string.Format("{0} is not a valid numeral", rightOperand), "rightOperand");
            }

            List<Bead> beads = new List<Bead>();
            beads.AddRange(leftOperandBeads);
            beads.AddRange(rightOperandBeads);

            foreach (Bead bead in beads)
            {
                initialRode.AddBead(bead);
            }

            return null;
        }

        protected abstract bool TryParse(string input, out List<Bead> beads);
        protected abstract Rode GetInitialRode();
    }
}