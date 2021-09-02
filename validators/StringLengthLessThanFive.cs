using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    class StringLengthLessThanFive : Validator<string>
    {
        public override bool IsValueValid(string value)
        {
            return value.Length < 5;
        }
    }
}
