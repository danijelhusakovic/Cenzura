using System.Text;

namespace Cenzura
{
    public class Program
    {
        public static Dictionary<string, Kategorija> zabranjeneRijeci =
            new Dictionary<string, Kategorija>();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            zabranjeneRijeci.Add("kvrapcu", Kategorija.Psovka);
            zabranjeneRijeci.Add("puska", Kategorija.Nasilje);
            zabranjeneRijeci.Add("crnac", Kategorija.Rasizam);

            //string recenica = Console.ReadLine();
            string recenica = "ja sam mali mate, KvrApcu";
            string[] rijeci = recenica.Split(" ");

            for(int i = 0; i < rijeci.Length; i++)
            {
                string mala = rijeci[i].ToLower();
                if(zabranjeneRijeci.ContainsKey(mala))
                {
                    rijeci[i] = new string('*', rijeci[i].Length);
                }
            }

            string cenzurirana = string.Join(" ", rijeci);
            Console.WriteLine(cenzurirana);
        }
    }
}

public enum Kategorija
{
    Psovka,
    Nasilje,
    Rasizam
}