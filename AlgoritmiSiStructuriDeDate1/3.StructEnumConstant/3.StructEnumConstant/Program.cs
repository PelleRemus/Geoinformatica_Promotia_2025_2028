namespace _3.StructEnumConstant
{
    // De regula, structurile si clasele se pot defini la acelasi nivel
    // O structura este un tip de date "definit de utilizator" si poate fi vazuta ca si o colectie de date
    // de tipuri diferite (in acest caz, string si int)
    struct Student
    {
        public string nume;
        public int nota;
    }

    // Enumeratiile se pot defini si ele la acest nivel (direct dupa acodele de la namespace),
    // pentru ca si acestea pot fi folosite ca un nou tip de date dupa ce sunt create.
    // Acest tip de date ar fi echivalentul unei casete cu optiuni multiple (dropdown)
    enum ZileleSaptamanii
    {
        Luni = 1, // Putem forta valoarea sub forma de int a acestei valori a enumeratiei sa fie 1
        Marti,    // Iar restul continua numerotarea 1 cate 1 (adica Marti este 2)
        Miercuri,
        Joi,
        Vineri,
        Sambata,
        Duminica
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Noi am putea defini acele variabile separat. Dar in modul asta nu sunt legate intre ele in mod direct
            string nume1, nume2, nume3;
            int nota1, nota2, nota3;

            // Putem folosi structuri, astfel stim care student are numele si nota respectiva
            // Codul de mai jos este echivalent, pentru ca are potentialul de a salva tot 3 nume si 3 note.
            Student student1, student2, strudent3;

            // Pentru initialiare, trebuie sa dam valorile direct pentru variabilele primitive
            nume1 = "Gigel"; nume2 = "Ionel"; nume3 = "Marcel";
            nota1 = 9; nota2 = 8; nota3 = 10;

            // Iar pentru structuri, cel mai simplu este tot sa dam valorle direct,
            // dar trebuie intai sa accesam variabila potrivita din structura. Putem face asta folosind
            // numele obiectului de tipul structurii de date, apoi punem punct si numele variabilei din structura
            // Urmatorul cod este echivalent:
            student1.nume = "Gigel"; student2.nume = "Ionel"; strudent3.nume = "Marcel";
            student1.nota = 9; student2.nota = 8; strudent3.nota = 10;

            // Putem combina acest aspect cu array-urile: in cazul in care avem mai mult de 3 studenti,
            // vom vrea o lista / colectie de studenti, asa ca putem face un vector de studenti
            // Linia urmatoare este echivalenta cu declararea celor 3 variabile de tip student
            Student[] studenti = new Student[3];

            // Iar urmatoarea linie este modul de accesare a numelui si notelor studentilor
            // (intai folosim indexarea dupa indice, si apoi punctul si variabila din structura):
            studenti[0].nume = "Gigel"; studenti[1].nume = "Ionel"; studenti[2].nume = "Marcel";
            studenti[0].nota = 9; studenti[1].nota = 8; studenti[2].nota = 10;

            // Enumeratia apare si in dreapta si in stanga, cu roluri diferite:
            // In stanga da tipul de data variabliei, iar in dreapta, accesam una din valorile definite in aceasta
            ZileleSaptamanii azi = ZileleSaptamanii.Luni;

            // Pentru a afisa valoarea ca si string (text), putem folosi valoare in WriteLine direct:
            Console.WriteLine("Astazi este " + azi);
            // Dar daca dorim sa spunem a cata zi a saptamanii este, putem converti la int:
            Console.WriteLine("Astazi este ziua cu numarul " + (int)azi + " a saptamanii curente.");

            // ------------------ Constante ------------------
            // Cand declaram un string, putem da o valoare constanta acestuia, cum am facut de exemplu pentru nume
            // Dar daca dorim sa afisam ceva intre ghilimele, observam ca nu putem face asta, pentru ca finalizam stringul
            //string text = "Si mi-a spus "Ce-ai mai facut, tinere?", si a plecat."
            // Linia de mai sus da eroare. Pentru a folosi orice caracter special, trebuie sa punem inaintea lui
            // caracterul backslash (\). Nu functioneaza decat cu caracterele speciale.
            string text = "Si mi-a spus 'Ce-ai mai facut, tinere?', si a plecat.";
            //string special = "\q"; // "q" nu este un caracter special

            // Alte caractere speciale de care o sa va loviti:
            // \n - newline (linie noua)
            // \t - caracterul tab
            // \\ - backslash (afisati la propriu \)
            // \' - single quote (apostrof)
            // \v - tab vertical

            // In unele situatii, avem des caracterul \ in text (de exemplu, la cai de fisiere).
            // In acest caz, este inconvenient sa punem backslash inaintea fiecarui \.
            // In aceasta situatie, putem folosi caracterul @ inaintea stringului, si il transformam
            // intr-un string "literal", adica este la propriu ceea ce am scris, fara caractere speciale.
            string filePath = @"C:\Users\remus\Desktop";

            // Putem declara variabile constante folosind cuvantul cheie const in fata tipului de data.
            // O variabila constanta primeste valoarea la declarare, si nu poate fi reinitializata.
            // Situatiiile in care este util este pentru valori exacte cum ar fi Pi.
            const double Pi = 3.141592;

            // Scrieti un algoritm pentru a determina daca un numar n citit de la tastatura este prim.
            // Un numar prim se poate imparti doar la el insusi si la 1.
            // Exemplu: 16 nu este numar prim, se imparte la 2, 4 si 8
            // 17 este numar prim, se imparte doar la 1 si la 17.
            // 2 este numar prim, se imparte doar la 1 si la 2.
            long n = long.Parse(Console.ReadLine());
            bool isPrime = true;

            // 1 se imparte doar la 1, 0 se imparte la orice numar, iar numerele negative se impart si la -1
            if (n < 2)
                isPrime = false;
            if (n == 2)
                isPrime = true;
            else if (n % 2 == 0)
                isPrime = false;

            // Parcurgem toti posibilii divizori si verificam daca n se imparte exact la acestia
            //for (long d = 2; d <= n / 2; d++) // Solutia banala (cea mai simpla)
            // S-a facut o descoperire ca nu doar n/2 este ultima valoare care ne poate spune daca un numar este prim,
            // ci deja daca depasim radical din n, nu mai este sansa sa gasim vreun divizor.
            //for (long d = 2; d <= Math.Sqrt(n); d++) // Nu este optim
            // Pentru ca operatia de radical este costisitoare,
            // putem in schimb sa verificam daca patratul lui d este mai mic decat n
            //for (long d = 2; d * d <= n; d++)
            // Mai sunt inca putine optimizari... daca verificam daca numarul se imparte la 2
            // inainte de for, putem in for sa sarim peste toti diviorii pari, si atunci am merge din 2 in 2 in for
            for (long d = 3; d * d <= n; d += 2)
            {
                if (n % d == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("Numarul " + n + " este prim.");
            }
            else
            {
                Console.WriteLine("Numarul " + n + " NU este prim.");
            }
        }
    }
}
