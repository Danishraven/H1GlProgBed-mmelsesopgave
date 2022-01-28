using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GlProgBedømmelsesopgave.Codes
{
    internal class Menu
    {
        public string? TypeValg { get; set; }
        public string? Navn;

        public Menu(string? typeValg)
        {
            TypeValg = typeValg;

            switch (TypeValg)
            {
                default:
                    Console.WriteLine("Vælg venligst en af valgmulighederne.");
                    break;

                case "1":
                    Console.WriteLine("Venligst skriv navnet på faget: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        H1.course i = H1.Searcher(Søgeord.Fag, Navn);
                        string teacher = i.value1.ToString();
                        List<Students> students = (List<Students>)i.value2;
                    }
                    break;
                case "2":
                    Console.WriteLine("Venligst skriv navnet på Læreren: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        H1.Searcher(Søgeord.Lærer, Navn);
                    }
                    break;
                case "3":
                    Console.WriteLine("Venligst skriv navnet på Eleven: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        H1.Searcher(Søgeord.Elev, Navn);
                    }
                    break;
            }
            Console.WriteLine();
        }
    }
}
