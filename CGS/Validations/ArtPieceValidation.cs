using System;
using System.Collections.Generic;
using System.Text;

namespace CGS.Validations
{
    public class ArtPieceValidation : Validation
    {
        public static bool IsTitleValid(string title)
        {
            return IsAtMost40Char(title);
        }

        public static bool IsDateValid(string date)
        {
            bool condition = false;
            if (date.Length == 4)
                condition = true;

            foreach (var character in date)
            {
                if (!Char.IsNumber(character))
                    condition = false;
            }

            return condition;
        }

        public static bool IsEstimedAndPriceValid(string esmited)
        {
            bool condition = true;
            foreach (var character in esmited)
            {
                if (!Char.IsNumber(character))
                    condition = false;
            }
            return condition;
        }

        public static bool IsStatusValid(string status)
        {
            bool condition = false;
            if (status.Length == 1 && (status == "D" || status == "S" || status == "O" || status == "d" || status == "s" || status == "o"))
                condition = true;

            return condition;
        }
    }
}
