using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    class StringStartWithUpperCase : Validator<string>
    {
        public override bool IsValueValid(string value)
        {
            return char.IsUpper(value.Trim().ToCharArray()[0]);
        }
    }
}
