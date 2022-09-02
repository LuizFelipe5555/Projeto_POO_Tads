using System;
using System.Collections.Generic;

namespace Gerenciamento_Ingresso
{
    public class Filme : IComparable<Filme>
    {
        public int Id { get; set; }
        public string Nome_filme { get; set; }
        public int Avaliacao { get; set; }
        public string Genero { get; set; }

        public int CompareTo(Filme obj)
        {
            return Nome_filme.CompareTo(obj.Nome_filme);
        }

        public override string ToString()
        {
            return $"{Id} - {Nome_filme} - {Avaliacao} estrelas - {Genero}";
        }
    }
}
