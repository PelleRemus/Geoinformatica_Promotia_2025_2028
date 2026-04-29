namespace _9.Interfete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exista anumite interfete declarate / definite in codul de baa C# din System,
            // si acestea pot fi folosite cand vrem sa fim generali, de exemplu pentru o colectie oarecare,
            // putem folosi IEnumerable ca si tip de data.

            // IEnumerable este o interfata "generica", adica poate fi folosita pentru orice tip de data,
            // dar trebuie sa specificam tipul de data intre paranteze unghiulare dupa numele interfetei.
            // Adica, daca pentru un vector de valori intregi spunem "int[]",
            // iar pentru unul de stringuri am spune "string[]",
            // pentru IEnumerable vom spune "IEnumerable<int>" sau "IEnumerable<string>".
            IEnumerable<int> values = new List<int>() { 1, 2, 3, 4, 5 };

            // Diferenta principala dintre lista si vector, este ca lista are dimensiune variabile.
            // Adica, la vector avem dimensiune fixa, deci cand initializam, trebuie sa dam si dimensiunea.
            List<int> list = (List<int>)values;
            Afisare(list);
            list.Remove(3);
            Afisare(list);
            list.Add(3);
            Afisare(list);

            int[] vector = values.ToArray();
            // Daca am fi folosit IEnumerable<int> ca parametru la declararea functiei Afisare,
            // puteam scriesimplu "vector", fara ".ToList()"
            Afisare(vector.ToList());
        }

        static void Afisare(List<int> values)
        {
            foreach (int value in values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
