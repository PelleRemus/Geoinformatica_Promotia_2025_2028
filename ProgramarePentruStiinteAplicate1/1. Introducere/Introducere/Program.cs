// Pentru afisare, ii spunem consolei sa scrie o linie (WriteLine)
// Si dupa textul afisat, se trece pe linia urmatoare
// Fiecare final de linie trebuie "mentionat" cu simbolul ;
Console.WriteLine("Hello World!");

/* In schimb, daca ii spunem doar sa scrie (Write),
   Nu se trece pe linia urmatoare si textul al doilea va fi lipit de precedentul*/
Console.Write("I am Learning C# ");
Console.Write("It is awesome! ");

// Se pot afisa si numere in mod direct
Console.WriteLine(12);

// Daca incercam sa afisam o ecuatie matematica, se afiseaza direct rezultatul
// Se pot folosi adunare +, scadere -, inmultire *, impartire /, restul impartirii %
// Se pot folosi si paranteze rotunde () pentru a prioritiza o anumita operatie
// Ordinea operatiilor este:
// - operatiile din interiorul parantezelor
// - inmultire sau impartire, de la stanga la dreapta
// - adunare si scadere, de la stanga la dreapta
Console.WriteLine(3 + 3);
Console.WriteLine(3 * (3 + 3) - 9 / 3);

// Variabilele sunt de mai multe feluri:
// - sir de caractere: "Hello World!"
// - un caracter: 'H', ' ', '1', '\n' -> linie noua (enter)
// - numere: int: -12, 3, 0, 4; double: 3.14, 0.27, 0.000001,...; float; decimal; long;
// - bool: true sau false; ocupa doar un bit de spatiu in memorie

// Sintaxa declararii arata in felul urmator: tip numeVariabila = valoare;
string nume = "Remus";
// Si putem folosi variabila fara ghilimele, si se poate afisa valoarea acesteia in schimb
// operatorul + intre doua stringuri le alipeste (concateneaza), adica mai jos => "Hello Remus!"
Console.WriteLine("Hello " + nume + "!");

// Declararea variabilelor este defapt doar sub forma: tip numeVariabila;
// Atunci cand spunem prima data "numeVariabila = valoare", acest lucru se numeste initializare
// Oricand altcandva, se numeste atribuire (pentru ca atribuim o noua valoare variabilei)
int numar;
numar = 15; // initializare
Console.WriteLine(numar);

numar = 3 + 3; // atribuire; rezultatul 6 va fi salvat in variabila numar
Console.WriteLine("3 + 3 = " + numar);

// Se pot declara mai multe variabile pe aceeasi linie, separate prin virgula,
// iar fiecare dintre variabile va avea tipul de data de la inceputul liniei
int x = 5, y = 6, z = 50;
Console.WriteLine(x + y + z);

// Denumirile variabilelor ar trebui sa aiba inteles, pentru a sti la prima vedere ce s-a salvat in ele
// Daca dorim sa dam nume format din mai multe cuvinte la variabila,
// conventia este sa folosim camelCase
int numarulMeuFoarteSmecher = 42;

// Unele tipuri de date se pot converti automat la alte tipuri de date:
int intreg = 3;
double real = intreg;
Console.WriteLine("Numarul 3 sub forma reala este: " + real);

// In schimb pentru altele, trebuie "fortat" prin o operatie numita "casting"
real = 3.14;
intreg = (int)real;
Console.WriteLine("Numarul 3.14 sub forma intreaga este: " + intreg);

// Pentru a converti un string la numar, se foloseste metoda "Parse" a tipului de date respectiv
string numarCaText = "14";
numar = int.Parse(numarCaText);
Console.WriteLine(numar);

// Am vaut metodele de afisare. Pentru "citire" sau inserare de date,
// putem folosi metoda ReadLine a consolei
Console.Write("Care este numele tau? ");
nume = Console.ReadLine();
Console.WriteLine("Hello " + nume + "!");

// Daca vrem sa citim un numar, trebuie sa combinam conversia la int,
// pentru ca o linie din consola este de tip string
numar = int.Parse(Console.ReadLine());
Console.WriteLine(numar);

// Sirurile de caractere au diferite proprietati, cum ar fi lungimea
// Se pot converti la litere mari folosind .ToUpper(), litere mici .ToLower()
nume = "Remus";
Console.WriteLine("Lungimea numelui " + nume + " este: " + nume.Length);

// "Interpolarea" este atunci cand putem folosi variabile direct in interiorul unui string,
// astfel nu mai avem nevoie de concatenare. Pentru a initia interpolarea, trebuie sa punem
// simbolul $ in fata ghilimelei deschise, si pentru a folosi direct variabila,
// aceasta se pune intre acolade
Console.WriteLine($"{numar} + {y} = {numar + y}");

// Se poate folosi si ceva similar, "construire de string", care nu are $ in fata,
// dar are acolade, si in mijlocul lor, un numar. Numarul reprezinta indicele parametrului
// pe care sa il foloseasca in acel spatiu, similar cu interpolarea.
// Parametrii se dau dupa stringul in sine, separati prin virgula
Console.WriteLine("{0} + {1} = {2}", numar, y, numar + y);

// Se poate accesa doar un caracter al stringului, folosind parantee drepte, si indicele caracterului
// Indicele este in felul urmator: R e m u s
//                                 0 1 2 3 4
Console.WriteLine(nume[0]); // R
Console.WriteLine(nume[3]); // u

// Valorile booleene apar in momentul in care facem verificari, cum ar fi
// daca 10 < 15, valoarea este False.
// Operatorii matematici sunt aceiasi, dar uneori arata diferit, cum ar fi:
// <=   mai mic sau egal
// >=   mai mare sau egal
// ==   verificare de egalitate (un singur = atribuie valori variabilelor, adica "numar = 12")
// ||   operatorul SAU, folosit intre doua alte booleene (5<3 || 5<10   -> TRUE)
// &&   operatorul SI   (5>3 && 5<7   -> TRUE)
Console.WriteLine($"{numar} < {y}? {numar < y}");

// Exista secvente de cod conditionate. Adica se intampla doar cand o conditie este TRUE
// Sintaxa este if (conditie), dupa care se deschide o acolada, pentru a sti care linii sunt afectate
// Pentru a nu mai afecta alte linii dupa, de pune o acolada inchisa
// Pentru a merge in situatia inversa, vom folosi else, dupa care acolade la fel.
if (numar < y)
{
    Console.WriteLine($"Numarul {numar} este mai mic decat numarul {y}");
}
else
{
    Console.WriteLine($"Numarul {numar} este mai mare sau egal decat numarul {y}");
}