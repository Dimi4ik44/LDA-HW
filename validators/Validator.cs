using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    abstract class Validator<T> : IValidator<T>
    {
        public abstract bool IsValueValid(T value);
    }
}
