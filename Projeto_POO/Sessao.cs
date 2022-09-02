using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Ingresso
{
    public class Sessao : IComparable<Sessao>
    {
        public int Id { get; set; }
        public string Sala { get; set; }
        public DateTime Data_Sessao { get; set; }
        public int Hora_sessao { get; set; }
        public int Id_Filme { get; set; }
        public int Id_Cinema { get; set; }

        public int CompareTo(Sessao obj)
        {
            return Id.CompareTo(obj.Id);
        }

        public override string ToString()
        {
            return $"{Id} - {Sala} - {Data_Sessao} - {Hora_sessao}";
        }
    }
}
