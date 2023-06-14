using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursDB
{
    class Kurs
    {
        public int KursID {get; set; }
        public string Name { get; set; }
        public int Raumnummer { get; set; }
        public ICollection<Studenten> Studenten { get; set; }
    }
}
