using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    public static class NSessao
    {
        private static List<Sessao> sessoes;
        private static string arquivo = "./sessoes.xml";

        public static void Inserir(Sessao s)
        {
            sessoes = Abrir();

            sessoes.Add(s);
            Salvar(sessoes);
        }

        public static List<Sessao> Listar()
        {
            sessoes = Abrir();

            return sessoes.OrderBy(f => f.Id).ToList();
        }

        public static Sessao Listar(int id)
        {
            sessoes = Abrir();
            foreach (Sessao conteudo in sessoes)
            {
                if (conteudo.Id == id) return conteudo;
            }
            return null;
        }

        public static void Atualizar(Sessao s)
        {
            Sessao atual = Listar(s.Id);

            if (atual != null)
            {
                atual.Sala = s.Sala;
                atual.Data_Sessao = s.Data_Sessao;
                atual.Hora_sessao = s.Hora_sessao;
                Salvar(sessoes);
            }
        }

        public static void Excluir(Sessao s)
        {
            Sessao atual = Listar(s.Id);
            if (atual != null)
            {
                sessoes.Remove(atual);
                Salvar(sessoes);
            }
        }



        public static List<Sessao> Abrir()
        {
            try
            {
                return Arquivo<List<Sessao>>.Abrir(arquivo);
            }
            catch
            {
                return new List<Sessao>();
            }
        }
        public static void Salvar(List<Sessao> obj)
        {
            Arquivo<List<Sessao>>.Salvar(arquivo, obj);
        }
    }
}
