using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Gerenciamento_Ingresso
{
    public static class NCinema
    {
        public static List<Cinema> cinemas;
        private static string arquivo = "./cinemas.xml";

        public static void Inserir(Cinema c)
        {
            cinemas = Abrir();

            cinemas.Add(c);
            Salvar(cinemas);
        }

        public static List<Cinema> Listar()
        {
            cinemas = Abrir();

            return cinemas.OrderBy(c => c.Nome).ToList();
        }

        public static Cinema Listar(int id)
        {
            cinemas = Abrir();
            foreach (Cinema conteudo in cinemas)
            {
                if (conteudo.Id == id) return conteudo;
            }
            return null;
        }

        public static void Atualizar(Cinema f)
        {
            Cinema atual = Listar(f.Id);

            if (atual != null)
            {
                atual.Nome = f.Nome;   
                atual.Cidade = f.Cidade;
                atual.Estado = f.Estado;
                atual.Endereco = f.Endereco;
                Salvar(cinemas);
            }
        }

        public static void Excluir(Cinema c)
        {
            Cinema atual = Listar(c.Id);
            if (atual != null)
            {
                cinemas.Remove(atual);
                Salvar(cinemas);
            }
        }

        public static List<Cinema> Abrir()
        {
            try
            {
                return Arquivo<List<Cinema>>.Abrir(arquivo);
            }
            catch
            {
                return new List<Cinema>();
            }
        }
        public static void Salvar(List<Cinema> obj)
        {
            Arquivo<List<Cinema>>.Salvar(arquivo, obj);
        }
    }
}
