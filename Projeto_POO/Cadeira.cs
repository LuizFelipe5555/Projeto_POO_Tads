using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Ingresso
{
    public class Cadeira : IComparable<Cadeira>
    {
        public int Id { get; set; }
        public string Cadeira_fileira { get; set; }
        public string Cadeira_coluna { get; set; }
        public string Cadeira_tipo { get; set; }
        public int Id_cinema { get; set; }

        public int CompareTo(Cadeira obj)
        {
            return Cadeira_tipo.CompareTo(obj.Cadeira_tipo);
        }

        public override string ToString()
        {
            return $"{Id} - {Cadeira_tipo} - {Cadeira_fileira} - {Cadeira_coluna}";
        }
    }
}
