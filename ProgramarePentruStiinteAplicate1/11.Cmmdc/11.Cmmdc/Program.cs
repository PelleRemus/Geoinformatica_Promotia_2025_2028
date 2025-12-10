namespace _11.Cmmdc
{
    internal class Program
    {
        static int Cmmdc(int n1, int n2) // Cel mai mare divizor comun al celor doua numere.
        {                                // Douna numere sunt "prime intre ele" daca cmmdc = 1
            int min = Math.Min(n1, n2);
            for (int d = min; d > 1; d--)
            {
                if (n1 % d == 0 && n2 % d == 0)
                {
                    return d;
                }
            }
            return 1; // Daca avem doar return-uri in if-uri, trebuie si un return de fallback.
        }

        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/496/numarare4
            // Se dă un vector cu n numere naturale.
            // Să se determine câte dintre elementele vectorului sunt prime cu ultimul element.
            int n = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            string[] split = text.Split(' ');
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(split[i]);
            }

            int nr = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (Cmmdc(v[i], v[n - 1]) == 1)
                {
                    nr++;
                }
            }
            Console.WriteLine(nr);
        }
    }
}
