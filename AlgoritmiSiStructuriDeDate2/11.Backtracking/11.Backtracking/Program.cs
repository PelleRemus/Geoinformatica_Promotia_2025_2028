namespace _11.Backtracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5, k = 3;
            int[] solutie = new int[k + 1];
            bool[] vizitat = new bool[n];

            //ProdusCartezian(k, 0, solutie);
            //Permutari(k, 0, solutie, vizitat);
            //Aranjamente(n, k, 0, solutie, vizitat);
            Combinari(n, k, 1, solutie);
        }

        static void ProdusCartezian(int n, int p, int[] solutie)
        {
            // conditia de oprire: pasul a ajuns sau a depasit valoarea lui n
            if (p >= n)
            {
                // Solutia este completa, si o putem afisa
                for (int i = 0; i < n; i++)
                    Console.Write(solutie[i] + " ");
                Console.WriteLine();
                return;
            }
            // In caz contrar, continuam sa construim solutia: punem valorile necesare pe pozitia p din solutie
            for (int i = 1; i <= n; i++)
            {
                solutie[p] = i; // punem valoarea i pe pozitia p
                ProdusCartezian(n, p + 1, solutie); // apelam recursiv pentru a construi urmatoarea pozitie
            }
        }

        // Pentru permutari, vrem sa fie unice. Pentru a ne asigura de acest lucru, avem nevoie de un vector de valori vizitate
        static void Permutari(int n, int p, int[] solutie, bool[] vizitat)
        {
            // conditia de oprire: pasul a ajuns sau a depasit valoarea lui n
            if (p >= n)
            {
                // Solutia este completa, si o putem afisa
                for (int i = 0; i < n; i++)
                    Console.Write(solutie[i] + " ");
                Console.WriteLine();
                return;
            }
            // In caz contrar, continuam sa construim solutia: punem valorile necesare pe pozitia p din solutie
            for (int i = 0; i < n; i++)
            {
                if (!vizitat[i])
                {
                    solutie[p] = i + 1; // punem valoarea i pe pozitia p
                    vizitat[i] = true; // marcam valoarea i ca fiind vizitata
                    Permutari(n, p + 1, solutie, vizitat); // apelam recursiv pentru a construi urmatoarea pozitie
                    vizitat[i] = false; // punem inapoi la dispozitie valoarea i
                }
            }
        }

        // Pentru aranjamente, avem nevoie de parametrul k
        static void Aranjamente(int n, int k, int p, int[] solutie, bool[] vizitat)
        {
            // conditia de oprire se schimba: pasul a ajuns sau a depasit valoarea lui k
            if (p >= k)
            {
                for (int i = 0; i < k; i++) // i merge doar pana la k
                    Console.Write(solutie[i] + " ");
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!vizitat[i])
                {
                    solutie[p] = i + 1;
                    vizitat[i] = true;
                    Aranjamente(n, k, p + 1, solutie, vizitat);
                    vizitat[i] = false;
                }
            }
        }

        // Pentru Combinari, solutiile nu au voie sa se repete, chiar si in alta ordine ({1 2 4} si {2 1 4} sunt aceeasi solutie)
        // Cel mai simplu, generam solutii in care toate valorile sunt in ordine crescatoare
        static void Combinari(int n, int k, int p, int[] solutie)
        {
            // conditia de oprire: pasul a depasit valoarea lui k
            if (p > k)
            {
                for (int i = 1; i <= k; i++) // i merge de la 1 pana la k
                    Console.Write(solutie[i] + " ");
                Console.WriteLine();
                return;
            }
            // Pentru ca i sa fie crescator, ne uitam la valoarea precedenta din solutie
            for (int i = solutie[p - 1] + 1; i <= n; i++)
            {
                // nu mai avem nevoie de vizitat, pentru ca nici nu incercam sa folosim aceleasi valori
                solutie[p] = i;
                Combinari(n, k, p + 1, solutie);
            }
        }
    }
}
