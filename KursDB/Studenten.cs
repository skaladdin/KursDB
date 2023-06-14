using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursDB
{
    class Studenten
    {
        public int StudentID {get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int KursID { get; set; }
        public Kurs Kurs { get; set; }  
    }
}
