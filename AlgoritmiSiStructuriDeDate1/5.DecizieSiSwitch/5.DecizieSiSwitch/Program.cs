namespace _5.DecizieSiSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Structura de decizie se foloseste pentru a executa o parte a codului
            // doar daca o anumita conditie este indeplinita. Putem avea si structura de if..else
            // pentru a face ceva si in cazul in care conditia este falsa.
            int number = 10; //int.Parse(Console.ReadLine());
            if (number == 10)
            {
                Console.WriteLine("Numarul citit este 10");
            }
            else
            {
                Console.WriteLine("Numarul citit este diferit de 10");
            }

            // Putem etinde structura de if..else cu structura if..else if..else, in care
            // putem adauga mai multe conditii, fiecare cu un cod diferit de executat,
            // si doar ultima bucata de cod (din interiorul else) va fi executata in caul in care
            // nici una din conditii nu este indeplinita.
            if (number == 9)
            {
                Console.WriteLine("Numarul citit este 9");
            }
            else if (number == 8)
            {
                Console.WriteLine("Numarul citit este 8");
            }
            // ...
            else
            {
                Console.WriteLine("Numarul citit este diferit si de 9 si 8");
            }

            // Alternativ unui if cu conditii de egalitate, putem folosi un switch. Conditia este, intr-un fel,
            // impartita in doua locuri: partea din stanga egalului se afla intre parantezele lui switch,
            // adica switch(number) in loc de if(number == 10), iar partea din dreapta egalului se afla in fiecare caz (case),
            // adica case 10: in loc de == 10. Pentru cazul else, putem folosi "default:", dar poate fi si evitat.
            // Dupa fiecare cod din interiorul unui case, trebuie sa punem "break;".
            switch (number)
            {
                case 10:
                    Console.WriteLine("Numarul citit este 10");
                    break;
                case 9:
                    Console.WriteLine("Numarul citit este 9");
                    break;
                case 8:
                    Console.WriteLine("Numarul citit este 8");
                    break;
                // ...
                // Echivalentul lui else este default: daca nu se intra in niciun caz, mergem pe varianta default
                default:
                    Console.WriteLine("Numarul citit este diferit de 10, 9 sau 8");
                    break;
            }

            // Daca vrem sa executam acelasi cod pentru mai mute valori ale lui Number, putem pune mai multe cazuri
            // unul dupa altul, fara break intre ele. Toate cazurile succesive vor executa acelasi cod.
            switch (number)
            {
                case 7:
                case 6:
                case 5:
                    // ...
                    Console.WriteLine("Numarul citit este intre 5 si 7");
                    break;
                case 4:
                default:
                    Console.WriteLine("Numarul citit este diferit de 7, 6 sau 5");
                    break;
            }

            // Exemplu de exercitiu in care putem folosi structura switch:
            // Se citesc 2 numere intregi de la tastura. Scrieti un Meniu in care sa putem selecta
            // o operatie de efectuat intre cele 2 numere: Adunare, Scadere, Inmultire, Impartire.
            Console.WriteLine("Introduceti doua numere a si b pe un rand separate printr-un spatiu:");
            string text = Console.ReadLine();
            string[] split = text.Split(' ');
            int a = int.Parse(split[0]);
            int b = int.Parse(split[1]);

            int optiune;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Selectati o optiune din meniul de operatii:");
                Console.WriteLine("1. Adunare a+b;");
                Console.WriteLine("2. Scadere a-b;");
                Console.WriteLine("3. Scadere b-a;");
                Console.WriteLine("4. Inmultire a*b;");
                Console.WriteLine("5. Impartire a/b;");
                Console.WriteLine("6. Impartire b/a;");
                Console.WriteLine("0. Iesire aplicatie");

                optiune = int.Parse(Console.ReadLine());
                switch (optiune)
                {
                    case 1: Console.WriteLine("a + b = " + (a + b)); break;
                    case 2: Console.WriteLine("a - b = " + (a - b)); break;
                    case 3: Console.WriteLine("b - a = " + (b - a)); break;
                    case 4: Console.WriteLine("a * b = " + (a * b)); break;
                    case 5:
                        if (b != 0)
                            Console.WriteLine("a / b = " + (a / b));
                        else
                            Console.WriteLine("Can not divide by 0.");
                        break;
                    case 6:
                        if (a != 0)
                            Console.WriteLine("b / a = " + (b / a));
                        else
                            Console.WriteLine("Can not divide by 0.");
                        break;
                }
            } while (optiune != 0);
        }
    }
}
