using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    class IntBelowZero : Validator<int>
    {
        public override bool IsValueValid(int value)
        {
            return value < 0;
        }
    }
}
