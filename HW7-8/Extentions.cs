using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    static class Extentions
    {
        public static Product[] ProductsAppend(this Product[] p,Product[] arrayOfProducts)
        {
            int tempLen = p.Length;
            Array.Resize(ref p,p.Length+arrayOfProducts.Length);
            for (int i = 0; i < arrayOfProducts.Length; i++)
            {
                p[tempLen+i] = arrayOfProducts[i];
            }
            return p;
        }
        public static Product[] ProductRemoveByIndex(this Product[] p, int index)
        {
            if (index + 1 > p.Length || index < 0) return p;
            Product[] d = new Product[p.Length - 1];
            int counter = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (i == index) continue;
                d[counter] = p[i];
                counter++;
            }
            return d;
        }
        public static Product[] ProductRemoveByIndex(this Product[] p, int[] index)
        {
            for (int i = 0; i < index.Length; i++)
            {
                if (index[i]+1 > p.Length || index[i] < 0) return p;
            }
            Product[] ptemp = p;
            for (int k = index.Length-1; k >= 0; k--)
            {
                Product[] d = new Product[ptemp.Length - 1];
                int counter = 0;
                for (int i = 0; i < ptemp.Length; i++)
                {
                    if (i == index[k]) continue;
                    d[counter] = ptemp[i];
                    counter++;
                }
                ptemp = d;
            }
            return ptemp;
        }
    }
}
