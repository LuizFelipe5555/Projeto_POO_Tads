using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    public static class NFilme
    {
        public static List<Filme> filmes;
        private static string arquivo = "./filmes.xml";

        public static void Inserir(Filme f)
        {
            filmes = Abrir();

            filmes.Add(f);
            Salvar(filmes);
        }

        public static List<Filme> Listar(){
            filmes = Abrir();

            return filmes.OrderBy(f => f.Nome_filme).ToList();
        }

        public static Filme Listar(int id)
        {
            filmes = Abrir();
            foreach (Filme conteudo in filmes)
            {
                if (conteudo.Id == id) return conteudo;
            }
            return null;
        }

        public static void Atualizar(Filme f)
        {
            Filme atual = Listar(f.Id);

            if (atual != null)
            {
                atual.Avaliacao = f.Avaliacao;
                atual.Nome_filme = f.Nome_filme;
                atual.Genero = f.Genero;
                Salvar(filmes);
            }
        }

        public static void Excluir(Filme f)
        {
            Filme atual = Listar(f.Id);
            if (atual != null)
            {
                filmes.Remove(atual);
                Salvar(filmes);
            }
        }

        public static List<Filme> Abrir()
        {
            try
            {
                return Arquivo<List<Filme>>.Abrir(arquivo);
            } catch
            {
                return new List<Filme>();
            }
        }
        public static void Salvar(List<Filme> obj)
        {
            Arquivo<List<Filme>>.Salvar(arquivo, obj);
        }
    }
}
