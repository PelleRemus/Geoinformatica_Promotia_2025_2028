using System.Xml.Linq;

namespace _12.VectoriOrdonati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/500/verificareordonat
            // Se dă un vector cu n elemente numere naturale.
            // Să se verifice dacă are elementele ordonate crescător.
            int n = int.Parse(Console.ReadLine());  // Citim n, ex: 7
            string text = Console.ReadLine();       // Citim vectorul ca si string: "4 5 7 9 9 10 12"
            string[] split = text.Split(' ');       // Convertim in vector de stringuri dupa spatiu: ["4" "5" "7" "9" "9" "10" "12"]
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(split[i]);
            }

            if (EsteOrdonatCrescator(v, n))
                Console.WriteLine("DA");
            else
                Console.WriteLine("NU");

            // https://www.pbinfo.ro/probleme/506/existaprime
            // Se dă un şir cu n elemente, numere naturale. Să se verifice dacă în şir există elemente prime.
            if (ContinePrime(v, n))
                Console.WriteLine("DA");
            else
                Console.WriteLine("NU");

            // https://www.pbinfo.ro/probleme/1320/ordonat-neordonat
            // Orice şir se încadrează în următoarele categorii: șir constant, șir strict crescător, șir crescător,
            // șir strict descrescător, șir descrescător sau șir neordonat.
            // Se citește un șir cu n elemente naturale. Să se verifice în ce categorie se încadrează.
            if (EsteConstant(v, n))
                Console.WriteLine("sir constant");
            else if (EsteOrdonatStrictCrescator(v, n))
                Console.WriteLine("sir strict crescator");
            else if (EsteOrdonatCrescator(v, n))
                Console.WriteLine("sir crescator");
            else if (EsteOrdonatStrictDescrescator(v, n))
                Console.WriteLine("sir strict descrescator");
            else if (EsteOrdonatDescrescator(v, n))
                Console.WriteLine("sir descrescator");
            else
                Console.WriteLine("sir neordonat");
        }

        static bool EsteOrdonatCrescator(int[] v, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (v[i] > v[i + 1])
                    return false;
            }
            return true;
        }

        static bool EsteOrdonatStrictCrescator(int[] v, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (v[i] >= v[i + 1])
                    return false;
            }
            return true;
        }

        static bool EsteOrdonatDescrescator(int[] v, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (v[i] < v[i + 1])
                    return false;
            }
            return true;
        }

        static bool EsteOrdonatStrictDescrescator(int[] v, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (v[i] <= v[i + 1])
                    return false;
            }
            return true;
        }

        static bool EsteConstant(int[] v, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (v[i] != v[i + 1])
                    return false;
            }
            return true;
        }

        static bool ContinePrime(int[] v, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (EstePrim(v[i]))
                    return true;
            }
            return false;
        }

        static bool EstePrim(int n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            double radical = Math.Sqrt(n);
            for (int d = 3; d <= radical; d += 2) // ori, d*d <= n
            {
                if (n % d == 0)
                    return false;
            }
            return true;
        }
    }
}
