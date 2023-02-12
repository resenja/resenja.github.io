using System;

namespace Baza
{
    public class Objekat
    {
        public int id
        { get; set; }
        public string atribut1
        { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}", id, atribut1);
        }
    }
}
