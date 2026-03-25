namespace _5.Mostenire
{
    public enum Specie
    {
        Caine,
        Pisica,
        Peste,
    }

    // Animal va fi clasa de baza, iar vom crea clase ce o vor mosteni
    // Cand o clasa este derivata din alta (mostenire), se mostenesc si toate proprietatile si metodele clasei de baza,
    // iar clasa derivata poate adauga proprietati si metode suplimentare sau poate suprascrie cele mostenite
    public class Animal
    {
        // Modificatorul de acces protected permite accesarea proprietatii sau metodei in clasa curenta si clasele derivate
        protected Specie Specia { get; set; }
        public string Rasa { get; set; }
        public int Varsta { get; set; }

        public Animal(Specie specie, string rasa, int varsta)
        {
            Specia = specie;
            Rasa = rasa;
            Varsta = varsta;
        }

        // Un alt aspect al Mostenirii este posibilitatea de a avea mai multe forme pentru aceeasi metoda
        // Acest lucru se numeste polimorfism, si puntru a putea modifica metoda in clasa derivata,
        // trebuie sa adaugam cuvantul cheie "virtual" in clasa de baza...
        public virtual string Descriere()
        {
            return "Animalul creat are specia " + Specia + ", rasa " + Rasa + " si varsta " + Varsta + " ani";
        }

        public override string ToString()
        {
            return Descriere();
        }
    }

    // Caine este o clasa derivata din Animal, ceea ce se scrie ca mai jos
    // Cuvantul cheie sealed nu permite derivarea inca o data din aceasta clasa
    public sealed class Caine : Animal, IBark
    {
        // Adaugam proprietati suplimentare pe langa cele mostenite de la Animal
        public string Nume { get; set; }

        // O clasa derivata trebuie sa apeleze constructorul clasei de baza pentru a initializa proprietatile mostenite,
        // iar acest lucru se face folosind cuvantul cheie base
        public Caine(string rasa, int varsta, string nume)   // Primim doar 2 parametri...
            : base(Specie.Caine, rasa, varsta)  // Pentru ca stim ca specia va fi caine
        {
            Nume = nume;
        }

        // Putem adauga si metode suplimentare
        public string Latra()
        {
            return "Ham ham!";
        }

        // ...iar in clasa derivata, trebuie folosit cuvantul cheie override
        public override string Descriere()
        {
            // Daca s-ar dori, se poate apela si implemnetarea metodei din clasa de baza folosind cuvantul cheie base
            //Console.WriteLine(base.Descriere());
            return "Cainele creat are rasa " + Rasa + ", varsta " + Varsta + " ani si numele '" + Nume + "'";
        }

        // Suprascrierea este similara, dar diferita, de supraincarcarea unei metode;
        // supraincarcarea permite folosirea a mai multor metode cu acelasi nume, dar cu lista de parametri diferiti.
        public string Descriere(bool scriereTehnica)
        {
            if (!scriereTehnica)
                return Descriere();
            return "{ \"Specia\" : " + Specia + ", \"Rasa\" : " + Rasa + ", \"Varsta\" : " + Varsta + ", \"Nume\" : " + Nume + " }";
        }
    }

    // Nu functioneaza pentru ca avem clasa Caine ca o clasa sealed
    //public class Tekel : Caine
    //{
    //    public Tekel(int varsta, string nume)
    //        : base("Tekel", varsta, nume)
    //    { }
    //}

    // interfetele sunt ca o schita a unei clase: definim cum trebuie sa arate o anumita caracteristica a acelei clase.
    // O clasa poate sa implementeze oricate interfete, astfel aproape simuland mostenire multipla
    public interface IBark
    {
        // in interfete, modificatorul implicit de acces este public
        // Metodele nu au implementare, doar semnatura, iar proprietatile nu au corp
        string Latra();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Caine caine = new Caine("tekel", 5, "Pufi");
            // Console.WriteLine(caine.Specia);     // Nu functioneaa pentru ca Specia este protected
            Console.WriteLine(caine.Rasa);          // Inca putem accesa variabilele mostenite...
            Console.WriteLine(caine.Descriere());   // .. la fel si pentru metode

            Console.WriteLine(caine.Nume);
            Console.WriteLine(caine.Latra());

            Console.WriteLine(caine);
            Console.WriteLine(caine.Descriere(true));   // Supraincarcarea metodei Descriere (o folosim cu parametru in acest caz)

            Animal peste = new Animal(Specie.Peste, "somn", 2);
            Console.WriteLine(peste.Descriere());   // Pentru clasa Animal, Descriere() are forma originala, asa observam polimorfismul
        }
    }
}