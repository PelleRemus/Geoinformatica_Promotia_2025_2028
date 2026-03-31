namespace _6.PregatirePartial
{
    // O clasa este un nou tip de date definit de programator, adica
    // in loc de "int a" vom putea spune "BigNumber n"
    // Un obiect este "o instanta a unei clase", adica valoarea unei variabile de tipul unei clase
    // Adica in momentul initializarii, se creeaza un obiect nou folosind cuvantul cheie new: "n = new BigNumber()"
    // "public" este unul dintre modificatorii de acces care permite accesarea acestei clase din orice alt cod.
    // "internal" este un alt modificator de acces care nu permite accesarea codului din alt proiect.
    // "private" este modificatorul de acces care nu permite accesarea codului decat in clasa curenta
    // O clasa poate contine campuri, proprietati, metode, si metoda speciala constructor.
    // De inceput, vom lucra doar cu campuri, dar proprietatile s-ar folosi similar, si ajuta la incapsulare
    public class BigNumber
    {
        // Daca nu punem niciun modificator de acces in fata, atunci campul va fi "private" in mod implicit
        //List<int> digits;
        public List<int> digits;
        public int length;

        // Constructorul se apeleaza automat la crearea unui obiect, adica atunci cand spunem "new BigNumber()"
        // Orice clasa are un constructor implicit fara parametri, dar acesta poate fi definit (si practic suprascris)
        // pentru a realiza initializarea corecta a obiectului. Pe langa asta, putem avea mai multi constructori,
        // pentru diferitele cazuri de initializare pe care le avem
        public BigNumber()
        {
            length = 1;
            digits = [0];
        }
        public BigNumber(int original)
        {
            digits = new List<int>();
            while (original > 0)
            {
                Add(original % 10);
                original /= 10;
            }
            digits.Reverse();
        }

        // Clasele definite de programator au un numar limitat de operatori cu definitii existente,
        // de aceea se pot suprascrie operatorii pentru usurinta in scriere. De exemplu, in loc sa facem metoda Suma(),
        // vom suprascrie operatorul +
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber();

            // Pasul 1. Facem reverse la cele 2 numere, pentru a aduna incepand cu ultimele cifre
            a.Reverse();
            b.Reverse();

            // Pasul 2. Adunam cifrele partii comune
            int minim = Math.Min(a.length, b.length);
            for (int i = 0; i < minim; i++)
            {
                result.Add(a.digits[i] + b.digits[i]);
            }

            // Pasul 3. Adaugam cifrele numarului cel mai lung
            for (int i = minim; i < a.length; i++)
            {
                result.Add(a.digits[i]);
            }
            for (int i = minim; i < b.length; i++)
            {
                result.Add(a.digits[i]);
            }

            // Pasul 4. Ne asiguram ca fiecare digit este defapt digit
            for (int i = 0; i < result.length; i++)
            {
                if (result.digits[i] > 10)
                {
                    result.digits[i] %= 10;
                    if (i == result.length - 1)
                    {
                        result.Add(1);
                    }
                    else
                    {
                        result.digits[i + 1]++;
                    }
                }
            }

            result.Reverse();
            return result;
        }

        // Helper functions
        public void Reverse()
        {
            digits.Reverse();
        }
        public void Add(int digit)
        {
            digits.Add(digit);
            length++;
        }
    }
}
