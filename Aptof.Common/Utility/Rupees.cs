using System;
using System.Collections.Generic;
using System.Text;

namespace Aptof.Common.Utility
{
    public interface IRupees
    {
        decimal Value { get; set; }
        string InRupees();
        string InWord();
    }

    public class Rupees : IRupees
    {
        public decimal Value { get; set; }

        public Rupees(decimal value)
        {
            Value = value;
        }

        public string InWord()
        {
            string rupees = Value.ToString();
            StringBuilder rupeesBuilder = new StringBuilder();
            rupeesBuilder.Append("Rupees");

            if (string.IsNullOrWhiteSpace(rupees.Trim('0', '.')))
            {
                rupeesBuilder.Append(" Zero");
            }

            else if (!rupees.Contains("."))
            {
                rupeesBuilder.Append(RecursiveFullRupeesInWord(rupees));
            }

            else
            {
                string[] rupeesAndPaisa = rupees.Split('.');
                rupeesBuilder.Append(RecursiveFullRupeesInWord(rupeesAndPaisa[0]));

                if (!string.IsNullOrWhiteSpace(rupeesAndPaisa[1].Trim('0')))
                {
                    if (rupeesAndPaisa[1].Length == 1)
                        rupeesAndPaisa[1] += "0";
                    rupeesBuilder.Append(" and");
                    rupeesBuilder.Append(ConvertTwoDigitToRupeesInWord(rupeesAndPaisa[1].Substring(0, 2)));
                    rupeesBuilder.Append(" Paisa");
                }
            }

            rupeesBuilder.Append(" Only");
            return rupeesBuilder.ToString();
        }


        private string ConvertTwoDigitToRupeesInWord(string twoDigitInString)
        {
            int twoDigit = Convert.ToInt32(twoDigitInString);
            if (twoDigit > 99)
                throw new ArgumentOutOfRangeException();

            string rupeesInWord = string.Empty;

            if (twoDigit < 20)
            {
                rupeesInWord = ZeroToNineteenDigitMap[twoDigit];
            }
            else
            {
                int unitPlace = twoDigit % 10;
                int decimalPlace = twoDigit / 10;
                rupeesInWord = DecimalPlaceMap[decimalPlace] + (unitPlace > 0 ? " " + ZeroToNineteenDigitMap[unitPlace] : "");
            }

            if (twoDigit > 0)
                rupeesInWord = " " + rupeesInWord;
            return rupeesInWord;
        }

        public string InRupees()
        {
            return Value.ToString("C2");
        }

        private readonly string[] ZeroToNineteenDigitMap = new[]
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"
        };

        private readonly string[] DecimalPlaceMap = new[]
        {
            "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        private readonly string[] UnitMapFormLength = new[]
        {
            "", "", "", "Hundred", "Thousand", "Thousand", "Lakh", "Lakh", "Crore",
        };

        private int SubStringLength(int length)
        {
            switch (length)
            {
                case 0:
                case 1:
                case 2:
                    return 0;

                case 3:
                case 4:
                case 6:
                    return 1;

                case 5:
                case 7:
                    return 2;



                default:
                    return length - 7;
            }

        }

        private string RecursiveFullRupeesInWord(string rupees)
        {
            if (rupees.Length <= 2)
            {
                return ConvertTwoDigitToRupeesInWord(rupees);
            }
            else
            {
                string digitsToConsider = rupees.Substring(0, SubStringLength(rupees.Length));

                string unit = GetUnit(digitsToConsider, rupees.Length);

                return RecursiveFullRupeesInWord(digitsToConsider) + unit + RecursiveFullRupeesInWord(rupees.Substring(SubStringLength(rupees.Length)));
            }
        }

        private string GetUnit(string digitsToConsider, int length)
        {
            if (string.IsNullOrWhiteSpace(digitsToConsider.Trim('0')))
                return "";
            else if (length > 7)
                return " " + UnitMapFormLength[8];
            else return " " + UnitMapFormLength[length];
        }
    }
}
