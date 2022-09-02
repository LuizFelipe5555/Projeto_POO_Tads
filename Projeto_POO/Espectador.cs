using System;
using System.Collections.Generic;


namespace Gerenciamento_Ingresso
{
    public class Espectador : Usuario,IComparable<Espectador>
    {
        public int Id_espectador { get; set; }
        //public string Nome { get; set; }
        //public string Senha { get; set; }
        public int CompareTo(Espectador obj)
        {
            return Id_espectador.CompareTo(obj.Id_espectador);
        }


        



        public override string ToString()
        {
            return $"{Id_espectador} - {base.Nome} - {base.Senha}";
        }
    }
}
