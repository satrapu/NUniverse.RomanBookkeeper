using System.Collections.Generic;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class RomanSymbolComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x.CompareTo('M') == 0)
            {
                if (y.CompareTo('M') == 0)
                {
                    return 0;
                }

                return -1;
            }
            else
            {

            }

            return 0;
        }
    }
}