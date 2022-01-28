using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GlProgBedømmelsesopgave.Codes
{
    enum Søgeord
    {
        Fag,
        Lærer,
        Elev
    }
    internal class H1: InterfaceH1
    {
        public record course(object value1, object value2);
        public static object[,] AllData = new object[3, 4];
        public static DateTime Start { get; set; }
        public static DateTime Slut { get; set; }
        static H1()
        {
            List<Students> glElever = new List<Students> 
            { 
                new Students(){ Id = 1, Fornavn = "Jan", Efternavn = "Pedersen", TelefonNummer = "11111111"},
                new Students(){ Id = 2, Fornavn = "Birger", Efternavn = "Bønneløkke", TelefonNummer = "22222222"},
                new Students(){ Id = 3, Fornavn = "Peter", Efternavn = "Pedal", TelefonNummer = "33333333"}
            };
            List<Students> dbElever = new List<Students>
            {
                new Students(){ Id = 1, Fornavn = "Jan", Efternavn = "Pedersen", TelefonNummer = "11111111"},
                new Students(){ Id = 2, Fornavn = "Birger", Efternavn = "Bønneløkke", TelefonNummer = "22222222"},
                new Students(){ Id = 3, Fornavn = "Peter", Efternavn = "Pedal", TelefonNummer = "33333333"}
            };
            List<Students> stElever = new List<Students>
            {
                new Students(){ Id = 2, Fornavn = "Birger", Efternavn = "Bønneløkke", TelefonNummer = "22222222"},
                new Students(){ Id = 3, Fornavn = "Peter", Efternavn = "Pedal", TelefonNummer = "33333333"}
            };
            AllData[0, 0] = "Grundlæggende programmering";
            AllData[0, 1] = "Niels";
            AllData[0, 2] = glElever;
            AllData[0, 3] = new int[] {3,4};
            AllData[1, 0] = "Database programmerin";
            AllData[1, 1] = "Henrik";
            AllData[1, 2] = dbElever;
            AllData[1, 3] = 5;
            AllData[2, 0] = "Studieteknik";
            AllData[2, 1] = "John";
            AllData[2, 2] = stElever;
            AllData[2, 3] = 6;
        }

        public static course Searcher(Søgeord type, string? input)
        {
            List<object> value1 = new List<object>();
            List<object> value2 = new List<object>();
            switch (type)
            {
                case Søgeord.Fag:
                    for (int i = 0; i < AllData.GetLength(0); i++)
                    {
                        if ((string?)AllData[i, 0] == input)
                        {
                            value1.Add (AllData[i, 1]);
                            value2.Add (AllData[i, 2]);                            
                        }
                    }
                    break;
                case Søgeord.Lærer:
                    for (int i = 0; i < AllData.GetLength(0); i++)
                    {
                        if ((string?)AllData[i, 1] == input)
                        {
                            value1.Add (AllData[i, 0]);
                            value2.Add (AllData[i, 2]);
                        }
                    }
                    break;
                case Søgeord.Elev:
                    for (int i = 0;i < AllData.GetLength(0); i++)
                    {
                        foreach (Students item in (List<Students>)AllData[i,2])
                        {
                            string navn = item.Fornavn + " " + item.Efternavn;
                            if (navn == input)
                            {
                                value1.Add (AllData[i, 0]);
                                value2.Add (AllData[i, 1]);
                            }
                        }
                    }
                    break;
            }
            return new course(value1, value2);
        }
        public static int Tid(DateTime nu)
        {
            DateTime Nu = nu;
            DateTime Slut = new DateTime(2022, 2, 14);
            DateTime Start = new DateTime(2022, 1, 17);
            return new DatoBeregner(Nu, Slut).Dage;
        }
    }
}
