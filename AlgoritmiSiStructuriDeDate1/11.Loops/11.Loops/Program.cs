namespace _11.Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Am mai folosit inainte for si while, de obicei impreuna cu vectori,
            // dar se poate itera pe acestia si cu foreach.
            int[] v = { 1, 2, 3, 4, 5 };
            // Iteratie cu for
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }
            Console.WriteLine();
            // Iteratie cu foreach
            // In loc sa declaram indicele, si sa il "ghidam" de la ce valoare,
            // si pana la ce valoare sa mearga, si procedeul "i++",
            // foreach declara doar "elementul", care va lua toate valorile din colectie.
            // Pentru a sti din ce colectie face parte, scriem si "in [colectie]" la final.
            // In interiorul buclei, nu mai lucram cu "v[i]", ci direct cu elementul declarat.
            foreach (int element in v)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // Am mai folosit "break" inainte, care practic opreste bucla mai repede,
            // si functioneaza la fel si in foreach, dar nu am vorbit inca despre "continue".
            // Atunci cand folosim "continue", se sare peste elementul curent, si bucla merge la pasul urmator.
            // Afisam doar elementele impare din vector. Cand gasim un element par, continue pentru a sari peste
            foreach (int element in v)
            {
                if (element % 2 == 0)
                {
                    continue;
                }
                Console.Write(element + " ");
            }

            // Inafara de vectori, exista mai multe colectii, dar una dintre cele mai importante este Lista.
            // Tipul de date este "List<int>" pentru o lista de numere intregi, in loc de "int[]".
            // Diferenta intre liste si vectori este ca vectorii au lungime fixa data la inceput, la declarare
            // (v = new int[n]), in timp ce listele au o lungime variabila / flexibila: putem tot sa adaugam, fara sa punem o limita.
            // Le putem folosi in situatiile in care nu stim cate elemente vom avea in total. Decat sa dam dimensiunea
            // foarte mare intr-un vector, e mai "econom" din punct de vedere al memoriei sa declaram o lista.
            List<int> lista = new List<int>();
            // Deocamdata, lista e goala, nu are niciun element, are lungime 0. Trebuie sa adaugam elemente.
            foreach (int element in v)
                lista.Add(element);
            // Alternativ adaugarii rand pe rand, putem adauga un "range" (o raza, o colectie) de elemente, folosind AddRange.
            lista.AddRange(v);

            // Iteratia pe lista este foarte similara cu for si foreach ca pentru vectori
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i] + " ");
            }
            Console.WriteLine();

            foreach (int element in lista)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // https://www.pbinfo.ro/probleme/499/numarare5
            // Se dă un vector cu n numere naturale.
            // Să se determine câte dintre perechile de elemente din vector sunt formate din valori cu aceeași sumă a cifrelor.
            int n = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            string[] parts = text.Split(' ');
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(parts[i]);
            }

            // Pentru ca ni se cer perechi de numere, folosim "for in for", foruri imbricate
            // Adica doua for-uri, unul pentru primul element din pereche, si altul pentru al doilea din pereche
            int perechi = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                {
                    if (SumaCifrelor(numbers[i]) == SumaCifrelor(numbers[j]))
                    {
                        perechi++;
                    }
                }

            Console.WriteLine(perechi);

            // https://www.pbinfo.ro/probleme/493/constr
            // Se dă un vector x cu n elemente, numere naturale.
            // Să se construiască un alt vector, y, cu proprietatea că y[i] este egal cu
            // restul împărțirii lui x[i] la suma cifrelor lui x[i].

            // Consideram valida citirea precedenta
            int[] y = new int[n];
            for (int i = 0; i < n; i++)
                y[i] = numbers[i] % SumaCifrelor(numbers[i]);

            // Afisam vectorul y
            for (int i = 0; i < n; i++)
                Console.Write(y[i] + " ");
            Console.WriteLine();
        }

        // "static" nu conteaza deocamdata; "int" reprezinta tipul de return, tipul metodei in sine, ca si cum am declara-o 
        // cu valoarea int, SumaCifrelor este ca si numele de variabila, si "int numar" reprezinta o variabila parametru
        // care trebuie sa existe in paranteze in momentul in care folosim metoda SumaCifrelor. (nu putem folosi direct
        // SumaCifrelor(), ci trebuie sa fie SumaCifrelor( <numar> ) )
        static int SumaCifrelor(int numar)
        {
            int suma = 0;
            // Parcurgem toate cifrele numarului. Nu stim cate sunt, deci folosim while
            while (numar > 0)
            {
                int cifra = numar % 10; // luam ultima cifra a numarului...
                numar = numar / 10;     // ... si o "taiem" din numar, ca urmatoarea iteratie sa ia urmatoarea cifra de la urma
                suma = suma + cifra;    // adaugam cifra la suma
            }
            return suma; // "dam valoare" lui "SumaCifre(numar)", adica putem considera ca atunci cand folosim
                         // SumaCifre(numar), valoarea acesteia va fi "suma" de aici
        }
    }
}
