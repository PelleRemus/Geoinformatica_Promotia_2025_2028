namespace _4.StructuraDecisivaMedie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/4721/veseltri
            // c reprezinta cerinta din enunt pe care trebuie sa o rezolvam
            // (dupa "Sa se determine:", avem cerintele 1 sau 2)
            string text = Console.ReadLine(); // "1 5 3"
            string[] parts = text.Split(' '); // ["1", "5", "3"]
            int c = int.Parse(parts[0]);      // int.Parse("1")
            int n = int.Parse(parts[1]);      // int.Parse("5")
            int k = int.Parse(parts[2]);      // int.Parse("3")

            if (c == 1)
            {
                Console.WriteLine(2 * n - 1);
            }
            else
            {
                if (k > n)
                    Console.WriteLine(0);
                else
                    Console.WriteLine(2 * (n - k) + 1);
            }

            // https://www.pbinfo.ro/probleme/1464/sir7
            text = Console.ReadLine();
            parts = text.Split(' ');
            int p = int.Parse(parts[0]);
            k = int.Parse(parts[1]);

            // k poate fi pana la 1000000000, iar dupa ce facem inmultirea cu 30,
            // nr ar iesi prea mare pentru int, de aceea folosim long
            long nr = p + (long)(k / 2) * 30;
            if (k % 2 == 0)
                n -= 20;

            Console.WriteLine(nr);
        }
    }
}
