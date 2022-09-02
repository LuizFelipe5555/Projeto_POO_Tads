using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    public static class NUsuario
    {
        public static List<Usuario> usuarios;
        public static List<Espectador> espectadores;
        public static List<Admin> administradores;
        public static List<Ingresso> comprados;

        private static string arquivo_comprado = "./comprados.xml";
        private static string arquivo_usuario = "./usuarios.xml";
        private static string arquivo_espectador = "./espectadores.xml";
        private static string arquivo_admin = "./administradores.xml";

        public static Ingresso Listar_Comprados(int id)
        {
            comprados = Abrir_Comprado();
            foreach (Ingresso comprado in comprados)
            {
                if (comprado.Id == id) return comprado;
            }
            return null;
        }
        public static void Inserir_Comprado(Ingresso i)
        {
            comprados = Abrir_Comprado();
            comprados.Add(i);
            Salvar_Comprado(comprados);
        }
        public static void Inserir_Usuario(Usuario u) {
            usuarios = Abrir_Usuarios();
            usuarios.Add(u);
            Salvar_Usuario(usuarios);
        }
        public static bool Autenticar_Admin(string nome, string senha) {
            List<Admin> administradores = Abrir_Admin();
            foreach (Admin conteudo in administradores)
            {
                if (conteudo.Nome == nome && conteudo.Senha == senha)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Autenticar_Espectador(string nome, string senha)
        {
            List<Espectador> espectadores = Abrir_Espectador();
            foreach (Espectador conteudo in espectadores)
            {
                if (conteudo.Nome == nome && conteudo.Senha == senha)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Inserir_Espectador(Espectador esp) {
            espectadores = Abrir_Espectador();


            espectadores.Add(esp);
            Salvar_Espectador(espectadores);
        }
        public static void Inserir_Admin(Admin ad) {
            administradores = Abrir_Admin();


            administradores.Add(ad);
            Salvar_Admin(administradores);
        }
        public static Usuario Listar_Usuario(int id)
        {
            usuarios = Abrir_Usuarios();
            foreach(Usuario u in usuarios)
            {
                if (u.Id == id) return u;
            }
            return null;
        }
        public static List<Usuario> Listar_Usuario()
        {
            usuarios = Abrir_Usuarios();
            return usuarios.OrderBy(u => u.Id).ToList();
        }
        public static List<Admin> Listar_Admins()
        {
            administradores = Abrir_Admin();

            return administradores.OrderBy(adm => adm.Nome).ToList();
        }
        public static List<Espectador> Listar_Espectadores()
        {
            espectadores = Abrir_Espectador();
            return espectadores.OrderBy(esp => esp.Nome).ToList();
        }

        public static Espectador Listar_Espectadores(int id)
        {
            espectadores = Abrir_Espectador();
            foreach (Espectador espectador in espectadores){
                if (espectador.Id == id) return espectador;
            }
            return null;
        }

        public static List<Usuario> Abrir_Usuarios() {
            try
            {
                return Arquivo< List<Usuario> >.Abrir(arquivo_usuario);
            }
            catch (FileNotFoundException)
            {
                return new List<Usuario>();
            }
        }
        public static void Salvar_Usuario(List<Usuario> obj) {
            Arquivo<List<Usuario>>.Salvar(arquivo_usuario, obj);
        }
        public static List<Espectador> Abrir_Espectador(){
            try
            {
                return Arquivo<List<Espectador>>.Abrir(arquivo_espectador);
            }
            catch
            {
                return new List<Espectador>();
            }
        }
        public static void Salvar_Espectador(List<Espectador> obj)
        {
            Arquivo<List<Espectador>>.Salvar(arquivo_espectador, obj);
        }
        public static List<Admin> Abrir_Admin()
        {
            try
            {
                return Arquivo<List<Admin>>.Abrir(arquivo_admin);
            }
            catch
            {
                return new List<Admin>();
            }
        }
        public static void Salvar_Admin(List<Admin> obj)
        {
            Arquivo<List<Admin>>.Salvar(arquivo_admin, obj);
        }
        public static List<Ingresso> Abrir_Comprado()
        {
            try
            {
                return Arquivo<List<Ingresso>>.Abrir(arquivo_comprado);
            }
            catch
            {
                return new List<Ingresso>();
            }
        }
        public static void Salvar_Comprado(List<Ingresso> obj)
        {
            Arquivo<List<Ingresso>>.Salvar(arquivo_comprado, obj);
        }
    }
}
