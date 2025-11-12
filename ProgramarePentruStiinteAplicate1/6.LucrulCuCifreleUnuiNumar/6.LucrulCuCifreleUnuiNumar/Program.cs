namespace _6.LucrulCuCifreleUnuiNumar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pentru a trece prin toate cifrele unui numar, se fac urmatorii pasi:
            // - se ia ultima cifra
            // - stergem ultima cifra (din numarul initial)
            // - se prelucreaza
            // - pana cand numarul nu mai are cifre
            ulong n = 12345;
            while (n > 0)
            {
                int cifra = (int)(n % 10); // convertim eplicit la int pentru ca ulong poate fi mai mare decat int
                // Daca nu il modificam pe n, vom lua mereu cifra 5, si while-ul merge la infinit
                // Deci trebuie sa "stergem" ultima cifra, pentru a putea lua a doua cifra la urmatorul pas.
                // Iar pentru a ne asigura ca pastram restul numarului la fel, trebuie doar sa impartim la 10
                n = n / 10;
                // Prelucrarea cifrei...
            }

            // https://www.pbinfo.ro/probleme/3979/suma37
            // Se dă un număr natural nenul n.
            // Calculați suma cifrelor lui n care sunt mai mari sau egale cu 3 și mai mici sau egale cu 7.
            n = ulong.Parse(Console.ReadLine());
            int suma = 0;
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                n = n / 10; // n /= 10;
                if (cifra >= 3 && cifra <= 7)
                {
                    suma = suma + cifra; // suma += cifra;
                }
            }
            Console.WriteLine(suma);

            // https://www.pbinfo.ro/probleme/3078/prod-k
            // Scrieți un program care citește un număr natural n și o cifră k.
            // Programul va calcula produsul P al cifrelor lui n diferite de cifra k.
            n = ulong.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int P = 1; // produs inseamna unmultire, suma inseamna adunare
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                n = n / 10;
                // Trebuie sa punem conditia "diferit de k", pentru ca aceea este cea care ne "obliga" sa facem o actiune
                // , adica nu ar avea sens sa punem "if (cifra == k)" pentru ca nu facem nimic in acel ca
                if (cifra != k)
                {
                    P = P * cifra;
                }
            }
            Console.WriteLine(P);

            // https://www.pbinfo.ro/probleme/4570/numaruldecifre1
            // Să se scrie un program care să determine numărul de cifre pare și numărul de cifre impare
            // ale unui număr natural citit de la tastatură.
            n = ulong.Parse(Console.ReadLine());
            int nrPare = 0, nrImpare = 0;
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                n = n / 10;
                if (cifra % 2 == 0)
                {
                    nrPare++; // nrPare = nrPare + 1;
                }
                else
                {
                    nrImpare++;
                }
            }
            Console.WriteLine(nrPare + " " + nrImpare);

            // https://www.pbinfo.ro/probleme/68/ciframaxima
            // Să se scrie un program care să determine cea mai mare cifră a unui număr natural citit de la tastatură.
            n = ulong.Parse(Console.ReadLine());
            int max = 0;
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                n = n / 10;
                if (cifra > max)
                {
                    max = cifra;
                }
            }
            Console.WriteLine(max);

            // https://www.pbinfo.ro/probleme/4516/max3cif
            // Dat numărul natural n, să se determine cel mai mare număr de trei cifre conținut în n.
            n = ulong.Parse(Console.ReadLine());
            max = 0;
            while (n > 99)
            {
                int numar = (int)(n % 1000); // Ultimele 3 cifre (un nou grup de 3 cifre)
                n = n / 10;
                if (numar > max)
                    max = numar;
            }
            Console.WriteLine(max);

            // https://www.pbinfo.ro/probleme/3932/stergezerouri
            // Se dă un număr natural nenul n. Să se elimine din n toate zerourile cu care se termină n.
            n = ulong.Parse(Console.ReadLine());
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                if (cifra == 0)
                {
                    n = n / 10;
                }
                else
                {
                    break; // oprim bucla n chiar daca se indeplineste conditia din while (n > 0)
                }
            }
            Console.WriteLine(n);

            // https://www.pbinfo.ro/probleme/3665/cmmcp
            // Se dă un număr natural n. Determinaţi cea mai mare cifră pară a sa.
            // Dacă numărul nu are cifre pare se va afişa numărul 10.
            n = ulong.Parse(Console.ReadLine());
            // Avem nevoie de un mod de a detecta dacca nu s-a gasit nicio cifra para.
            // Pentru ca 0 este si ea cifra para, ne impiedica din a detecta asta cu succes,
            // de aceea vom initializa max cu -1
            max = -1;
            while (n > 0)
            {
                int cifra = (int)(n % 10);
                n = n / 10;
                if (cifra % 2 == 0 && cifra > max)
                {
                    max = cifra;
                }
            }
            if (max == -1)
            {
                Console.WriteLine(10);
            }
            else
            {
                Console.WriteLine(max);
            }
        }
    }
}
