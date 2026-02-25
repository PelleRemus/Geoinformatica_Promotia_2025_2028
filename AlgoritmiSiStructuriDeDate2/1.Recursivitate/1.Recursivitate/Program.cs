namespace _1.Recursivitate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Putere(2, 8));
            Console.WriteLine(DoiLaPuterea(8));
            Console.WriteLine(Factorial(5));

            // Un alt mod in care facem actiuni repetate fara a folosi recursivitate, este folosind for.
            // Adica putem rescrie functia putere astfel:
            int x = 2, y = 8;
            int rezultat = 1;
            for (int i = 0; i < y; i++)
            {
                rezultat = x * rezultat;
            }
            Console.WriteLine(rezultat);
        }

        // O metoda recursiva este o metoda care se auto-apeleaza. Adica, asa cum din Main() apelam metoda Putere(),
        // observam ca si in interiorul metodei Putere() apelam tot Putere(), dar cu alte argumente.
        static int Putere(int x, int y) // se calculeaza x la puterea y
        {
            // Primul lucru de care avem nevoie intr-o metoda recursiva este o instructiune de iesire,
            // altfel codul ruleaza la infinit si vom primi "StackOverflowEception".
            // In cazul puterilor, stim ca orice numar la puterea 0 este 1,
            // deci putem sa ne folosim de acest lucru pentru a iesi din recursivitate.
            if (y == 0)
                return 1; // x^0=1, oricare ar fi x numar real

            // In restul metodei, trebuie sa descriem ceea ce vrem sa se intample intr-un mod repetitiv.
            // In cazul puterilor, stim ca x^y = x inmultit cu x^(y-1). Vom descrie asta in cod
            return x * Putere(x, y - 1);
        }

        // Alt exemplu de calcul matematic ce se scrie usor recursiv, este factorialul: x!
        // x! = 1 * 2 * 3 * ... * x
        static int Factorial(int x)
        {
            if (x < 0)
                return -1; // asta ar insemna ca nu a fost corecta valoarea lui x.
            if (x == 0 || x == 1) // conventie: 0! = 1.
                return 1;
            return x * Factorial(x - 1);
        }

        // Putem folosi metodele recursive si in alte metode decat Main.
        static int DoiLaPuterea(int y)
        {
            // return Putere(2, y);

            // 2 la o anumita putere se poate calcula si folosind operatorul de shiftare (mutare) la stanga pe biti.
            // Pentru explicatia exacta, consultati unul din cursurile de semestrul trecut unde apare.
            // Pe scurt, 2^n = 1 << n, adica mutam bitul 1 cu n pozitii la stanga, ceea ce inseamna ca
            // se adauga n zerouri dupa 1 (pe biti), adica 2^n.
            // Ex pe biti: din                      0000 0001
            // shiftat la stanga de 4 ori, obtinem  0001 0000, adica 16, adica 2^4.
            return 1 << y;
        }
    }
}
