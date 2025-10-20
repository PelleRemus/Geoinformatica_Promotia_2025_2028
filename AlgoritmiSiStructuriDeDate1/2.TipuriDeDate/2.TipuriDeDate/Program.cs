// -------------------- Tipuri de date --------------------
// -------------------- Date de tip valoare --------------------
// 1. Numere intregi:
// - Informatia salvata pe 8 biti (1 byte), adica avem valori de la 0 la 255 (sau -128 la 127)
byte octet = 200;    // 300 da eroare
sbyte sOctet = -100; // -150 da eroare
// "sbyte" vine de la "signed byte", adica poate fi si cu semn (cu minus, valori negative)

// - Informatia salvata pe 2 bytes (octeti) => valori de la 0 la 65_535 (sau -32_678 la 32_677)
short Short = 5_000;    // 33_333 da eroare
ushort uShort = 33_333; // -1 da eroare
// "ushort" vine de la "unsigned short", adica fara semn (fara valori negative)

// - Informatie salvata pe 4 bytes, cu valori de la 0 la 4_294_967_295 sau de la -2_147_483_648 la 2_147_483_647
int integer = 2_000_000_000; // 8_000_000_000 da eroare
uint uInteger = 4_000_000_000; // valorile negative dau eroare

// Informatie salvata pe 8 bytes, cu valori... foarte mari (19-20 cifre)
long longInteger = 1_234_567_890_123_456_789;
ulong unsignedLong = 12_345_678_901_234_567_890;

// Motivul pentru care limita superioara a numerelor nu este un numar exact, este pentru ca
// numerele in spate sunt salvate pe biti, adica valori doar de 0 sau 1. Asta inseamna ca numerele
// sunt scrise in baza 2, nu in baza 10, si dupa conversie ajungem la valorile respective.
// Pentru byte, unde avem 8 biti, vom avea 8 valori de 0 sau 1 consecutive, de ex 1001_1010.
// Valoarea minima este 0000_0000 si cea maxima 1111_1111, si pentru a afla valoarea maxima in baza 10,
// inmultim 2 * 2 * 2... de 8 ori (numarul bitilor). Deci maximul este 2^8 - 1 (pentru n biti, 2^n - 1)

// 2. Numere reale (cu virgula)
// Informatie salvata pe 4 bytes, cu 6-7 zecimale (cifre dupa virgula)
float Float = 1.123F; // trebuie pus un "F" sau "f" la final, pentru ca "1.123" este considerat double

// Informatie salvata pe 8 bytes, cu 14 zecimale
double Double = 1.1234567890_12;

// Informatie salvata pe 16 bytes, cu 28 zecimale
decimal Decimal = 1.1234567890_1234567890_123456M; // punem "M" sau "m" la final, la fel ca pentru float

// 3. Variabile "booleene" (cu valoare doar "adevarat" sau "fals") (ar fi suficient un singur bit pentru memorie)
bool adevarat = true;

// 4. Variabila caracter, ocupa 2 octeti si poate reprezenta pana si emojis
char heart = '♡';

// Caracterele au in spate un cod al caracterului, care poate fi reprezentat ca si numar
Console.WriteLine((int)heart);
Console.WriteLine((int)'9');

// 5. Enumeratii
/* public enum AdmisRespins
{
    Respins = 0,
    Admis = 1
} */
// AdmisRespins calificativ = AdmisRespins.Admis;

// 6. Structuri
// https://www.pbinfo.ro/articole/7652/structuri-de-date-neomogene-in-c
// Pe scurt, cream un nou tip de date (numit "tip de date definit definit de utilizator")
// pe care il putem folosi dupa aia ca si orice alt tip de date, pentru declarare.
/* struct Student
{
    int nota;
    string nume;
} */
// Sintaxa de declarare + initializare
// Student student = new Student()

// Sintaxa de initializare (per fiecare componenta)
// student.nota = 7;
// student.nume = "John Doe";

// Structurile pot ajuta in momentul in care am detectat doua sau mai multe variabile
// care repreinta / descriu acelasi concept / obiect. Iar in situatia in care lucram cu mai multe
// astfel de obiecte de acelasi fel, se micsoareaza numarul de variabile declarate.
// Exemplu: 3 studenti ar fi declarati astfel, cu 6 variabile:
int nota1, nota2, nota3;
string nume1, nume2, nume3;

// Pe cand cu structura "Student", avem doar 3 variabile
// Student student1, student2, student3;

// -------------------- Date de tip referinta --------------------
// 1. Obiect si Dinamic
// Folorind cuvintele cheie "obiect" sau "dinamic", putem schimba in timpul executiei codului
// tipul de date salvat intr-o variabila. De eemplu, daca in prima parte a codului dorim sa lucram
// cu partea de "nota" a studentului, salvam valoare intreaga in variabila student,
// iar pentru urmatoarea parte a codului, trecem la partea de "nume" a studentului
object student = 7; // dynamic student
Console.WriteLine("Nota studentului este: " + student);
student = "John Doe";
Console.WriteLine("Numele studentului este: " + student);

// 2. Siruri de caractere
// "char" este de tip valoare, pe cand sir de caractere este referinta, si este o insiruire de caractere.
string sir = "sir de caractere";
Console.WriteLine(sir);

// Pentru ca este un sir, in spate, este practic un array (vector) si putem accesa un singur caracter in functie de indice
Console.WriteLine("Caracterul de pe pozitia 2 din sir este: " + sir[2]);

// 3. Arrays (alte siruri decat string)
// Un array este o colectie de mai multe variabile de acelasi fel.
// De exemplu, daca avem o clasa de 23 de studenti, decat crearea a 23 de variabile cu numele "nota",
// putem crea o singura variabila cu numele "note" de dimensiune 23
int[] note = new int[23];

// Accesarea si scrierea datelor se face tot folsind paranteze drepte, ca la stringuri, si accesam fiecare
// valoare incepand cu 0, si acest numar reprezinta pozitia (indicele) din sir, de la 0 pana la 22
note[7] = 7;

// Pentru afisare, de regula, se foloseste for. Dar in cazul acesta, avem nota doar pe pozitia 7, si putem s-o folosim direct
Console.WriteLine("Nota celui de-al 8-lea student este: " + note[7]);

// 4. Pointeri
// Putem transforma orice tip de date valoare in tip de date referinta folosind pointer: o * la final
// int* pointer = 10;

// 5. Clase si obiecte
// Similare cu structurile, dar sunt de tip referinta. Vom vorbi despre ele mai tarziu

// -------------------- Diferenta intre valoare si referinta --------------------
// Tipurile valoare sunt salvatre direct in variabila, pe cand referintele sunt salvate in alta locatie,
// si doar fac referinta spre acea valoare. Asta inseamna ca putem avea mai multe referinte la aceeasi valoare,
// si astfel putem modifica valoarea unei variabile folosind alta
int a = 5;
int b = a;
b = 7;
Console.WriteLine("a are valoarea " + a + ", iar b are valoarea " + b);

int[] x = new int[1];
x[0] = 5;
int[] y = x;
y[0] = 7;
Console.WriteLine("x are valoarea " + x[0] + ", iar y are valoarea " + y[0]);

// -------------------- Metoda Split pe stringuri --------------------
// Veti avea multe exercitii in care veti citi mai multe numere de la tastatura.
// In aceasta situatie, nu mai putem zice direct "int.Parse(Console.ReadLine())", pentru ca
// linia nu mai este un singur numar. De asta trebuie sa folosim o metoda de a separa linia in mai multe
// siruri de caractere, toate caracterele fiind cifrele numerelor. trebuie doar sa luam string-ul de baza,
// sa aplicam metoda split, si sa mentionam caracterul care separa numerele (de obicei spatiu)
string numbers = Console.ReadLine();
string[] numbersSplit = numbers.Split(" ");

// Acum ca avem linia impartita, putem sa-i luam dimensiunea cu ".Length" si sa parcurgem cu for toate numerele,
// si sa le facem "int.Parse" acestora
int[] array = new int[numbersSplit.Length];
for (int i = 0; i < numbersSplit.Length; i++)
{
    array[i] = int.Parse(numbersSplit[i]);
}