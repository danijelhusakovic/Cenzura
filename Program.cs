using System.Text;

namespace Cenzura
{
    public class Program
    {
        public static Dictionary<string, Kategorija> zabranjeneRijeci =
            new Dictionary<string, Kategorija>();
        public static Dictionary<Kategorija, int> statistika = new Dictionary<Kategorija, int>();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            zabranjeneRijeci.Add("kvrapcu", Kategorija.Psovka);
            zabranjeneRijeci.Add("puska", Kategorija.Nasilje);
            zabranjeneRijeci.Add("crnac", Kategorija.Rasizam);

            statistika.Add(Kategorija.Psovka, 0);
            statistika.Add(Kategorija.Nasilje, 0);
            statistika.Add(Kategorija.Rasizam, 0);

            //string recenica = Console.ReadLine();
            string recenica = "ja sam mali mate KvrApcu kvrapcu crnac";
            string[] rijeci = recenica.Split(" ");

            for(int i = 0; i < rijeci.Length; i++)
            {
                string mala = rijeci[i].ToLower();
                if(zabranjeneRijeci.ContainsKey(mala))
                {
                    Kategorija kategorija = zabranjeneRijeci[mala];
                    statistika[kategorija]++;
                    rijeci[i] = new string('*', rijeci[i].Length);
                }
            }

            string cenzurirana = string.Join(" ", rijeci);
            Console.WriteLine(cenzurirana);
            foreach (KeyValuePair<Kategorija, int> kvp in statistika)
            {
                if(kvp.Value >0)
                {
                    Console.WriteLine(kvp.Key.ToString() + ": " +
                        kvp.Value.ToString());
                }
            }
        }
    }
}

public enum Kategorija
{
    Psovka,
    Nasilje,
    Rasizam
}