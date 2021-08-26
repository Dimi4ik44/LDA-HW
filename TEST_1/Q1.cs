using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_1
{
    sealed class Q1 : Q2Abstract , IInterface , IInterface1
    {
        static int q1Count = 0;
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int field;
        public int field1;
        public int Field { get; }
        public int Field1 { get; private set; }
        public int MyIProperty { get; set; }

        public Q1(int p,int p1, int p2)
        {
            MyProperty = p;
            MyProperty1 = p1;
            MyProperty2 = p2;
            q1CountIncrement();
        }
        public void FuncQ(int a)
        {

        }
        public int FuncQ1()
        {
            return 1;
        }
        public static void q1CountIncrement()
        {
            q1Count++;
        }

        public override void Func()
        {
            
        }

        public override void Func1()
        {
            base.Func1();
        }

        void IInterface.IFunc()
        {
            Console.WriteLine("Interface");
        }
        void IInterface1.IFunc()
        {
            Console.WriteLine("Interface1");
        }
        public override string ToString()
        {
            return "MyBaseClass";
        }
    }
}
