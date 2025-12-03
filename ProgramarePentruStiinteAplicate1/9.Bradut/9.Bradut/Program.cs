namespace _9.Bradut
{
    internal class Program
    {
        // Desenati urmatorul bradut (pentru n=5):
        /*      *
               ***
              *****
             *******       
            *********        
               | |
         */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // 1. Bradutul simplu
            // Parcurgerea tuturor "liniilor" din triunghi
            for (int i = 0; i < n; i++)
            {
                // Afisam numarul corect de spatii pentru a centra stelutele
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }
                // Afisam numarul corect de stelute pentru linia curenta
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // Afisam baza bradutului, incepem cu spatiile pentru centrare
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("| |");
            Console.WriteLine();

            // 2. Bradutul colorat
            // Inainte sa afisam, schimbam culoarea la verde
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // Pentru baza, punem cea mai apropiata culoare de maro
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("| |");
            Console.WriteLine();

            // 3. Bradutul impodobit
            // Intai de toate, afisam o steluta galbena in varf
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("*");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    // luam o sansa pentru a afisa globuri sau betea in loc de frunze
                    // Exista clasa Random pentru valori aleatorii
                    // NextDouble() ne da o valoare intre 0 si 1, diferita de 1
                    Random random = new Random();
                    double sansa = random.NextDouble();
                    // Vrem sa alegem culori la intamplare pentru globuri, dar sa nu fie fundalul consolei sau culoarea frunzelor
                    ConsoleColor color;
                    do
                    {
                        // Asa ca luam culori la intamplare...
                        // Putem converti o valoare enumeratie la valoarea sa int. Alb este ultima culoare din enumeratie,
                        // asa ca il folosim pe post de valoarea maxima pe care o poate selecta random-ul
                        int max = (int)ConsoleColor.White;
                        // luam indexul culorii la intamplare. Folosim max+1 pentru ca valoarea data este exclusa.
                        // Next(max + 1) da valori intregi de la 0 pana la max inclusiv
                        int colorIndex = Random.Shared.Next(max + 1);
                        // Convertim indexul la valoarea culorii din enumeratie
                        // (este la fel ca si cand punem (int)real, pentru a lua partea intreaga a numarului real)
                        color = (ConsoleColor)colorIndex;
                        // ...pana cand aceasta este diferita de negru sau verde inchis
                    } while (color == ConsoleColor.Black || color == ConsoleColor.DarkGreen);
                    Console.ForegroundColor = color;

                    // 20% sansa sa fie glob...
                    if (sansa < 0.2)
                    {
                        Console.Write("o");
                    }
                    // 20% sansa sa fie betea...
                    else if (sansa < 0.4)
                    {
                        Console.Write("#");
                    }
                    // si restul de 60% pentru frunze
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(" ");
            }
            // Putem afisa trunchiul si cu culori solide de background
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("   ");

            // La final, resetam culorile consolei
            Console.ResetColor();
        }
    }
}
