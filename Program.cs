using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeliBeadando_Vorak_Gergo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Síkidom számításait elvégző program");
            int valasztas;
            do
            {
                do
                {
                    Console.WriteLine("Menü");
                    Console.WriteLine("|1 Téglalap|2 Háromszög|3 Kör|4 Paralelogramma|5 Kilépés|");
                    Console.WriteLine("Adja meg mit szeretne!");
                    valasztas = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                } while (valasztas > 5 || valasztas < 1);
                switch (valasztas)
                {
                    case 1: teglalapbeker(); break;
                    case 2: haromszog(); break;
                    case 3: kor(); break;
                    case 4: paralelogramma(); break;
                    case 5: kilepes(); break;
                    default: break;
                }
            } while (valasztas != 5);
        }
        static int teglalapbeker()
        {
            int a;
            int b;
            do
            {
                Console.WriteLine("Adja meg a oldalt:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adja meg b oldalt:");
                b = Convert.ToInt32(Console.ReadLine());
            } while (a < 1 || b < 1);
            teglalapszamitas(a, b);
            return 0;
        }
        static int teglalapszamitas(int a, int b)
        {
            if (a != b)
            {
                int kerulet = (a + b) * 2;
                int terulet = a * b;
                Console.WriteLine("A téglalap kerülete: {0} cm.", kerulet);
                Console.WriteLine("A téglalap területe: " + terulet+ " cm².");
            }
            if (a == b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Az adatok egy négyzet adatai.");
                int kerulet = a * 4;
                int terulet = a * b;
                Console.WriteLine("A négyzet kerülete: {0} cm.", kerulet);
                Console.WriteLine("A négyzet területe: " + terulet + " cm².");
                Console.ResetColor();
            }
            Console.WriteLine("A menübe való visszalépéshez nyomjon le egy billentyűt.");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        static int haromszog()
        {
            int a;
            int b;
            int c;
            do
            {
                Console.WriteLine("Adja meg a oldalt:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adja meg b oldalt:");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adja meg c oldalt:");
                c = Convert.ToInt32(Console.ReadLine());
            } while (a < 1 || b < 1);
            if (a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine("A megadott adatok egy háromszög adatai!");
                int kerulet = a + b + c;
                int s = (a + b + c) / 2;
                int heron = s * (s - a) * (s - b) * (s - c);
                double terulet = Math.Sqrt(heron);
                double koreIrtKor = ((a * b * c) / (4 * terulet));
                double beleIrtKor = ((2 * terulet) / (a + b + c));
                double ma = Math.Sqrt((a + b + c) * (-a + b + c) * (a - b + c) * (a + b - c) / (2 * a));
                double mb = Math.Sqrt((a + b + c) * (-a + b + c) * (a - b + c) * (a + b - c) / (2 * b));
                double mc = Math.Sqrt((a + b + c) * (-a + b + c) * (a - b + c) * (a + b - c) / (2 * c));
                Console.WriteLine("A háromszög kerülete " + kerulet + " cm.");
                Console.WriteLine("A háromszög területe " + terulet + " cm².");
                Console.WriteLine("A háromszög köré írt kör sugara " + koreIrtKor + " cm.");
                Console.WriteLine("A háromszögbe írt kör sugara " + beleIrtKor + " cm.");
                Console.WriteLine("Az a oldalhoz tartózó magasság " + ma + " cm.");
                Console.WriteLine("A b oldalhoz tartózó magasság " + mb + " cm.");
                Console.WriteLine("A c oldalhoz tartózó magasság " + mc + " cm.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A háromszög nem szerkeszthető.");
                int elso = Math.Max(Math.Max(a, b), c);
                int harmadik = Math.Min(Math.Max(a, b), c);
                int masodik;
                if (elso == a && harmadik == c)
                {
                    masodik = b;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
                else if (elso == a && harmadik == b)
                {
                    masodik = c;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
                else if (elso == b && harmadik == a)
                {
                    masodik = c;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
                else if (elso == b && harmadik == c)
                {
                    masodik = a;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
                else if (elso == c && harmadik == b)
                {
                    masodik = a;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
                else if (elso == c && harmadik == a)
                {
                    masodik = b;
                    Console.WriteLine("A megadott értékek: {0}, {1}, {2}", harmadik, masodik, elso);
                }
            }
            Console.ResetColor();
            Console.WriteLine("A menübe való visszalépéshez nyomjon le egy billentyűt.");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        static int kor()
        {
            int valasztas;
            int sugar;
            do
            {
                Random r = new Random();
                sugar = r.Next(1, 11);
                Console.WriteLine("A sugár értéke: {0}", sugar);
                Console.WriteLine("Megfelel ez az érték, vagy kér újat? i/n");
                valasztas = Convert.ToChar(Console.ReadLine());
            }
            while (valasztas != 'i');
            double kerulet = Math.PI * 2 * sugar;
            double terulet = Math.Pow(sugar, 2) * Math.PI;
            int atmero = 2 * sugar;
            Console.WriteLine("A kör kerülete: " + kerulet + " cm.");
            Console.WriteLine("A kör területe: " + terulet + " cm².");
            Console.WriteLine("A kör átmérője: " + atmero + " cm.");
            Console.WriteLine("A menübe való visszalépéshez nyomjon le egy billentyűt.");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        static int paralelogramma()
        {
            int a;
            int b;
            int szog;
            do
            {
                Console.WriteLine("Adja meg a oldalt:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adja meg b oldalt:");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adja meg a paralelogramma egyik szögét.");
                szog = Convert.ToInt32(Console.ReadLine());
            } while (a < 1 || b < 1);
            if (szog != 90)
            {
                int kerulet = 2 * a + 2 * b;
                double terulet = Math.Abs(a * b);
                double magassag = terulet / a;
                Console.WriteLine("A paralelogramma kerülete: " + kerulet + " cm.");
                Console.WriteLine("A paralelogramma területe: " + terulet + " cm².");
                Console.WriteLine("A paralelogramma magassága " + magassag + " cm.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A megadott adatok nem egy paralelogramma adatai.");
                Console.ResetColor();
                teglalapszamitas(a, b);
            }
            Console.WriteLine("A menübe való visszalépéshez nyomjon le egy billentyűt.");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        static int kilepes()
        {
            Console.WriteLine("Viszlát!");
            return 0;
        }
    }
}
