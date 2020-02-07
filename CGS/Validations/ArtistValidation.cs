using System;
using System.Collections.Generic;
using System.Text;

namespace CGS.Validations
{
    public class ArtistValidation : Validation
    {
        public static bool IsNameValid(string lname)
        {
            return IsAtMost40Char(lname);
        }
    }
}
