using System.Collections.Generic;

namespace NUniverse.RomanBookkeeper.WebApplication.Models
{
    public class NumeralSystems
    {
        private static readonly List<string> registeredNumeralSystems;

        static NumeralSystems()
        {
            registeredNumeralSystems = new List<string> { "Roman", "Arabic" };
        }

        public static IEnumerable<string> Values
        {
            get
            {
                return registeredNumeralSystems;
            }
        }
    }
}