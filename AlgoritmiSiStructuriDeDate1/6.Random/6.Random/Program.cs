namespace _6.Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/490/afisareminmax
            // Se citește un vector cu n elemente, numere naturale distincte.
            // Să se afișeze elementele cuprinse între elementul cu valoarea minimă și cel cu valoare maximă din vector, inclusiv acestea.
            int n = int.Parse(Console.ReadLine()); // Citim n
            string text = Console.ReadLine();      // Citim vectorul ca si text "7 9 6 2 8"
            string[] split = text.Split(' ');      // Impartim unde gasim spatiu ["7", "9", "6", "2", "8"]
            int[] vector = new int[n]; // Declaram vectorul de dimensiune n

            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]); // Transformam vectorul de stringuri in int, string cu string: [7, 9, 6, 2, 8]
            }

            int min = vector[0], max = vector[0];
            int minIndex = 0, maxIndex = 0; // Varianta 2
            for (int i = 1; i < n; i++)
            {
                if (vector[i] < min)
                {
                    min = vector[i];
                    minIndex = i; // Varianta 2
                }
                if (vector[i] > max)
                {
                    max = vector[i];
                    maxIndex = i; // Varianta 2
                }
            }

            // Varianta 1: schimbam de la "modul afisare" la "modul neafisare" si vice versa
            /*bool afisare = false;
            for (int i = 0; i < n; i++)
            {
                if (afisare || vector[i] == min || vector[i] == max)
                {
                    Console.Write(vector[i] + " ");
                }
                if (vector[i] == min || vector[i] == max)
                {
                    afisare = !afisare;
                }
            }*/

            // Varianta 2: cand calculam minimul si maximul, salvam si indicii acestora
            if (minIndex > maxIndex)
            {
                // "Formula" celor 3 pahare: Imagginati-va ca aveti un pahar cu apa, unul cu suc si unul gol.
                // Cum facem sa avem apa in paharul care avea suc si suc in paharul care avea apa? (exact aceeasi metoda o facem cu int-uri)
                int pahar3 = minIndex;
                minIndex = maxIndex;
                maxIndex = pahar3;
            }

            for (int i = minIndex; i <= maxIndex; i++)
            {
                Console.Write(vector[i] + " ");
            }

            // https://www.pbinfo.ro/probleme/487/numarare2
            // Se dă un vector cu n numere naturale.
            // Să se determine câte dintre elemente au valoarea strict mai mare decât media aritmetică a elementelor vectorului.

            // Citirea, la fel ca mai sus
            // Media aritmetica este suma elementelor, impartita la cate elemente sunt
            float mediaAritmetica = 0;
            for (int i = 0; i < n; i++)
            {
                mediaAritmetica += vector[i];
            }
            mediaAritmetica /= n;

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (vector[i] > mediaAritmetica)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

            // https://www.pbinfo.ro/probleme/986/numarare7
            // Se dă un șir cu n elemente, numere reale.
            // Să se determine câte dintre elemente se află în afara intervalului închis determinat de primul și ultimul element.
            // Luam acelasi n in considerare
            text = Console.ReadLine();
            split = text.Split(' ');
            float[] reale = new float[n];

            for (int i = 0; i < n; i++)
            {
                reale[i] = float.Parse(split[i]);
            }

            float primul = reale[0];
            float ultimul = reale[n - 1];
            if (primul > ultimul) // "Formula" celor 3 pahare, pentru a avea intervalul [primul, ultimul]
            {
                float pahar3 = primul;
                primul = ultimul;
                ultimul = pahar3;
            }

            count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!(reale[i] >= primul && reale[i] <= ultimul)) // pentru interval inchis, folosim >= si <=
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
