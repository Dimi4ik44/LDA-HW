using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    interface IValidator<T>
    {
        public abstract bool IsValueValid(T value);
    }
}
