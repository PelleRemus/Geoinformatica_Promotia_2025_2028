namespace _7.Vectori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/4382/inlocuire5
            // Se citește un vector cu n elemente, numere naturale.
            // Să se înlocuiască fiecare element prim din vector cu 0, apoi să se afișeze vectorul.
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];  // int[] -> declarare vector
                                        // new int[n] -> initializare cu dimensiunea n
            string text = Console.ReadLine();
            string[] split = text.Split(' ');

            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]);
                // Verificam daca elementul curent este prim astfel: parcurgem posibilii diviori ai numarului,
                // si daca se imparte la acesta, este intr-adevar divizor si stim ca numarul nu e prim
                bool estePrim = true;
                if (vector[i] < 2)
                    estePrim = false;
                else if (vector[i] == 2) // 2 se imparte exact doar la 1 si la 2 (el insusi) deci este prim
                    estePrim = true;
                else if (vector[i] % 2 == 0) // numerele pare mai mari decat 2 nu sunt prime
                    estePrim = false;
                else
                {
                    for (int d = 3; d * d <= vector[i]; d += 2) // Pentru ca am verificat 2, incepem de la 3. Daca pana la
                    {                                           // radical din numar nu gasim divizori, inseamna ca numarul e prim
                        if (vector[i] % d == 0)
                        {
                            estePrim = false;
                            break; // Iese din for-ul cu d
                        }
                    }
                }

                // Daca numarul este prim, il inlocuim cu 0
                if (estePrim)
                {
                    vector[i] = 0;
                }
            }

            // Afisarea vectorului
            for (int i = 0; i < n; i++)
            {
                Console.Write(vector[i] + " ");
            }
            Console.WriteLine(); // de regula, dupa afisarea vectorului, trecem la linia urmatoare


            // https://www.pbinfo.ro/probleme/4383/inlocuire6
            // Se citește un vector cu n elemente, numere naturale.
            // Să se înlocuiască ultimul element prim din vector cu 0, apoi să se afișeze vectorul.
            n = int.Parse(Console.ReadLine());
            vector = new int[n];

            text = Console.ReadLine();
            split = text.Split(' ');

            // Diferentele fata de celalalt exercitiu sunt doar trei: citim valorile separat de prelucrare...
            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]);
            }

            // ...parcurgem descrescator in for pentru a gasi ultima valoare prima data, si...
            for (int i = n - 1; i >= 0; i--)
            {
                vector[i] = int.Parse(split[i]);
                bool estePrim = true;
                if (vector[i] < 2)
                    estePrim = false;
                else if (vector[i] == 2)
                    estePrim = true;
                else if (vector[i] % 2 == 0)
                    estePrim = false;
                else
                {
                    for (int d = 3; d * d <= vector[i]; d += 2)
                    {
                        if (vector[i] % d == 0)
                        {
                            estePrim = false;
                            break;
                        }
                    }
                }

                if (estePrim)
                {
                    vector[i] = 0;
                    break; // ... iesim din for dupa ce inlocuim prima valoare gasita
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(vector[i] + " ");
            }
            Console.WriteLine();

            // https://www.pbinfo.ro/probleme/633/paritate1
            // Se dă un șir cu n elemente, numere naturale.
            // Determinați diferența în valoare absolută dintre numărul de valori pare din șir și numărul de valori impare din șir.
            n = int.Parse(Console.ReadLine());
            vector = new int[n];

            text = Console.ReadLine();
            split = text.Split(' ');

            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]);
            }

            int nrPare = 0;
            for (int i = 0; i < n; i++)
            {
                if (vector[i] % 2 == 0)
                {
                    nrPare++;
                }
            }
            int nrImpare = n - nrPare;
            int diferenta = Math.Abs(nrPare - nrImpare);
            Console.WriteLine(diferenta);

            // https://www.pbinfo.ro/probleme/546/afisare0
            // Se citește un vector cu n elemente, numere naturale.
            // Să se afișeze elementele din vector care sunt multipli ai ultimului element.
            n = int.Parse(Console.ReadLine());
            vector = new int[n];

            text = Console.ReadLine();
            split = text.Split(' ');

            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (vector[i] % vector[n - 1] == 0)
                {
                    Console.Write(vector[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
