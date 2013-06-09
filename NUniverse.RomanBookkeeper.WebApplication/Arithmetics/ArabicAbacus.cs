using System.Collections.Generic;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class ArabicAbacus : Abacus
    {
        protected override bool TryParse(string input, out List<Bead> beads)
        {
            beads = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            beads = new List<Bead>();
            int index;

            for (index = input.Length - 1; index >= 0; index--)
            {
                beads.Add(new Bead(string.Format("{0}{1}", input[index], new string('0', index))));
            }

            return false;
        }

        protected override Rode GetInitialRode()
        {
            throw new System.NotImplementedException();
        }
    }
}