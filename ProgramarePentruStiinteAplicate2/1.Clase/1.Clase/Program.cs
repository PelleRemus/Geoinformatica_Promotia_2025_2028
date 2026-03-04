namespace _1.Clase
{
    // Deja ni s-a introdus faptul ca eista conceptul de clasa pentru ca fiecare program
    // incepe cu "class Program", dar ce este o clasa?
    // Deja cunoastem tipurile de date "primitive": int, string, bool, etc.
    // Atunci cand acestea nu sunt suficiente pentru a descrie tipul de date pe care il dorim,
    // ne putem crea un nou tip de date cu un nume dat de noi, iar acesta este definit folosind cuv cheie "class".
    // "Programarea Orientata pe Obiecte" (POO, sau OOP in eng) foloseste clase, dar si obiecte.
    // Un obiect este "valoarea" unei clase, asa cum un numar intreg este valoarea unui int, de exemplu.
    // Punem "valoare" intre ghilimele, pentru ca este o diferenta intre tipuri de valoare si de referinta.
    // Orice clasa este un tip de date de tip referinta.

    // O clasa este formata din proprietati si metode. Proprietatile ne ajuta sa descriem tipul de date,
    // iar metodele ne ajuta sa descriem comportamentul acestui tip de date. Exista si o metoda unica numita constructor,
    // care se executa automat atunci cand se creaza obiectul.
    class Animal
    {
        // Cu aceste proprietati (field-uri) descriem animalul, prin specie, rasa si varsta
        public string specia;
        public string rasa;
        public int varsta;

        // Pentru a putea da toate cele 3 valori la crearea obiectului, vom scrie metoda constructor cu 3 parametri.
        // Constructorul este similar cu o metoda normala, pentru ca are nume si lista de parametri,
        // dar nu are tip de return (nu are nevoie de el), iar numele sau este acelasi cu numele clasei.
        // O diferenta fata de celelalte metode, este ca (deocamdata) este nevoie sa facem cosntructorul public,
        // pe scurt, facem metoda vizibila in intreg codul
        public Animal(string specia, string rasa, int varsta)
        {
            // Cand avem coincidenta de nume, folosim cuvantul cheie "this", urmat de un punct si de numele proprietatii.
            // "this" se refera la obiectul curent, adica la obiectul care se creaza in acest moment,
            // deci "this.specie" se refera la propeietatea tipului Animal, nu la parametrul metodei Animal()
            this.specia = specia;
            this.rasa = rasa;
            this.varsta = varsta;
        }

        // Cream o metoda pentru generarea unui string ce descrie animalul, si facem metoda publica.
        public string Descriere()
        {
            return "Animalul creat are specia " + specia + ", rasa " + rasa + " si varsta " + varsta + " ani";
        }

        // "Suprascriem" metoda "ToString()", pentru a permite obiectelor sa fie folosite direct in Console.WriteLine(),
        // fara apel de metoda, iar aici specificam cum se converteste obiectul la string.
        public override string ToString()
        {
            return "Animalul creat are specia " + specia + ", rasa " + rasa + " si varsta " + varsta + " ani";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Acum ca am definit tipul de date "Animal", putem crea obiecte de acest tip si sa le folosim in codul nostru.
            // Putem cere cele 3 proprietati care definesc animalul de la tastatura, dupa care sa le adaugam la un obiect
            // de tip Animal, ca mai apoi sa observam cu se pot folosi direct din acel obiect.
            Console.Write("Introduceti specia animalului: ");
            string specia = Console.ReadLine();
            Console.Write("Introduceti rasa animalului: ");
            string rasa = Console.ReadLine();
            Console.Write("Introduceti varsta animalului: ");
            int varsta = int.Parse(Console.ReadLine());

            // avem clasa Animal, si o putem folosi pe post de tip de date, adica in loc de "int x", putem spune:
            Animal animal = new Animal(specia, rasa, varsta);
            // "new" este cuvantul cheie ce ne permite sa creem obiecte noi, iar dupa el urmeaza constructorul clasei.

            // Pentru a ne folosi de proprietatile din interiorul obiectului, scriem numele variabilei, urmat de punct,
            // apoi urmat de numele proprietatii, de exemplu: animal.specia
            // Daca folosim acum proprietatea astfel, codul subliniaza numele proprietatii cu rosu si spune ca nu recunoaste.
            // Motivul este ca nu am dat nicium "modificator de acces" pentru aceasta proprietate in interiorul clasei.
            // Cand acesta nu este specificat, se presupune direct ca ar fi "private", adica nu putem folosi
            // proprietatea decat in interiorul clasei in care este definita. Asa ca le vom face publice deocamdata.
            Console.WriteLine("Animalul creat are specia " + animal.specia + ", rasa " + animal.rasa + " si varsta " + animal.varsta + " ani");

            // Momentele cand alegem ce proprietati sunt private, si ce proprietati sunt publice, stau la baza Incapsularii.
            // Incapsularea este una dintre cele 4 principii care stau la baza OOP, iar majoritar, se ocupa de acesti
            // modificatori de acces. Sunt si unele aspecte mai complexe ale acesteia, pe care nu le vom discuta acum.
            // Mai sunt si alti modificatori pe care ii vom introduce impreuna cu un alt principiu dintre cele 4,
            // dar putem defini pe scurt ce face si internal: internal permite accesarea proprietatilor in proiectul curent,
            // iar atata timp cat lucram cu unul singur, este echivalent cu public.

            // Haideti sa ne imaginam ca proprietatile clasei sunt private, dar vrem sa afisam mesajul de mai sus.
            // Sa ne imaginam si ca nu avem disponibile nici variabilele initiale care au citit aceste valori.
            // Ce optiune am avea pentru a afisa mesajul de mai sus din Console.WriteLine()?
            // O optiune este de a crea o metoda publica ce genereaza aceasta descriere
            Console.WriteLine(animal.Descriere());

            // O alta optiune, este sa "suprascriem" metoda "ToString()" a clasei, si sa afisam direct obiectul,
            // fara apel de metoda. Vom eplica mai in detaliu cum functioneaza mai incolo.
            Console.WriteLine(animal);

            // Haideti sa vedem situatiile in care un struct este diferit de o clasa:
            // Daca facem o variabila noua ce ia valoarea lui animal, si o modificam, animal ramane neschimbata.
            // Daca facem acelasi lucru pentru o clasa, chiar si animal se va schimba.
            Animal animal2 = animal;
            animal2.specia = "Caine";
            animal2.rasa = "Bulldog";
            animal2.varsta = 5;

            Console.WriteLine();
            Console.WriteLine(animal); // Animal s-a schimbat si el,
            Console.WriteLine(animal2); // Nu doar Animal2
        }
    }
}
