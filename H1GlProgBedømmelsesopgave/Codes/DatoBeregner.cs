using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GlProgBedømmelsesopgave.Codes
{
    public struct DatoBeregner
    {
        public int Dage;
        public DatoBeregner(DateTime nu, DateTime slut)
        {
            Dage = Convert.ToInt32((slut - nu).TotalDays);
        }
    }
}
