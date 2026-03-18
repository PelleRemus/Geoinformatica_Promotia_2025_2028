namespace _4.DivideAndConquer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pentru ca binary search sa functioneze, vectorul trebuie sa fie sortat
            int[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Citim de la tastatura elementul pe care dorim sa il cautam
            int element = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearchIterativ(vector, element));
            Console.WriteLine(BinarySearchRecursiv(vector, element, 0, vector.Length - 1));
        }

        static bool BinarySearchIterativ(int[] vector, int element)
        {
            // Binary search imparte problema cautarii intr-un vector in probleme mai mici:
            // Verificam elementul din mijlocul vectorului, iar daca acesta este diferit, atunci:
            // 1. Daca elementul cautat este mai mic decat cel din mijloc, cautam in jumatatea stanga a vectorului,
            // 2. Altfel, cautam in jumatatea dreapta a vectorului.

            // Avem nevoie sa stim intervalul in care facem cautarea
            int stanga = 0;
            int dreapta = vector.Length - 1;
            // In momentul in care stanga este mai mare cu dreapta, inseamna ca am epuizat toate posibilitatile de cautare
            while (stanga <= dreapta)
            {
                // mijlocul intervalului
                int mijloc = (stanga + dreapta) / 2;
                // Verificam daca am gasit elementul cautat
                if (vector[mijloc] == element)
                {
                    return true;
                }
                // Cautam in stanga
                if (element < vector[mijloc])
                {
                    // Pentru asta, capatul stang al intervalului ramane la fel, dar capatul drept trebuie sa fie mijloc
                    if (dreapta == mijloc)
                        dreapta = mijloc - 1;
                    else
                        dreapta = mijloc;
                }
                // Cautam in dreapta
                else
                {
                    if (stanga == mijloc)
                        stanga = mijloc + 1;
                    else
                        stanga = mijloc;
                }
            }
            return false;
        }

        static bool BinarySearchRecursiv(int[] vector, int element, int stanga, int dreapta)
        {
            if (stanga > dreapta)
            {
                return false;
            }

            int mijloc = (stanga + dreapta) / 2;
            if (vector[mijloc] == element)
            {
                return true;
            }

            // Cautam in stanga
            if (element < vector[mijloc])
            {
                return BinarySearchRecursiv(vector, element, stanga, mijloc - 1);
            }
            // Cautam in dreapta
            else
            {
                return BinarySearchRecursiv(vector, element, mijloc + 1, dreapta);
            }
        }
    }
}
