using System;
using System.Collections.Generic;

namespace Gerenciamento_Ingresso
{
    public class Usuario : IComparable<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public int CompareTo(Usuario obj)
        {
            return Id.CompareTo(obj.Id);
        }

        /*
        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }
        */
        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Senha: {Senha}";
        }

    }
}
