using System;
using System.Collections.Generic;
using System.Text;

namespace validators
{
    class ValidatorList<T>
    {
        public List<Validator<T>> vlist { get; set; } = new List<Validator<T>>();
    }
}
