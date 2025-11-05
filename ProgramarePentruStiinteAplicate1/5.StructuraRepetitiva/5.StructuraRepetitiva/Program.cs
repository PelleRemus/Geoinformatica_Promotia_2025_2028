namespace _5.StructuraRepetitiva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/2987/afisarenumere
            // Se dă un număr natural n cu exact 13 cifre reprezentând un cod numeric personal.
            // Să se afișeze anul, luna și ziua nașterii deținătorului.
            string buletin = "5070521071145";//Console.ReadLine();
            // Metoda Substring poate primi 2 parametri: indexul de inceput (caracterul de la care sa inceapa sa ia valori)
            // si cate valori sa ia in total. Pentru an, incepem de la al 2-lea caracter, si luam 2 caractere in total.
            //string an = buletin.Substring(1, 2);
            //string luna = buletin.Substring(3, 2);
            //string zi = buletin.Substring(5, 2);
            //Console.WriteLine($"{an} {luna} {zi}");
            // Echivalent:
            //Console.WriteLine(an + " " + luna + " " + zi);

            // Solutia folosind long (sau ulong):
            ulong cnp = ulong.Parse(buletin);
            // un cnp arata de exemplu asa: 5_070_521_071_145
            // Pentru an, trebuie sa "stergem" ultimele 10 cifre, pentru a ramane cu 507, si apoi sa luam ultimele 2 cifre.
            // Pentru a realiza acest lucru, impartim la 1 urmat de 10 0-uri, adica 10^10 = 10_000_000_000,
            // dupa care luam ultimele 2 cifre, care sunt defapt restul impartirii cu 100.
            ulong an = (cnp / 10_000_000_000L) % 100;
            // Pentru luna, facem acelasi lucru, dar impartim la 1 urmat de 8 0-uri, si din nou luam ultimele 2 cifre
            ulong luna = (cnp / 100_000_000) % 100;
            ulong zi = (cnp / 1_000_000) % 100;

            string anString = an.ToString(); // "7"
            if (an < 10)
                anString = "0" + anString;   // "0" + "7" = "07"

            string lunaString = luna.ToString(); // "5"
            if (luna < 10)
                lunaString = "0" + lunaString;   // "0" + "5" = "05"

            string ziString = zi.ToString(); // "21"
            if (zi < 10)
                ziString = "0" + ziString;

            Console.WriteLine(anString + " " + lunaString + " " + ziString);

            // https://www.pbinfo.ro/probleme/351/piramida
            int n = 5; //int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            // https://www.pbinfo.ro/probleme/4274/para1
            string text = Console.ReadLine(); // "5 *"
            string[] split = text.Split(' '); // ["5", "*"]
            n = int.Parse(split[0]); // 5
            string c = split[1];     // "*"

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            // Solutie cu i--
            /*for (int i = n; i >= 1; i--)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }*/
            // Solutie cu i++
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < i; j++) // i=1, j=1..0; i=2, j=1..1; ...
                {
                    Console.Write(" ");
                }
                for (int j = i; j <= n; j++) // i=1, j=1..5; i=2, j=2..5
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}
