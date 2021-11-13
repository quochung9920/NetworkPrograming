using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSAFileServer
{
    public class Algorithm
    {
        public static int Gcd(int a, int b)///Алгоритм Евкліда(найбільший спільний дільник)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
        private static int Gcd(int a, int b, out int x, out int y)///алгоритм Ейлера другий варіант
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            int x1, y1;
            int d = Gcd(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }
        public static int ExpGcd(int a, int m)///розширений алгоритм Евкліда
        {
            int x, y;
            int g = Gcd(a, m, out x, out y);
            if (g != 1)
                throw new ArgumentException();
            return (x % m + m) % m;
        }
        public static int SimpleSqrt(int a)
        {
            int count = 1;
            int l = 1;
            while (a>0)
            {
                a = -l;
                ++count;
                l += 2;
            }
            return count+1;
        }
        public static bool Prime(int n)///Перевірка на простоту
        {
            for (int i = 2; i <= SimpleSqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        public static int Eyler(int n)
        {
            int res = n, en = SimpleSqrt(n) + 1;
            for (int i = 2; i <= en; i++)
            {
                if ((n % i) == 0)
                {
                    while ((n % i) == 0)
                        n /= i;
                    res -= (res / i);
                }
            }
            if (n > 1) res -= (res / n);
            return res;
        }
        public static int RNPG(int a, int b)///рандомна генерація великого простого числа з діапазону [a,b]
        {
            List<int> arr = new List<int>();
            while (a<b)
            {
                if (Prime(a))
                {
                    arr.Add(a);
                }
                a = a + 1;
            }
            Random r = new Random();
            return arr[r.Next()%arr.Count];
        }
        public static int Pow(int a, int n, int m)
        {
                if (n == 1)
                    return a % m;
                int z;
                z = Pow(a, n / 2, m);
                z = (z * z) % m;
                if (n % 2 == 1)
                    z = (z * a) % m;
                return z;
        }
    }
}
