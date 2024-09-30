using TechnologyOneAssignment.Constants;

namespace TechnologyOneAssignment.Services
{
    public class NumberService : INumberService
    {
        private static readonly decimal _maxNumber = 1000000000000;

        public string ConvertDoubleToStringOfDollarsAndCents(decimal number)
        {
            string strNumber = SantizeNumberAndConvertToString(number);

            if (number == 0)
            {
                return "zero dollars";
            }
            else if (_maxNumber <= number || number < 0)
            {
                return "number out of range (must be between 0 and 1,000,000,000,000)";
            }

            int i = strNumber.Length - 1;
            int placeValuesIndex = 0;
            Stack<string> output = new Stack<string>();
           
            while (i >= 0)
            {
                // Read cents
                if ((i == strNumber.Length - 1 | i == strNumber.Length - 2) & strNumber.Contains('.'))
                {
                    int digitsToRead = 2;
                    List<string> cents = ReadDigitsFromStringOfDollarsAndCents(strNumber, i, digitsToRead);
                    i -= digitsToRead;

                    if (cents.Count > 0)
                    {
                        output.Push("cents");
                        cents.ForEach(output.Push);
                    }

                }
                // Skip decimal point
                else if (strNumber[i].Equals('.'))
                {
                    i--;
                }
                // Read dollars
                else
                {
                    int digitsToRead = 3;
                    List<string> dollars = ReadDigitsFromStringOfDollarsAndCents(strNumber, i, digitsToRead);
                    i -= digitsToRead;

                    if (dollars.Count > 0)
                    {
                        if (!output.Contains("dollars"))
                        {
                            output.Push("dollars");
                        }

                        if (!NumberConstants.placeValues[placeValuesIndex].Equals("hundred"))
                        {
                            output.Push(NumberConstants.placeValues[placeValuesIndex]);
                        }

                        dollars.ForEach(output.Push);
                    }

                    placeValuesIndex++;
                }
            }

            return String.Join(" ", output);
        }

        /***
         * ReadDigitsFromStringOfDollarsAndCents(str number, int i, int digitsToRead)
         * 
         * Inputs:
         *  strNumber: the floating point number as a string
         *  i: the index to begin reading digits from (reading from RHS to LHS i.e least significant bit to most)
         *  digitsToRead: the number of digits to read, should only be set to 2 or 3 - if we are reading cents set to 2 if not set to 3
         *  
         *  Output: a list of strings (in reverse order) of the word equivalents of the digits read
         *      e.g.    input:182
         *              output: two eighty hundred
         */
        private List<string> ReadDigitsFromStringOfDollarsAndCents(string strNumber, int i, int digitsToRead)
        {

            Stack<string> stack = new Stack<string>();

            int digitsSeen = 0;

            while (i >= 0 & digitsSeen < digitsToRead)
            {
                digitsSeen++;

                if (digitsSeen == 1 & !strNumber[i].Equals('0'))
                {
                    int key = (int)Char.GetNumericValue(strNumber[i]);
                    stack.Push(NumberConstants.numbersToNames[key]);
                }
                else if (digitsSeen == 2 & !strNumber[i].Equals('0'))
                {
                    int key = 10 * (int)Char.GetNumericValue(strNumber[i]);
                    string word = "";

                    // special case if 11, 12, 13, 14,... 19
                    if (strNumber[i].Equals('1'))
                    {
                        key += (int)Char.GetNumericValue(strNumber[i + 1]);

                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }

                        word = NumberConstants.numbersToNames[key];
                    }
                    // otherwise hypenate twenty-one, etc.
                    else if (stack.Count > 0)
                    {
                        word = NumberConstants.numbersToNames[key] + "-" + stack.Pop();
                    }
                    stack.Push(word);
                    
                }
                else if (digitsSeen == 3 & !strNumber[i].Equals('0'))
                {
                    int key = (int)Char.GetNumericValue(strNumber[i]);
                    stack.Push(NumberConstants.numbersToNames[100]);
                    stack.Push(NumberConstants.numbersToNames[key]);
                }

                i--;
            }
            List<string> digits = stack.ToList();
            digits.Reverse();

            return digits;
        }

        private string SantizeNumberAndConvertToString(decimal number)
        {
            // Sanitize input
            number = Math.Round(number, 2);
            string strNumber = number.ToString();

            if (strNumber.Contains('.') && strNumber[^2].Equals('.')) 
            {
                strNumber = strNumber + '0';
            }

            return strNumber;
        }
    }
}