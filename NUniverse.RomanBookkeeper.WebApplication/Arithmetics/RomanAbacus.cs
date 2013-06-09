using System;
using System.Collections.Generic;
using System.Globalization;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class RomanAbacus : Abacus
    {
        private const char symbolOneThousand = 'M';
        private const char symbolFiveHundred = 'D';
        private const char symbolOneHundred = 'C';
        private const char symbolFifty = 'L';
        private const char symbolTen = 'X';
        private const char symbolFive = 'V';
        private const char symbolOne = 'I';

        protected override bool TryParse(string input, out List<Bead> beads)
        {
            beads = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            beads = new List<Bead>();
            int index = 0;

            while (index < input.Length)
            {
                try
                {
                    switch (input[index])
                    {
                        case symbolOneThousand:
                            beads.Add(new Bead(symbolOneThousand.ToString(CultureInfo.InvariantCulture)));
                            break;
                        case symbolFiveHundred:
                            beads.AddRange(HandleSymbolFiveHundred(input, index));
                            break;
                        case symbolOneHundred:
                            beads.AddRange(HandleSymbolOneHundred(input, ref index));
                            break;
                        case symbolFifty:
                            beads.AddRange(HandleSymbolFifty(input, ref index));
                            break;
                        case symbolFive:
                            beads.AddRange(HandleSymbolFive(input, ref index));
                            break;
                        case symbolTen:
                            beads.AddRange(HandleSymbolTen(input, ref index));
                            break;
                        case symbolOne:
                            beads.AddRange(HandleSymbolOne(input, ref index));
                            break;
                        default:
                            // only M, D, C, L, X, V and I are valid Roman symbols, everything else is considered invalid symbol
                            return false;
                    }
                }
                catch (InvalidOperationException)
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        protected override Rode GetInitialRode()
        {
            throw new NotImplementedException();
        }

        private static Bead[] HandleSymbolFiveHundred(string input, int currentIndex)
        {
            if (currentIndex + 1 < input.Length && input.Substring(currentIndex, 2) == "DD")
            {
                // ...DD... case is invalid
                throw new InvalidOperationException();
            }

            if (currentIndex + 1 < input.Length && input.Substring(currentIndex, 2) == "DM")
            {
                // ...DM... case is invalid
                throw new InvalidOperationException();
            }

            return CreateBeads(symbolFiveHundred);
        }

        private static Bead[] HandleSymbolOneHundred(string input, ref int currentIndex)
        {
            if (currentIndex + 3 < input.Length && input.Substring(currentIndex, 4) == "CCCC")
            {
                // ...CCCC... case is invalid
                throw new InvalidOperationException();
            }

            if (currentIndex + 2 < input.Length)
            {
                // handle CM case
                if (input[currentIndex + 1] == symbolOneThousand)
                {
                    currentIndex++;
                    return CreateBeads(symbolOneHundred, 9);
                }

                // handle CD case
                if (input[currentIndex + 1] == symbolFiveHundred)
                {
                    currentIndex++;
                    return CreateBeads(symbolOneHundred, 4);
                }
            }

            return CreateBeads(symbolOneHundred);
        }

        private static IEnumerable<Bead> HandleSymbolFifty(string input, ref int currentIndex)
        {
            if (currentIndex + 1 < input.Length && input.Substring(currentIndex, 2) == "LL")
            {
                // ...LL... case is invalid
                throw new InvalidOperationException();
            }

            return CreateBeads(symbolFifty);
        }

        private static Bead[] HandleSymbolTen(string input, ref int currentIndex)
        {
            if (currentIndex + 3 < input.Length && input.Substring(currentIndex, 4) == "XXXX")
            {
                // ...XXXX... case is invalid
                throw new InvalidOperationException();
            }

            if (currentIndex + 2 < input.Length)
            {
                // handle XM case
                if (input[currentIndex + 1] == symbolOneThousand)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 9));
                    beads.AddRange(CreateBeads(symbolTen));
                    return beads.ToArray();
                }

                // handle XD case
                if (input[currentIndex + 1] == symbolFiveHundred)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 4));
                    beads.AddRange(CreateBeads(symbolTen, 9));
                    return beads.ToArray();
                }

                // handle XC case
                if (input[currentIndex + 1] == symbolOneHundred)
                {
                    currentIndex++;
                    return CreateBeads(symbolTen, 9);
                }

                // handle XL case
                if (input[currentIndex + 1] == symbolFifty)
                {
                    currentIndex++;
                    return CreateBeads(symbolTen, 4);
                }
            }

            return CreateBeads(symbolTen);
        }

        private static Bead[] HandleSymbolFive(string input, ref int currentIndex)
        {
            if (currentIndex + 1 < input.Length)
            {
                if (input.Substring(currentIndex, 2) == "VV")
                {
                    // ...VV... case is invalid
                    throw new InvalidOperationException();
                }

                if (input.Substring(currentIndex, 2) == "VX")
                {
                    // ...VX... case is invalid
                    throw new InvalidOperationException();
                }
            }

            if (currentIndex + 2 < input.Length)
            {
                // handle VM case
                if (input[currentIndex + 1] == symbolOneThousand)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 9));
                    beads.AddRange(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    return beads.ToArray();
                }

                // handle VD case
                if (input[currentIndex + 1] == symbolFiveHundred)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 4));
                    beads.AddRange(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    return beads.ToArray();
                }

                // handle VC case
                if (input[currentIndex + 1] == symbolOneHundred)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    return beads.ToArray();
                }

                // handle VL case
                if (input[currentIndex + 1] == symbolFifty)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    return beads.ToArray();
                }
            }

            return CreateBeads(symbolFive);
        }

        private static Bead[] HandleSymbolOne(string input, ref int currentIndex)
        {
            if (currentIndex + 3 < input.Length && input.Substring(currentIndex, 4) == "IIII")
            {
                // ...IIII... case is invalid
                throw new InvalidOperationException();
            }

            if (currentIndex + 2 < input.Length)
            {
                // handle IM case
                if (input[currentIndex + 1] == symbolOneThousand)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 9));
                    beads.AddRange(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    beads.AddRange(CreateBeads(symbolOne, 4));
                    return beads.ToArray();
                }

                // handle ID case
                if (input[currentIndex + 1] == symbolFiveHundred)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolOneHundred, 4));
                    beads.AddRange(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    beads.AddRange(CreateBeads(symbolOne, 4));
                    return beads.ToArray();
                }

                // handle IC case
                if (input[currentIndex + 1] == symbolOneHundred)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolFifty));
                    beads.AddRange(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    beads.AddRange(CreateBeads(symbolOne, 4));
                    return beads.ToArray();
                }

                // handle IL case
                if (input[currentIndex + 1] == symbolFifty)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolTen, 4));
                    beads.AddRange(CreateBeads(symbolFive));
                    beads.AddRange(CreateBeads(symbolOne, 4));
                    return beads.ToArray();
                }

                // handle IX case
                if (input[currentIndex + 1] == symbolTen)
                {
                    currentIndex++;
                    List<Bead> beads = new List<Bead>(CreateBeads(symbolFive));
                    beads.AddRange(CreateBeads(symbolOne, 4));
                    return beads.ToArray();
                }

                //handle IV case
                if (input[currentIndex + 1] == symbolFive)
                {
                    currentIndex++;
                    return CreateBeads(symbolOne, 4);
                }
            }

            return CreateBeads(symbolOne);
        }

        private static Bead[] CreateBeads(char symbol, int count = 1)
        {
            Bead[] array = new Bead[count];

            for (int index = 0; index < count; index++)
            {
                array[index] = new Bead(symbol.ToString(CultureInfo.InvariantCulture));
            }

            return array;
        }
    }
}