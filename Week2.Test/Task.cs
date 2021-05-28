using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class Task
    {
        public String Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public LivelloImportanza Livello { get; set; }

        public override String ToString()
        {
            return $"{Descrizione} {DataScadenza.ToShortDateString()} {Livello}";
        }
    }

    public enum LivelloImportanza
    {
        Basso = 1,
        Medio,
        Alto
    }

    
}
