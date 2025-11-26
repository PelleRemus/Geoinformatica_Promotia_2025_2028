namespace _8.Metode
{
    internal class Program
    {
        // Unul din scopurile principale ale metodelor este de a reutiliza codul,
        // adica sa nu rescriem o anumita functionalitate doar pentru ca este folosita putin diferit.
        // De exemplu, ambele exercitii din saptamana 7 folosesc fnctionalitatea de a verifica daca un numar este prim,
        // si daca am scrie o metoda, am putea doar sa folosim metoda din nou pentru al doilea exercitiu.
        // Datorita faptului ca suntem intro metoda, algoritmul in sine se scurteaza putin, pentru ca putem folosi return.
        // Ca si exercitiu, incercati sa comparati implementarea de la exercitiile din saptamana 7 cu aceasta.
        // De regula, metdele se declara la nivel de clasa, nu in interiorul altor metode (deci nu in Main).
        // Pentru a declara o metoda, trebuie sa intelegem ce inseamna "semnatura" acestei metode.
        // Semnatura unei metode este alcatuita din:
        // - tipul de return (void daca nu returneaza nimic) (in cazul curent, "bool")
        //    -> ne spune ce valoare va avea rezultatul executiei metodei, deci pentru ca este bool,
        //       daca am vrea sa stocam rezultatul intr-o variabila in metoda Main, ar trebui sa fie de tip bool
        // - numele metodei, in acest caz "EstePrim"
        // - lista de parametri, intre paranteze rotunde (tip si nume de variabila), in acest caz "(int number)"
        //   -> daca avem mai multi parametri, sunt separati prin virgula, de ex: (int a, int b, int c)
        // Pe langa semnatura metodei, putem gasi si alte cuvinte cheie in fata acesteia, in acest caz "static",
        // dar cel mai des ar trebui sa gasim un "modificator de acces", cum ar fi "public" sau "private".
        // Deocamdata nu conteaza ce inseamna aceste cuvinte cheie, iar daca omiteti modificatorul de acces, implicit metoda este private.
        // dupa randul cu semnatura metodei, se deschide un set de acolade, la fel ca pentru clasa, Main sau for-uri, de exemplu
        private static bool EstePrim(int number)
        {
            // Implementarea de saptamana trecuta a aratat asa:
            /*bool estePrim = true;
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
            }*/
            // Nu mai avem nevoie variabila "estePrim", pentru ca putem da direct "return".
            if (number < 2)
                return false; // "return" da rezultat metodei, si in acelasi timp, iese din metoda, similar cu "break" in for.
            // Nu mai este nevoie sa punem "else if", pentru ca am pus return mai sus si am iesit din metoda in acel caz.
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            for (int d = 3; d * d <= number; d += 2)
            {
                if (number % d == 0)
                {
                    return false; // Pentru ca "return" se comporta ca si un break, nu mai este nevoie sa punem acea linie de cod.
                }
            }
            return true; // in cazul in care nu am gasit niciun divizor, inca nu am dat rezultat metodei.
                         // Stim ca in acest caz, numarul este prim, deci returnam true.
        }

        static void Main(string[] args)
        {
            // https://www.pbinfo.ro/probleme/4382/inlocuire5
            // Se citește un vector cu n elemente, numere naturale.
            // Să se înlocuiască fiecare element prim din vector cu 0, apoi să se afișeze vectorul.
            int n = int.Parse(Console.ReadLine());
            int[] vector = CitireVector(n);

            for (int i = 0; i < n; i++)
            {
                // In metoda Main, folosim metoda EstePrim prin scrierea numelui acesteia, si intre paranteze, dam valori parametrilor.
                // In cazul nostru, parametrul "numar" va primi valoarea "vector[i]". In cazul mai multor parametri, se separa prin virgula.
                // Varianta 1: stocam rezultatul intr-o variabila
                /*bool estePrim = EstePrim(vector[i]);
                if (estePrim)
                {
                    vector[i] = 0;
                    break;
                }*/

                // Varianta 2: folosim direct in if rezultatul metodei
                if (EstePrim(vector[i]))
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
            vector = CitireVector(n);

            // Parcurgem descrescator in for pentru a gasi ultima valoare prima data
            for (int i = n - 1; i >= 0; i--)
            {
                if (EstePrim(vector[i]))
                {
                    vector[i] = 0;
                    break; // Iesim din for dupa ce inlocuim prima valoare gasita
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(vector[i] + " ");
            }
            Console.WriteLine();

            // https://www.pbinfo.ro/probleme/2858/pv
            // Se consideră un șir a1, a2, …, an de numere naturale.
            n = int.Parse(Console.ReadLine());
            vector = CitireVector(n);

            // Metodele "void" sunt doar apelate, nu pot fi folosite in if-uri sau salvate in variabile, precum "EstePrim"
            AfisareDeLaDreapta(vector, n);              // a.
            // In schimb aceasta metoda, daca doar am apela-o direct, ne-ar da rezultatul, dar noi nu am face nimic cu el.
            // In cazul nostru, e nevoie sa afisam reultatul, deci apelam metoda in "Console.WriteLine"
            Console.WriteLine(SumaPare(vector));        // b.
            Console.WriteLine(SumaPozitiiPare(vector)); // c.
            Console.WriteLine(SumaDiv10(vector, n));    // d.
            SumaDiv3PozitiiImpare(vector);              // e.
        }

        // Alte metde decat Main, in C#, pot fi mai jos de aceasta metoda
        // a. Să se afișeze elementele șirului de la dreapta la stânga.
        // Un mic "truc", cand este vorba doar de afisare, nu avem nevoie de tip de return, si asta inseamna ca folosim "void".
        // In acest caz, nu putem pune rezultatul metodei intr-o variabila in Main, pentru ca nu returneaza nimic.
        // Cu toate acestea, putem scrie linia de cod "return;" pe post de "break;"
        static void AfisareDeLaDreapta(int[] a, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        // b. Să se calculeze suma valorilor pare din șir.
        // Pentru ca vrem un reultat (acea suma), avem nevoie de return, si va fi de tip int
        static int SumaPare(int[] a) // putem omite parametrul n...
        {
            int suma = 0;
            for (int i = 0; i < a.Length; i++) // ...pentru ca putem folosi proprietatea Length a vectorului
            {
                if (a[i] % 2 == 0)
                {
                    suma += a[i];
                }
            }
            return suma;
        }

        // c. Să se determine suma valorilor aflate pe poziții pare în șir.
        static int SumaPozitiiPare(int[] a)
        {
            int suma = 0;
            // Pentru ca cerinta spune "pozitii pare IN SIR", iar sirul porneste de la 1, i trebuie defapt sa fie impar
            // Prima pozitie para din sir este "a2", care este pe pozitia i=1 in vector
            for (int i = 1; i < a.Length; i += 2)
            {
                suma += a[i]; // facem suma Valorilor pe pozitii pare, nu suma pozitiilor pare
            }
            return suma;
        }

        // d. Să se determine numărul numerelor din șir care sunt divizibile cu 10.
        static int SumaDiv10(int[] a, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 10 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        // e. Să se determine suma numerelor divizibile cu 3 și aflate pe poziții impare.
        // Chiar daca avem nevoie de suma, pentru ca cerinta nu cere specific sa cream metoda pentru aceasta,
        // inseamna ca nu suntem obbligati sa returnam valoarea, o putem afisa direct in metoda.
        static void SumaDiv3PozitiiImpare(int[] a)
        {
            int suma = 0;
            // Pozitiile impare IN SIR sunt pozitiile pare din vector, deci i incepe de la 0
            for (int i = 0; i < a.Length; i += 2)
            {
                if (a[i] % 3 == 0)
                {
                    suma += a[i];
                }
            }
            Console.WriteLine(suma);
        }

        // Pentru ca citim un vector de 3 ori deja, si pentru ca sunt destule linii de cod pentru asta,
        // haideti sa cream o metoda pentru acest lucru
        static int[] CitireVector(int n)
        {
            int[] vector = new int[n];
            string text = Console.ReadLine();
            string[] split = text.Split(' ');

            for (int i = 0; i < n; i++)
            {
                vector[i] = int.Parse(split[i]);
            }
            return vector;
        }
    }
}
