using System.Collections.Generic;

namespace NetsisRestOrnekleri.Model
{
    public class Dokuman
    {
        public string Seri { get; set; }
        public bool HesaplamalariYap { get; set; }
        public DokumanBaslik FatUst { get; set; }
        public List<DokumanSatir> Kalems { get; set; }
    }
}
