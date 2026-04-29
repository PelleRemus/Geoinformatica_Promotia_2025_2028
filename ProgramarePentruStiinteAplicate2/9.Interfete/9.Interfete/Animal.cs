// cand scriem "using <namespace>;", spunem ca dorim sa avem acces la clasele / enums etc din acel namespace
using _9.Interfete.Entities;

// Clasa animal se afla direct in proiect, fara foldere,
// deci numele namespace-ului este acelasi cu numele proiectului, adica "_9.Interfete"
namespace _9.Interfete
{
    public abstract class Animal
    {
        // Inainte sa scriem "using _9.Interfete.Entities;",
        // aparea eroare, pentru ca nu exista enumeratia Specie in namespace-ul "_9.Interfete".
        protected Specie Specia { get; set; }
        public string Rasa { get; set; }
        public int Varsta { get; set; }

        // Cand nu dorim sa scriem "using _9.Interfete.Entities;", putem sa scriem "Entities.Specie" in loc de "Specie",
        // deci practic folosim numele namespace-ului imbricat "Entities", dupa care punem punct, si apoi
        // putem accesa enumeratia Specie
        public Animal(Entities.Specie specie, string rasa, int varsta)
        {
            Specia = specie;
            Rasa = rasa;
            Varsta = varsta;
        }

        public virtual string Descriere()
        {
            return "Animalul creat are specia " + Specia + ", rasa " + Rasa + " si varsta " + Varsta + " ani";
        }

        public abstract void Mananca();

        public override string ToString()
        {
            return Descriere();
        }
    }
}
