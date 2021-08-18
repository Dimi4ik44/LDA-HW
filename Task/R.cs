using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class R : T
    {
        public override void test()
        {
            base.test();
        }

        public override void test1()
        {
            throw new NotImplementedException();
        }
    }
}
