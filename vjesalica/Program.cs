using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjesalica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lijep pozdrav, dobrodošli u poznatu igru Vješala. Vjerovatno ste već upoznati pravilima igre, no ne škodi ponoviti ih.\n" +
                "Pravila igre su vrlo jednostavna potrebno je pogoditi skriveni pojam ili frazu birajući jedno slovo abecede. Pogađajući tako slovo po slovo dolazite do riješenja.\n" +
                "Ukoliko promašite slovo, tj. nema ga u pojmu vaš čovječuljak dobiva jedan dio tijela i tako redom dio po dio dok ne pogodite pojam ili sve promašite i izgubite.\n" +
                "Igrač može igrati igru na tri razine zahtjevnosti: \n" +
                "   A) lagana - nudi 9 promašaja prije nego igra završi,\n" +
                "   B) normalna - nudi 7 promašaja prije nego igra završi i \n" +
                "   C) teška - nudi 5 promašaja prije nego igra završi.\n" +
                "Također na zahtjevnost razine utječe i dužina pojma/fraze, lakša razina će sadržavati najdulje pojmove, a teža najkraće.\n" +
                "Vješalo je prikazana u igri na sljedeći način:\n" +
                "       _______\n" +
                "       |     |\n" +
                "       |     @\n" +
                "       |   --|--\n" +
                "       |     |\n" +
                "       |    / \\\n" +
                "       |                  V J E Š A L A \n \n" +
                "Da li želite odigrati jednu igru?");
            string odluka = SrediUnos(Console.ReadLine());

            while (odluka != "DA" && odluka != "NE")
            {
                odluka = KriviUnos(odluka);
            }

            string uneseno = "";    //ubaciti array kasnije
            int ud = 0;

            if (odluka == "DA")
            {
                while (odluka == "DA")
                {
                    string pojam = ("Samozatajnost").ToUpper();
                    string opis = "vrlina";
                    int i = pojam.Length;
                    String crtice = new String('_', i);
                    crtice = crtice.Replace("_", "_ ");
                    char[] pojamRazmaci = pojam.ToCharArray();      //razbija pojam u niz znakova
                    string neuspjeh = String.Join(" ", pojamRazmaci);       //spaja niz znakova sa speratorom " " u string 

                    while (pojam != crtice.Replace(" ", null))
                    {
                        crtice = Prikaz(opis, crtice, ud);
                        Console.WriteLine("Molimo unesite odabrano slovo:");
                        string slovo = SrediUnos(Console.ReadLine());

                        while (slovo.Length != 1)
                        {
                            slovo = KriviUnos(slovo);
                        }

                        bool provjera = pojam.Contains(slovo);
                        bool provjera2 = uneseno.Contains(slovo);
                        uneseno = uneseno + slovo;
                        //Console.WriteLine("\n {0} \n", uneseno);

                        if (provjera2 == true)
                        {
                            Console.WriteLine("Već ste pokušali unjeti odabrano slovo. Molimo odaberite neko drugo slovo:");
                        }
                        else if (provjera == false)
                        {
                            ud++;
                            //Console.WriteLine(ud);
                            if (ud >= 9)
                            {
                                crtice = neuspjeh;
                                Console.WriteLine("Ovo je bio posljednji pokušaj.");
                            }
                            else
                            {
                                Console.WriteLine("Slovo koje ste unjeli se ne nalazi u skrivenom pojmu. Molimo pokušajte ponovo:");
                            }
                        }
                        else
                        {
                            for (int j = 0; j < i; j++)
                            {
                                string pojmaSlovo = pojam[j].ToString();
                                string[] nizCrtica = crtice.Split(' ');
                                if (slovo == pojmaSlovo)
                                {
                                    nizCrtica[j] = slovo;
                                }
                                else if (nizCrtica[j] != "_")
                                {
                                    // ne radi ništa, ostavi slovo koje je
                                }
                                else
                                {
                                    nizCrtica[j] = "_";
                                }
                                crtice = String.Join(" ", nizCrtica);
                            }
                        }
                    }

                    Prikaz(opis, crtice, ud);
                    string poraz = " :( ŠTETA, niste uspjeli odgonenuti skriveni pojam. Da li želite odigrati još jednu partiju?";
                    string pobjeda = " :) BRAVO! Čestitamo, uspjeli ste pogoditi pojam. Da li želite odigrati još jednu partiju?";
                    string poruka = (ud < 9) ? pobjeda : poraz;
                    Console.WriteLine(poruka);
                    odluka = SrediUnos(Console.ReadLine());

                    while (odluka != "DA" && odluka != "NE")
                    {
                        odluka = KriviUnos(odluka);
                    }
                    
                    if (odluka == "DA")
                    {
                        ud = 0;
                        uneseno = "";
                    }

                }
                //ubaciti upit dali igrač želi igrati još

                Console.WriteLine("Hvala vam na vašem vremenu. Igra je završila, pritisnite \"Enter\" za kraj.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Hvala vam na vašem vremenu. Pritisnite 'Enter' za izlazak iz igre. Lijep pozdrav.");
                Console.ReadLine();
            }
        }
        public static string Prikaz(string opis, string crtice, int k)
        {
            string[] ud = new string[] {"@", "|", "-", "-", "-", "-", "|", "/", "\\"};
            string[] udi = new string[] {" ", " ", " ", " ", " ", " ", " ", " ", " "};

            for (int l = 0; l < k; l++)
            {
                udi[l] = ud[l];
            }

            string kraj = (k >= 9)?"Rješenje je:" : null;
            
            Console.WriteLine(
                   "       _______ \n" +
                   "       |     | \n" +
                   "       |     {0}\n" +
                   "       |   {3}{2}{1}{4}{5}\n" +
                   "       |     {6}        {11}\n" +
                   "       |    {7} {8}\n" +
                   "       |             {9}       (opis: {10})\n", 
                   udi[0], udi[1], udi[2], udi[3], udi[4], udi[5], udi[6], udi[7], udi[8], crtice, opis, kraj);
            return crtice;
        }
        public static string KriviUnos(string ponovi)
        {
            Console.WriteLine("Netočan unos, molimo pokušajte ponovo:");
            string sadrzaj = Console.ReadLine();
            ponovi = sadrzaj.ToUpper().Trim();    //mogao si pozvati metodu SrediUnos
            return ponovi;
        }
        public static string SrediUnos(string sadrzaj)
        {
            sadrzaj = sadrzaj.ToUpper().Trim();
            return sadrzaj;
        }
    }
}
