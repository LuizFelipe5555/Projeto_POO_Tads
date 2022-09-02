using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Ingresso
{
    public class Cinema : IComparable<Cinema>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }

        public int CompareTo(Cinema obj)
        {
            return Nome.CompareTo(obj.Nome);
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Estado} - {Cidade} - {Endereco}";
        }
    }
}
