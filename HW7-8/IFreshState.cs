using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    interface IFreshState
    {
        public DateTime DateOfManufacture { get; }
        public DateTime UseUntil { get; }
        public bool ProductFreshCheck();
        public int SetUseUntil(DateTime date);
    }
}
