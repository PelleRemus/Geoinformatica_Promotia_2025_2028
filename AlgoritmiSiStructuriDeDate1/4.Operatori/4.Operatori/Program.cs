namespace _4.Operatori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------------    OPERATORI    --------------------
            // -------------------- Operatori Aritmetici --------------------
            int a = 10, b = 20;
            Console.WriteLine("a + b = " + (a + b)); // 30
            Console.WriteLine("b - a = " + (b - a)); // 10
            Console.WriteLine("b / a = " + (b / a)); // 2
            Console.WriteLine("a * b = " + (a * b)); // 200
            Console.WriteLine("a % b = " + (a % b)); // 10
            // Operatorul % este "restul impartirii lui a la b"
            // Daca facem operatia "a / b", rezultatul e 10/20 = 0, pentru ca a si b sunt intregi (fara virgula)
            // Pentru a primi rezultatul cu virgula, trebuie sa convertim impartitorul la float (cu virgula)
            // Deci, "(float)a / b" va da 0.5 ca rezultat
            Console.WriteLine("a / b = " + (a / b)); // 0
            Console.WriteLine("(float)a / b = " + ((float)a / b)); // 0.5
            // Operatorul % face prima dintre aceste impartiri, adica "a / b", doar ca nu ia reultatul intreg,
            // Ci restul impartirii (ca si impartirea cu rest din clasele primare)
            // Ex: 3/2 = 1 rest 1, deci 3 % 2 = 1
            // Cele mai utile aplicari ale operatorului % sunt verificarea paritatii si ultima cifra
            // Ex: 13 % 2 = 1 (impar), 14 % 2 = 0 (par)
            // Ex: 123 % 10 = 3 (ultima cifra a lui 123 este 3)

            // Incrementarea si decrementarea pot fi si ele considerate operatori aritmetici, dar si de atribuire
            // a++ inseamna a = a+1 (11), b-- inseamna b = b-1 (19), dar prin afisare, vedem valoarea veche
            Console.WriteLine("a++ = " + a++); // 10 -> il afisam pe a, si facem a++, adica a = a + 1 = 11
            Console.WriteLine("b-- = " + b--); // 20 -> il afisam pe b, si facem b--, deci b = 19
            Console.WriteLine("a = " + a); // 11, valoarea este modificata
            Console.WriteLine("++a = " + (++a)); // 12, valoarea este deja modificata
            Console.WriteLine("--b = " + (--b)); // 18, valoarea este deja modificata

            // -------------------- Operatori Relationali --------------------
            // De obicei se folosesc in if-uri sau for-uri
            Console.WriteLine("a == b = " + (a == b)); // False
            Console.WriteLine("b != a = " + (b != a)); // True
            Console.WriteLine("b < a = " + (b < a)); // False
            Console.WriteLine("a > b = " + (a > b)); // False
            Console.WriteLine("a <= b = " + (a <= b)); // True
            Console.WriteLine("a >= b = " + (a >= b)); // False

            // -------------------- Operatori Logici --------------------
            // Se folosesc intre doua valori de tipul True sau False, booleene, si se pot folosi
            // si intre conditii precum cele de mai sus (adica "a == b || a < b")
            // Operatorii principali sunt operatorul SI (&&) si operatorul SAU (||)
            // Cum functioneaza:
            // TRUE && TRUE = TRUE
            // TRUE && FALSE = FALSE
            // FALSE && TRUE = FALSE
            // FALSE && FALSE = FALSE
            // 
            // TRUE || TRUE = TRUE
            // TRUE || FALSE = TRUE
            // FALSE || TRUE = TRUE
            // FALSE || FALSE = FALSE
            // Se poate si nega o conditie, folosind operatorul de negatie (!)
            // Ex: !(10 == 12) = TRUE
            bool c = true, d = false;
            Console.WriteLine("c && d = " + (c && d)); // False
            Console.WriteLine("c || d = " + (c || d)); // True
            Console.WriteLine("!c = " + (!c)); // False

            // -------------------- Operatori pe Biti --------------------
            // Operatorii pe biti lucreaza direct cu bitii unui numar, adica numarul in baza 2
            // Pentru a transforma un numar in biti (in baza 2), trebuie sa verificam ce componente
            // puteri ale lui 2 se afla in numarul respectiv. Cel mai din treapta bit este 2^0 = 1,
            // si are 1 daca este impar, respectiv 0 daca este par. Urmatoarea cifra in baa 2 este 2^1 = 2,
            // care are 1 daca numarul are in componenta sa 2, respectiv 0 daca nu. Se continua tot asa 
            // pana cand urmatoarea putere alui 2 este mai mare decat numarul original.
            // Ex: 13 in baza 2 este 1101, pentru ca 13 = 8 + 4 + 0 + 1 = 2^3 + 2^2 + 2^1*0 + 2^0
            // Un alt mod de a intelege baza 2 este de a invata sa "numaram" in aceasta baza. In baza 10,
            // numaram astfel: 0, 1, 2, ..., 9, 10, 11, ..., 19, 20, 21, ..., 99, 100, ...
            // In baza 2, in loc sa avem cifrele de la 0 la 9, avem doar 0 si 1, deci trecem la 10 mult mai repede.
            // Dupa aceea avem 11, dupa care, in loc sa trecem la 20 (pentru ca nu avem cifra 2), trecem la 100.
            // Este ca si cum "1" in baza 2, este echivalentul lui "9" in baza 10.
            // Ex: 0, 1, 10, 11, 100, 101, 110, 111, 1000, 1001, 1010, 1011, 1100, 1101, 1110, 1111, 10000, ...
            // Convertirea unui numar din baza 2 in baza 10 este mai simpla: incepem din dreapta spre stanga,
            // tinem minte ce valoare are bitul curent (primul este 1), si adaugam valoarea la rezultat daca bitul nu este 0.
            // Dupa aceea, pentru a afla valoarea urmatorului bit, inmultim valoarea curenta cu 2.
            // Ex: 1011 = 1*1 + 2*1 + 4*0 + 8*1 = 11
            // Adunarea, scaderea, etc, deci operatiile aritmetice, in spate, se fac tot pe biti. Nu trebuie sa
            // intelegem cum functioneaa pe biti pentru ca rezultatul este acelasi
            // Hai sa facem adunare pe biti:
            //  1010 +
            //  1100 =
            // 10110
            //
            //  1111 +
            //     1 =
            // 10000 (=16)
            // Operatorii pe biti fac acelasi lucru, operatii, dar care nu au sens decat in context de 0 sau 1
            // (sau "true" sau "false"). De eemplu avem echivalentul lui && si || pe biti, daca punem o singura data simbolul
            // Ex: 1011 & 1101 este operatia "SI" pe biti a celor doua numere, si face acelasi lucru ca si && pentru fiecare dintre biti
            //  1011 &
            //  1101 =
            //  1001 => (11 & 13 = 9)
            // 
            //  1010 |
            //  1100 =
            //  1110 => (10 | 12 = 14)
            //
            // Mai este si operatorul ^ (XOR, Eclusive OR, adica SAU Exclusiv), care este adevarat daca doar unul dintre biti este 1
            // Deci este fals cand avem 1^1 (True^True).
            //  1010 ^
            //  1100 =
            //  0110 => (10 ^ 12 = 6)
            //
            // Operatorul tilda ~ este operatorul de negatie pe biti, adica inverseaza toti bitii (ca si cum am pune !)
            // ~1010 = 0101 (~10 = 5, Daca lucram pe 4 biti)
            //
            // "Shiftarea" pe biti, la stanga sau la dreapta, inseamna ca mutam bitii ca pe o banda rulanta,
            // in acea directie, de cate ori specificam
            // Ex: 0011 << 1 = 0110 (3 << 1 = 6)
            //     0011 << 2 = 1100 (3 << 2 = 12)
            // Observam ca shiftarea la stanga inseamna inmultirea cu 2 de cate ori am shiftat
            // Ex: 1100 >> 1 = 0110 (12 >> 1 = 6)
            //     1100 >> 2 = 0011 (12 >> 2 = 3)
            // Observam ca shiftarea la dreapta inseamna impartirea cu 2 de cate ori am shiftat

            // -------------------- Operatori de Atribuire --------------------
            // La finalul oricarei operatii de atribuire, valoarea variabilei s-a modificat cu rezultatul
            Console.WriteLine("a = " + (a = 5)); // 5
            Console.WriteLine("a += 2 =" + (a += 2)); // 7 -> a = a + 2 = 5 + 2 = 7, si il afisam pe a
            Console.WriteLine("a -= 4 =" + (a -= 4)); // 3 -> a = a - 4 = 7 - 4 = 3, si il afisam pe a
            Console.WriteLine("a *= 2 =" + (a *= 2)); // 6
            Console.WriteLine("a /= 2 =" + (a /= 2)); // 3
            Console.WriteLine("a %= 2 =" + (a %= 2)); // 1
            Console.WriteLine("a <<= 4 =" + (a <<= 4)); // 16
            Console.WriteLine("a >>= 2 =" + (a >>= 2)); // 4
            Console.WriteLine("a &= 12 =" + (a &= 12)); // 4
            Console.WriteLine("a |= 12 =" + (a |= 12)); // 12
            Console.WriteLine("a ^= 8 =" + (a ^= 8)); // 4

            // -------------------- Operatorul ternar --------------------
            // Este un mod de a prescurta if..else cand singurul lucru pe care-l facem este o atribuire in amandoua
            // Ex, codul de mai jos:
            if (b > 10)
            {
                a = 5;
            }
            else
            {
                a = 20;
            }
            // Este echivalent cu codul urmator:
            a = (b > 10) ? 5 : 20;
            // ? este "if", iar : este "else"
            // Sintaxa este: variabila = (conditie) ? valoare_daca_adevarat : valoare_daca_fals;

            // -------------------- Operatori diversi --------------------
            // sizeof() returneaza numarul de bytes (octeti) ocupati in memorie de variabila
            // Ex: sizeof(int) = 4, sizeof(long) = 8, sizeof(byte) = 1
            Console.WriteLine("sizeof(int) = ", sizeof(int));
            Console.WriteLine("sizeof(int) = ", sizeof(long));
            // typeof() returneaza tipul de date ca string, ex: typeof(int) = "System.Int32"
            // Daca avem struct Student in cod, typeof(Student) = "[namespace].Student"
            //
            // Folosind & cu o singura variabila (&a), primim inapoi adresa de memorie a lui a,
            // Dar la afisare vom afisa valoarea de pe acea adresa (deci valoarea lui a).
            // Cu toate acestea, in proces, convertim a din tip de valoare in tip de referinta (pointer).
            //
            // Folosind * cu o singura variabila (*a), transformam a in pointer.
            //
            // Daca avem struct Student in cod, putem verifica daca o variabila are acest tip de date
            // scriind "variabila is Student". Pe langa asta, putem incerca sa convertim o variabila la Student
            // scriind "variabila as Student"
        }
    }
}
