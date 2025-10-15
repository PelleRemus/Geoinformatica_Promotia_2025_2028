// Putem folosi structura conditionala pentru a "ignora" parti din cod. De eemplu, in codul de mai jos,
// se va apela o singura metoda Console.WriteLine, in functie de rezultatul conditiilor
int number = 5;
if (number < 3)
{
    Console.WriteLine("Numarul dat este mai mic decat 3");
}
else
{
    if (number == 3)
    {
        Console.WriteLine("Numarul dat este egal cu 3");
    }
    Console.WriteLine("Numarul dat este mai mare decat 3");
}

// Putem folosi si ramura "else if", si atunci arata mai ordonat putin. Echivalentul codului de mai sus:
if (number < 3)
{
    Console.WriteLine("Numarul dat este mai mic decat 3");
}
else if (number == 3)
{
    Console.WriteLine("Numarul dat este egal cu 3");
}
else
{
    Console.WriteLine("Numarul dat este mai mare decat 3");
}

// "while" este o structura repetitiva "cu numar necunoscut de pasi", adica nu stim de cate ori vrem sa facem o actiune
// De exemplu, daca dorim sa citim numere de la tastatura si facem suma lor,
// pana cand se introduce de la tastatura numarul 0, atunci vom folosi while,
// pentru ca nu stim cand utilizatorul va introduce 0.
number = int.Parse(Console.ReadLine());
int suma = 0;
while (number != 0)
{
    suma = suma + number;
    number = int.Parse(Console.ReadLine());
}
Console.WriteLine("Suma numerelor introduse inaintea lui 0 este: " + suma);

// Observam ca am scris linia de cod pentru citirea de la tastatura de doua ori
// In programare, mereu se incearca sa se evite repetarile
// Pentru a face asta aici, putem folosi bucla alternativa "do..while",
// care intai executa codul, si apoi face verificarea
suma = 0;
do
{
    number = int.Parse(Console.ReadLine());
    suma = suma + number;
} while (number != 0);
Console.WriteLine("Suma numerelor introduse inaintea lui 0 este: " + suma);

// Exista multe exercitii in care dam o valoare initiala unei variabile,
// folosim variabila intr-o conditie in while,
// si modificam variabila inainte de a ajunge inapoi la conditie.
int i = 1;
while (i <= 10)
{
    Console.Write(i + " ");
    i = i + 1;
}
Console.WriteLine();

// Deoarece este o structura atat de uzuala, s-a creat o structura repetitiva diferita
// doar pentru acest caz. Pentru ca stim la ce valoare vrem sa se ajunga (la 10 in caul nostru)
// , structura "for" se numeste "structura reptitiva cu numar cunoscut de pasi".
// Echivalentul codului de mai sus este:
for (i = 1; i <= 10; i = i + 1)
{
    Console.Write(i + " ");
}
Console.WriteLine();

// Operatiile in care adunam sau scadem o valoare dintr-o variabila, si salvam valoarea
// in aceasi variabila, sunt foarte uzuale si s-au prescurtat folosind operatorul "+=" sau "-="
// Exemplu: suma = suma + numar     =>      suma += numar
//          dif = dif - numar       =>      dif -= numar
// O alta operatie foarte uzuala ar fi cresterea sau scaderea valorii unei variabile cu 1.
// Acest lucru se numeste "incrementare" sau "decrementare", si se scrie in felul urmator:
// Exemplu: i = i + 1       =>      i++
//          j = j - 1       =>      j--

// Hai sa consideram urmatorul exercitiu: Afisati numerele de la 1 la 5 si de la 5 la 1
// Pentru acest exercitiu, pentru al doilea rezultat, trebuie sa folosim decrementare
for (i = 1; i <= 5; i++)
{
    Console.Write(i + " ");
}
Console.WriteLine();
for (i = 5; i > 0; i--)
{
    Console.Write(i + " ");
}
Console.WriteLine();

// Daca dorim sa ne oprim in mijlocul executiei unei structuri repetitiva,
// si sa nu asteptam pana se ajunge inapoi la conditie (poate nu vrem sa afisam ceva),
// se pot folosi cuvintele cheie break sau continue. Break iese cu totul din structura,
// pe cand continue doar merge la pasul urmator
// Exemplu: Afisati numerele de la 1 la 10, mai putin 6
for (i = 1; i <= 10; i++)
{
    if (i == 6)
        continue;
    Console.Write(i + " ");
}
Console.WriteLine();

// Afisati numerele introduse de la tastatura, pana cand se introduce valoarea 0 sau 6
do
{
    number = int.Parse(Console.ReadLine());
    if (number == 6)
        break;
    Console.Write(number + " ");
} while (number != 0);
Console.WriteLine();

// Exercitii pbinfo:
// Se citesc două numere naturale a și b.
// Afișați în ordine crescătoare primii b multipli nenuli ai numărului a.
int a = 3, b = 6;
for (i = 1; i <= b; i++)
{
    Console.Write(a * i + " ");
}
Console.WriteLine();

// Se citesc două numere naturale n și m.
// Afișați în ordine descrescătoare primii n multipli nenuli ai numărului m.
int n = 3, m = 6;
for (i = n; i > 0; i--)
{
    Console.Write(m * i + " ");
}
Console.WriteLine();

// Se dă un număr natural n. Afișați în ordine crescătoare primele n numere naturale pare nenule.
n = 100;
for (i = 1; i <= n; i++)
{
    Console.Write(2 * i + " ");
}
