namespace _3.Colectii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Sa se verifice daca un numar de 8 cifre este format din aceleasi 4 cifre, de doua ori
            int n = 1234_1234;
            int primaParte = n / 10000; // Impartirea cu multiplii lui 10 vor taia atatea cifre de la final, cate 0-uri sunt
            int aDouaParte = n % 10000; // Restul acestei impartiri sunt chiar cifrele de la final taiate

            if (primaParte == aDouaParte) // Verificam daca cele doua parti sunt identice
                Console.WriteLine("da");
            else
                Console.WriteLine("nu");

            // 2. Se citesc 3 numere separate printr-un spatiu de la tastatura. Afisati cel mai mic numar.
            string line = Console.ReadLine();
            // Pentru ca numerele sunt pe aceeasi linie, Console.Readline va returna "1 2 3", de exemplu.
            // Nu putem face int.Parse direct pe aceasta linie, asa ca intai Ii facem split cu aceasta functie.
            // Din "1 2 3", cand facem split dupa spatiu ' ', se returneaza [ "1", "2", "3" ].
            // Acela este un vector (array), care este o colectie de date de acelasi tip, in caul asta string.
            string[] split = line.Split(' ');

            // Acum ca avem fiecare numar sub forma de string, putem face int.Parse pe fiecare dintre acestea.
            // Pentru a accesa fiecare string din array, cerem indexul elementului intre paranteze drepte astfel:
            // split[0], split[1], split[2]; Indexarea se face de la 0.
            int a = int.Parse(split[0]);
            int b = int.Parse(split[1]);
            int c = int.Parse(split[2]);

            // Vom folosi operatorul "&&" (si) pentru a verifica doua lucruri deodata:
            // Simbolul "&&" functioneaza doar pe doua valori booleene (true sau false),
            // deci vom folosi comparatii intre numere pentru a obtine astfel de valori.
            // Operatorul "&&" va da rezultatul "true" doar cand este folosit de doua valori "true"
            // Exemplu:
            // true && true = true;
            // true && false = false;
            // false && true = false;
            // false && false = false;
            // Alt operator des folosit este "||" (sau), pentru care tabelul de valori
            // este fals doar cand ambele valori care il folosesc sunt false:
            // true || true = true;
            // true || false = true;
            // false || true = true;
            // false || false = false;
            if (a <= b && a <= c)
                Console.WriteLine(a);
            else if (b <= a && b <= c)
                Console.WriteLine(b);
            else // Nici a, nici b nu sunt cele mai mici numere, deci e clar ca c e cel mai mic
                Console.WriteLine(c);

            // 3. Se citesc 3 numere separate printr-un spatiu de la tastatura.
            // Afisati "pare" daca sunt mai multe numere pare, sau "impare" in caz contrar.
            // (Folosim aceeasi citire de la tastatura ca si mai sus)
            int pare = 0;
            // Pentru a verifica daca un numar este par, putem folosi impartirea cu rest la 2:
            // Definitia numarului par este ca este un multiplu de 2, deci restul impartirii e 0.
            if (a % 2 == 0)
                pare++;
            if (b % 2 == 0)
                pare++;
            if (c % 2 == 0)
                pare++;

            // Stim ca sunt 3 numere in total, asa ca numarul de impare este 3 minus numarul de pare
            if (pare > 3 - pare)
                Console.WriteLine("pare");
            else
                Console.WriteLine("impare");

            // Haideti sa schimbam problema la un numar necunoscut de date si folosind Arrays.
            line = Console.ReadLine();
            split = line.Split(' ');
            // Un array are o proprietate "Length" care ne spune cate elemente are in interior (lungimea sa).
            // Ex: [ "1", "2", "3", "4" ] va avea Length 4. 
            int nr = split.Length;
            pare = 0;

            // Pentru fiecare numar, vom face acelasi lucru: transformam cu int.Parse, si verificam daca e par
            // Pentru ca avem de facut acelasi lucru de mai multe ori, folosim o structura repetitiva.
            // Vom merge cu i de la 0, si pana la nr exclusiv (adica strict mai mic), pentru ca in exemplul cu 3 numere
            // , ultimul numar c a fost egal cu int.Parse(split[2]) (indicele 2, nu 3).
            // i va trece prin toti indicii, deci folosim i++
            for (int i = 0; i < nr; i++)
            {
                a = int.Parse(split[i]);
                if (a % 2 == 0)
                    pare++;
            }

            // De data asta, nu mai sunt 3 numere, ci "nr" numere, deci numarul de impare este nr - pare
            if (pare > nr - pare)
                Console.WriteLine("pare");
            else if (pare == nr - pare)
                Console.WriteLine("Acelasi numar de pare si impare");
            else
                Console.WriteLine("impare");
        }
    }
}
