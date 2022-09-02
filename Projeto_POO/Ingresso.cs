using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Ingresso
{
    public class Ingresso : IComparable<Ingresso>
    {
        public int Id { get; set;} 
        public int Preco { get; set; }
        public string Tipo_ingresso { get; set; }
        public int Id_Sessao { get; set; }
        public int Id_Cadeira { get; set; }
        public int Id_Espectador { get; set; }

        public int CompareTo(Ingresso obj)
        {
            return Id.CompareTo(obj.Id);
        }
        public override string ToString()
        {
            return $"Id:{Id} - Preço:{Preco} - Tipo:{Tipo_ingresso}";
        }
    }
}
