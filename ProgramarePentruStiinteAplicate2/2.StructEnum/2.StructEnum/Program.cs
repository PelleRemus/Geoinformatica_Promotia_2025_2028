namespace _2.StructEnum
{
    // O enumeratie este folosita de catre cod sub forma unui numar intreg,
    // dar pentru a avea mai mult sens pentru un programator, acestea sunt transformate in valori similare cu un string.
    // Acestea pot fi folosite cu amandoua variantele, adica in acest caz, si ca si "Caine", si ca "1".
    // Putem da valori diferite fata de cele implicite, in eemplul acesta, am spus ca pentru caine, avem valoarea 1,
    // iar restul vor avea valorile consecutive. Se pot si ele suprascrie, adica am putea da la Pisica valoarea 3
    enum Specie
    {
        Caine = 1,
        Pisica = 3,
        Peste,
    }

    // O structura este foarte similara cu o clasa: si aceasta creeaza un nou tip de date ce poate fi folosit de programator,
    // are si aceasta campuri (proprietati), si poate si aceasta sa aiba metode (comportament).
    // Diferenta este locatia unde se salveaza datele: o structura este de tip Valoare (ca si int, string, etc),
    // iar o clasa este de tip Referinta (ca si un vector).
    struct Animal
    {
        // Si intr-o structura avem nevoie de modificatori de acces (public, private)
        public Specie specia;
        public string rasa;
        public int varsta;

        // Putem si aici sa avem constructori
        public Animal(Specie specia, string rasa, int varsta)
        {
            this.specia = specia;
            this.rasa = rasa;
            this.varsta = varsta;
        }

        public string Descriere()
        {
            return "Animalul creat are specia " + specia + ", rasa " + rasa + " si varsta " + varsta + " ani";
        }

        public override string ToString()
        {
            return Descriere();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Cum folosim enumeratiile: Se pot folosi tot ca si un nou tip de date (similar cu o clasa in acest sens)
            // , iar pentru valoare avem doua optiuni: Ori folosim numele enumeratiei, urmat de punct, urmat de valoare,
            Specie specie1 = Specie.Peste;
            // ori folosim convertirea eplicita a unei valori intregi la tipul de date "Specie".
            Specie specie2 = (Specie)3;

            // Vom incerca sa scriem acelasi cod ca si saptamana trecuta, dar folosind struct
            Console.Write("Introduceti specia animalului (prima litera trebuie sa fie majuscula): ");
            string specia = Console.ReadLine();
            Console.Write("Introduceti rasa animalului: ");
            string rasa = Console.ReadLine();
            Console.Write("Introduceti varsta animalului: ");
            int varsta = int.Parse(Console.ReadLine());

            // putem converti si un string la o valoare din Enum:
            Specie Specia = (Specie)Enum.Parse(typeof(Specie), specia);
            Animal animal = new Animal(Specia, rasa, varsta);

            // pentru a folosi campurile (proprietatile) din structura, scriem numele variabilei,
            // urmata de punct, urmata de campul ce dorim sa-l folosim
            Console.WriteLine("Animalul creat are specia " + animal.specia + ", rasa " + animal.rasa + " si varsta " + animal.varsta + " ani");
            Console.WriteLine(animal.Descriere());
            Console.WriteLine(animal);

            // Haideti sa vedem situatiile in care un struct este diferit de o clasa:
            // Daca facem o variabila noua ce ia valoarea lui animal, si o modificam, animal ramane neschimbata.
            // Daca facem acelasi lucru pentru o clasa, chiar si animal se va schimba.
            Animal animal2 = animal;
            animal2.specia = Specie.Caine;
            animal2.rasa = "Bulldog";
            animal2.varsta = 5;

            Console.WriteLine();
            Console.WriteLine(animal); // Animal este neschimbat
            Console.WriteLine(animal2); // Animal2 s-a modificat
        }
    }
}
