using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Ingresso
{
    public class Admin : Usuario,IComparable<Admin>
    {
        public int Id_Admin { get; set; }
        //public string Nome { get; set; }
        //public string Senha { get; set; }


        


        public int CompareTo(Admin obj)
        {
            return Id_Admin.CompareTo(obj.Id_Admin);
        }

        public override string ToString()
        {
            return $"{Id_Admin} - {Nome} - {Senha}";
        }
    }
}
