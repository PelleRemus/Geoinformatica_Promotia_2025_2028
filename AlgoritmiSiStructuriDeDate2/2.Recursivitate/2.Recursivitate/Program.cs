namespace _2.Recursivitate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Fibonacci(100));

            // Solutia optima pentru Fibonacci este sa tinem minte valorile ultimelor 2 valori din sir,
            // ori folosind un vector, ori folosind 2 sau 3 variabile care isi tot schimba valoarea.
            int n = 100;
            long[] fibonacci = new long[n + 1];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            Console.Write("0 1 ");

            for (int i = 2; i <= n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                Console.Write(fibonacci[i] + " ");
            }

            Console.WriteLine("\n");
            Console.WriteLine(Recursiv(7));

            // Hai sa facem "Recursiv" folosind for (pentru comparatie)
            n = 7;
            string rezultat = "1";
            for (int i = 2; i <= n; i++)
            {
                rezultat = rezultat + i + rezultat;
            }
            Console.WriteLine(rezultat);
        }

        // Sirul Fibonacci incepe cu "0, 1" sau "1, 1", si dupa aceea se genereaza succesiv adunand ultimii 2 termeni din sir.
        // Adica avem: 0, 1, apoi 0+1=1, apoi 1+1=2, apoi 1+2=3, apoi 2+3=5, apoi 3+5=8, apoi 5+8=13, etc.
        // 0 1 1 2 3 5 8 13 21 34 55 89 144
        static int Fibonacci(int n)
        {
            // O functie recursiva este formata din conditie de oprire si de pasul repetitiv
            if (n < 0)
                return -1;
            if (n == 0)
                return 0;
            if (n == 1 || n == 2)
                return 1;

            // Daca am incerca sa obtinem valoare pentru un n destul de mare, vom observa de ce aceasta practica nu este bune (eficienta)
            // Ce se intampla defapt in spate, pentru fiecare metoda deschisa (adica pentru n=20 de ex),
            // Se vor mai deschide inca 2 metode, care la randul lor vor mai deschide inca 2 metode.
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // n=1: "1"
        // n=2: "121"
        // n=3: "1213121"
        // n=4: "121312141213121"
        // n=5: "1213121412131215121312141213121"
        // n=6: "121312141213121512131214121312161213121412131215121312141213121"
        // n=7: "1213121412131215121312141213121612131214121312151213121412131217121312141213121512131214121312161213121412131215121312141213121"
        static string Recursiv(int n)
        {
            if (n < 1)
                return "";
            if (n == 1)
                return "1";

            // Varianta gresita (neoptimizata), in stil "Fibonacci", cu doua apeluri recursive
            //return Recursiv(n - 1) + n + Recursiv(n - 1);

            // Putem salva rezultatul apelului recursiv intr-o variabila,
            // si atunci nu mai apelam recursiv de doua, ci refolosim rezultatul calculat
            string precedent = Recursiv(n - 1);
            return precedent + n + precedent;
        }
    }
}
