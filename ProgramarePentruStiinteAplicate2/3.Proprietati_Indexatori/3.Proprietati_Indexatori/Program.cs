namespace _3.Proprietati_Indexatori
{
    public class Animal
    {
        // Am povestit inainte despre incapsulare, dar nu am folosit corect principiile acesteia,
        // deoarece foloseam doar field-uri (campuri). Teoria spune ca field-urile nu ar trebui sa fie publice, ci private.
        // Acum intrebarea este: daca sunt private, cum le putem folosi in eteriorul clasei? Aici vine defapt conceptul de
        // proprietate. Proprietatile pot fi publice (sau internal, sau cu alti modificatori de acces). Motivul pentru care
        // este mai bine asa, este ca field-ul poate permite doar accesul la ambele operatii de vedere si de modificare
        // cu acelasi modificator, dar de obicei, permitem viualizarea mai putin restrictionat. Alte motive ar fi ca putem
        // verifica daca modificam valoarea cu ceva valid, de exemplu.

        // Varianta lunga de a scrie o proprietate: Field-urile sunt separat, si avem 2 metode pentru fiecare
        private string specia;
        public string GetSpecia()
        {
            return specia;
        }
        internal void SetSpecia(string value)
        {
            // putem pune aici verificari daca Value este un string cu o specie cunoscuta, iar daca esueaa, nu facem modificarea
            specia = value;
        }

        // Varianta medie: scurtam metodele intr-o Proprietate cu "get, set", unde get se ocupa de metoda getter,
        // iar set de metoda setter. Inca avem nevoie de field pentru validari, de exemplu.
        private string rasa;
        public string Rasa
        {
            get { return rasa; }
            internal set
            {
                // Aici din nou putem pune niste validari
                rasa = value;
            }
        }

        // Varianta scurta: In situatia in care nu avem nevoie de validari, atunci nu mai avem nevoie sa specificam field-ul din spate,
        // si acesta va exista implicit fara a mai fi mentionat
        public int Varsta { get; internal set; }

        public Animal(string specia, string rasa, int varsta)
        {
            this.specia = specia;
            this.rasa = rasa;
            Varsta = varsta;
        }

        // Pentru ca suntem in interiorul clasei, putem folosi direct field-urile unde exista
        public string Descriere()
        {
            return "Animalul creat are specia " + specia + ", rasa " + rasa + " si varsta " + Varsta + " ani";
        }

        // Dar nu este obligatoriu, putem folosi si getter-ele si setter-ele (ba chiar, este recomandat)
        public override string ToString()
        {
            return "Animalul creat are specia " + GetSpecia() + ", rasa " + Rasa + " si varsta " + Varsta + " ani";
        }
    }

    // Pentru a folosi indexatori, vom defini o noua clasa "Zoo", in care avem o lista cu animalele din acesta
    public class Zoo
    {
        // Consideram ca avem o lista privata de animale, iar obiectele de tip Zoo vor fi folosite majoritar pentru aceasta lista
        // Pentru a le putea accesa mai usor, vom crea un indeator pentru acestea, care este similar la scriere cu o proprietate
        private Animal[] animale = [
            new Animal("caine", "labrador", 3),
            new Animal("pisica", "siameza", 2),
        ];

        // Definirea arata cam asa: modificator de acces, urmat de tipul de return (Animal), iar apoi pentru a defini modul
        // de indexare, folosim cuvantul cheie "this", urmat de paratene drepte, in care declaram tipul de date al indexului
        // (in caul nostru, int), apoi ii dam un nume pentru a putea fi folosit in partea de get si set.
        public Animal this[int index]
        {
            // Pe partea de get sau set, in loc sa spunem "return field" si "field = value", folosim field-ul care este colectie
            // si folosim indexarea sa proprie, "[index]".
            get { return animale[index]; }
            set { animale[index] = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduceti specia animalului: ");
            string specia = Console.ReadLine();
            Console.Write("Introduceti rasa animalului: ");
            string rasa = Console.ReadLine();
            Console.Write("Introduceti varsta animalului: ");
            int varsta = int.Parse(Console.ReadLine());

            Animal animal = new Animal(specia, rasa, varsta);

            // Pentru a folosi valorile, nu putem accesa field-urile, pentru ca sunt private, in schimb folosim getter-ele
            // Proprietatile, chiar daca au functii in spate, nu se apeleaa precum o functie cu paranteze, ci folsim direct numele proprietatii
            // Versiunea lunga: folosim apel de metoda (getter-ul), iar versiunile medii si scurte: folosim direct proprietatea
            Console.WriteLine("Animalul creat are specia " + animal.GetSpecia() + ", rasa " + animal.Rasa + " si varsta " + animal.Varsta + " ani");

            Console.WriteLine(animal.Descriere());
            Console.WriteLine(animal);

            // Pentru utiliare, avem nevoie de un obiect Zoo, si apoi folosim indexarea direct pe acest obiect
            Zoo zoo = new Zoo();
            Console.WriteLine(zoo[0]);
        }
    }
}
