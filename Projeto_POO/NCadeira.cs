using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    public static class NCadeira
    {
        public static List<Cadeira> cadeiras;
        private static string arquivo = "./cadeiras.xml";

        public static void Inserir(Cadeira c)
        {
            cadeiras = Abrir();

            cadeiras.Add(c);
            Salvar(cadeiras);
        }

        public static List<Cadeira> Listar()
        {
            cadeiras = Abrir();

            return cadeiras.OrderBy(f => f.Cadeira_tipo).ToList();
        }

        public static Cadeira Listar(int id)
        {
            cadeiras = Abrir();
            foreach (Cadeira conteudo in cadeiras)
            {
                if (conteudo.Id == id) return conteudo;
            }
            return null;
        }

        public static void Atualizar(Cadeira c)
        {
            Cadeira atual = Listar(c.Id);

            if (atual != null)
            {
                atual.Id = c.Id;
                atual.Id_cinema = c.Id_cinema;
                atual.Cadeira_fileira = c.Cadeira_fileira;
                atual.Cadeira_coluna = c.Cadeira_coluna;
                atual.Cadeira_tipo = c.Cadeira_tipo;
                Salvar(cadeiras);
            }
        }

        public static void Excluir(Cadeira c)
        {
            Cadeira atual = Listar(c.Id);
            if (atual != null)
            {
                cadeiras.Remove(atual);
                Salvar(cadeiras);
            }
        }


        public static List<Cadeira> Abrir()
        {
            try
            {
                return Arquivo<List<Cadeira>>.Abrir(arquivo);
            }
            catch
            {
                return new List<Cadeira>();
            }
        }
        public static void Salvar(List<Cadeira> obj)
        {
            Arquivo<List<Cadeira>>.Salvar(arquivo, obj);
        }
    }
}
