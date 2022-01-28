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
                    Console.Write("Venligst skriv navnet på faget: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        List<string> teacher = new List<string>();
                        H1.course i = H1.Searcher(Søgeord.Fag, Navn);
                        foreach (object item in (List<object>)i.value1)
                        {
                            teacher.Add(item.ToString());
                        }
                        foreach (string item in teacher)
                        {
                            Console.WriteLine("Lærer: " + item);
                        }
                        foreach(object item in (List<object>)i.value2)
                        {
                            List<Students> students = (List<Students>) item;
                            foreach (Students item2 in students)
                            {
                                string stringStud = item2.Fornavn + " " + item2.Efternavn;
                                Console.WriteLine("Elev: " + stringStud);
                            }
                        }
                    }
                    break;
                case "2":
                    Console.Write("Venligst skriv navnet på Læreren: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        List<string> fag = new List<string>();
                        H1.course i = H1.Searcher(Søgeord.Lærer, Navn);
                        foreach (object item in (List<object>)i.value1)
                        {
                            fag.Add(item.ToString());
                        }
                        foreach (string item in fag)
                        {
                            Console.WriteLine("Fag: " + item);
                        }
                        foreach (object item in (List<object>)i.value2)
                        {
                            List<Students> students = (List<Students>)item;
                            foreach (Students item2 in students)
                            {
                                string stringStud = item2.Fornavn + " " + item2.Efternavn;
                                Console.WriteLine("Elev: " + stringStud);
                            }
                        }
                    }
                    break;
                case "3":
                    Console.Write("Venligst skriv navnet på Eleven: ");
                    Navn = Console.ReadLine();
                    if (Navn != null)
                    {
                        List<string> fag = new List<string>();
                        List<string> teacher = new List<string>();
                        H1.course i = H1.Searcher(Søgeord.Elev, Navn);
                        foreach (object item in (List<object>)i.value1)
                        {
                            fag.Add(item.ToString());
                        }
                        foreach (string item in fag)
                        {
                            Console.WriteLine("Fag: " + item);
                        }
                        foreach (object item in (List<object>)i.value2)
                        {
                            teacher.Add(item.ToString());
                        }
                        foreach (string item in teacher)
                        {
                            Console.WriteLine("Lærer: " + item);
                        }
                    }
                    break;
            }
            Console.WriteLine();
        }
    }
}
