namespace _8.Greedy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Valoarea monedelor / bancnotelor in lei
            double[] monede = [200, 100, 50, 20, 10, 5, 1, 0.5, 0.1, 0.05, 0.01];
            double rest = 496.99, copie = rest;
            int nr = 0; // Numarul de monede / bancnote

            // Trecem prin toate monedele disponibile de la cea mai mare la cea mai mica...
            for (int i = 0; i < monede.Length; i++)
            {
                // Cat timp moneda curenta incape in rest, se scade din rest si se aduna la numarul de monede necesare
                while (rest >= monede[i])
                {
                    rest = Math.Round(rest - monede[i], 2);
                    nr++;
                }
            }

            Console.WriteLine($"Pentru a da restul de {copie} lei, aparatul trebuie sa dea inapoi un numar de {nr} bancnote si monede.");

            // Problema activitatilor
            int[] start = [0, 0, 0, 2, 2, 3, 5, 5, 6, 7];
            int[] finish = [2, 1, 2, 4, 3, 4, 9, 7, 8, 10];

            // Sortam activitatile dupa timpul de finalizare
            for (int i = 1; i < finish.Length; i++)
                for (int j = i; j > 0; j--)
                {
                    // Daca pe o pozitie mai mare gasim un element mai mic, facem swap (ex, [2, 1] se interschimba)
                    if (finish[j] < finish[j - 1])
                    {
                        int aux = finish[j];
                        finish[j] = finish[j - 1];
                        finish[j - 1] = aux;

                        // Interschimbam si timpul de start corespunzator
                        aux = start[j];
                        start[j] = start[j - 1];
                        start[j - 1] = aux;
                    }
                }

            List<int> selectate = new List<int>(); // Lista activitatilor selectate
            selectate.Add(finish[0]); // Prima activitate este intotdeauna selectata

            for (int i = 1; i < finish.Length; i++)
            {
                // Daca activitatea curenta incepe mai devreme decat cand se termina ultima activitate adaugata...
                if (start[i] < selectate.Last())
                    continue; // ... atunci nu o putem selecta
                else
                    selectate.Add(finish[i]); // Altfel, o adaugam la lista de activitati selectate
            }

            Console.WriteLine($"Din lista data de activitati, s-au selectat {selectate.Count}.");
        }
    }
}
