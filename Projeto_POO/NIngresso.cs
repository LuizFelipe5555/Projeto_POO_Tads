using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    public static class NIngresso
    {
        public static List<Ingresso> ingressos;
        public static List<Ingresso> nao_comprados;

        public static void Inserir_Escolha(Ingresso i)
        {
            nao_comprados = Abrir_naocomprado();
            nao_comprados.Add(i);
            Salvar_naocomprado(nao_comprados);
            
        }

        public static void Inserir_Ingresso(Ingresso i)
        {
            ingressos = Abrir_Ingresso();
            ingressos.Add(i);
            Salvar_Ingresso(ingressos);
        }

        public static List<Ingresso> Listar_Ingresso()
        {
            ingressos = Abrir_Ingresso();
            return ingressos.OrderBy(i => i.Id).ToList();
        }


        public static Ingresso Listar_Ingresso(int id)
        {
            ingressos = Abrir_Ingresso();

            foreach (Ingresso conteudo in ingressos)
            {
                if (conteudo.Id == id) return conteudo;
            }
            return null;
        }

        public static void Atualizar(Ingresso i)
        {
            Ingresso atual = Listar_Ingresso(i.Id);
            if (atual != null)
            {
                atual.Tipo_ingresso = i.Tipo_ingresso;
                atual.Preco = i.Preco;
                atual.Id_Sessao = i.Id_Sessao;
                atual.Id_Cadeira = i.Id_Cadeira;
                atual.Id = i.Id;
                atual.Id_Espectador = i.Id_Espectador;
                Salvar_Ingresso(ingressos);
            }
        }

        public static void Atualizar_1(Ingresso i)
        {
            Ingresso atual = Listar_Ingresso(i.Id);
            if (atual != null)
            {
                atual.Tipo_ingresso = i.Tipo_ingresso;
                atual.Preco = i.Preco;
                atual.Id_Sessao = i.Id_Sessao;
                atual.Id = i.Id;
                Salvar_Ingresso(ingressos);
            }
        }

        public static void Excluir(Ingresso i)
        {
            Ingresso atual = Listar_Ingresso(i.Id);
            if (atual != null)
            {
                ingressos.Remove(atual);
                Salvar_Ingresso(ingressos);
            }
        }

        private static string arquivo_ingresso = "ingressos.xml";
        private static string arquivo_naocomprado = "nao_comprados.xml";
        public static List<Ingresso> Abrir_Ingresso()
        {
            try
            {
                return Arquivo<List<Ingresso>>.Abrir(arquivo_ingresso);
            }
            catch (FileNotFoundException)
            {
                return new List<Ingresso>();
            }
        }
        public static void Salvar_Ingresso(List<Ingresso> obj)
        {
            Arquivo<List<Ingresso>>.Salvar(arquivo_ingresso, obj);
        }
        public static List<Ingresso> Abrir_naocomprado()
        {
            try
            {
                return Arquivo<List<Ingresso>>.Abrir(arquivo_naocomprado);
            }
            catch (FileNotFoundException)
            {
                return new List<Ingresso>();
            }
        }
        public static void Salvar_naocomprado(List<Ingresso> obj)
        {
            Arquivo<List<Ingresso>>.Salvar(arquivo_naocomprado, obj);
        }
    }
}
