using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gerenciamento_Ingresso
{
    class Program
    {
        public static Espectador espec;
        public static List<Ingresso>quantidade_ingresso;

        public static void Main()
        {
            

            int op = 0;
            do
            {
                try
                {
                    op = Opcoes();
                    switch (op)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Cadastro();
                            break;
                    }


                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            } while (op != 99);
        }

        static void MainAdmin()
        {
            int op = 100;
            while (op != 0)
            {
                Console.WriteLine("----- Ações de Administrador -----");
                Console.WriteLine("1  - Listar Usuarios.");
                Console.WriteLine("2  - Listar Administradores.");
                Console.WriteLine("3  - Inserir Administrador.");
                Console.WriteLine("4  - Listar Espectadores.");
                Console.WriteLine();
                Console.WriteLine("5  - Inserir Cadeira.");
                Console.WriteLine("6  - Atualizar Cadeiras.");
                Console.WriteLine("7  - Excluir Cadeira.");
                Console.WriteLine("8  - Listar Cadeiras.");
                Console.WriteLine();
                Console.WriteLine("9  - Inserir Cinema.");
                Console.WriteLine("10 - Listar Cinema.");
                Console.WriteLine("11 - Atualizar Cinema.");
                Console.WriteLine("12 - Excluir Cinema.");
                Console.WriteLine();
                Console.WriteLine("13 - Inserir Sessão.");
                Console.WriteLine("14 - Atualizar Sessão.");
                Console.WriteLine("15 - Listar Sessões.");
                Console.WriteLine("16 - Excluir Sessão");
                Console.WriteLine();
                Console.WriteLine("17 - Inserir Filme");
                Console.WriteLine("18 - Listar Filmes.");
                Console.WriteLine("19 - Atualizar Filme");
                Console.WriteLine("20 - Excluir Filme.");
                Console.WriteLine();
                Console.WriteLine("21 - Inserir Ingresso.");
                Console.WriteLine("22 - Listar Ingressos.");
                Console.WriteLine("23 - Atualizar Ingresso");
                Console.WriteLine("24 - Excluir Ingresso");
                Console.WriteLine();
                Console.WriteLine("25 - Exibir Vendas");
                Console.WriteLine();
                Console.WriteLine("0 - voltar.");
                Console.Write("Insira uma opção: ");
                op = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (op)
                {
                    case 1:
                        Listar_Usuario();
                        break;
                    case 2:
                        Listar_Admins();
                        break;
                    case 3:
                        Inserir_Admin();
                        break;
                    case 4:
                        Listar_Espectadores();
                        break;
                    case 5:
                        Inserir_Cadeira();
                        break;
                    case 6:
                        Atualizar_Cadeira();
                        break;
                    case 7:
                        Excluir_Cadeira();
                        break;
                    case 8:
                        Listar_Cadeira();
                        break;
                    case 9:
                        Inserir_Cinema();
                        break;
                    case 10:
                        Listar_Cinema();
                        break;
                    case 11:
                        Atualizar_Cinema();
                        break;
                    case 12:
                        Excluir_Cinema();
                        break;
                    case 13:
                        Inserir_Sessao();
                        break;
                    case 14:
                        Atualizar_Sessao();
                        break;
                    case 15:
                        Listar_Sessao();
                        break;
                    case 16:
                        Excluir_Sessao();
                        break;
                    case 17:
                        Inserir_Filme();
                        break;
                    case 18:
                        Listar_Filme();
                        break;
                    case 19:
                        Atualizar_Filme();
                        break;
                    case 20:
                        Excluir_Filme();
                        break;
                    case 21:
                        Inserir_Ingresso();
                        break;
                    case 22:
                        Listar_Ingresso();
                        break;
                    case 23:
                        Atualizar_Ingresso();
                        break;
                    case 24:
                        Excluir_Ingresso();
                        break;
                    case 25:
                        Exibir_Vendas();
                        break;
                    case 0:
                        break;

                }
            }

        }
        static void Main_Espectador()
        {
            int op = 99;
            while (op != 0) { 
                Console.WriteLine();
                Console.WriteLine("---- Ações de Espectador ----");
                Console.WriteLine("1 - Listar Cinema ");
                Console.WriteLine("2 - Listar Filme");
                Console.WriteLine("3 - Listar Sessões");
                Console.WriteLine("4 - Escolher Ingresso");
                Console.WriteLine("5 - Remover Ingresso");
                Console.WriteLine("6 - Listar Ingressos");
                Console.WriteLine("7 - Confirmar Compra");
                Console.WriteLine("0 - Sair.");
                Console.Write("Escolha uma opção: ");

                op = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (op)
                {
                    case 1:
                        Listar_Cinema();
                        break;
                    case 2:
                        Listar_Filme();
                        break;
                    case 3:
                        Listar_Sessao();
                        break;
                    case 4:
                        Escolher_Ingresso();
                        break;
                    case 5:
                        Remover_Ingresso();
                        break;
                    case 6:
                        Listar_Ingressos();
                        break;
                    case 7:
                        Confirmar_Compra();
                        break;
                    case 0:
                        break;

                }
            }

        }

        public static int Opcoes()
        {
            int saida;
            Console.WriteLine("------ Gerenciador de Ingressos ------");
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Registrar-se");
            Console.WriteLine("99 - Fechar programa");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            
            saida = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return saida;
        }
        public static void Inserir_Admin()
        {
            Console.WriteLine("------ Adicionar Administrador ------");
            Listar_Usuario();
            Console.Write("Insira o id: ");
            int id = int.Parse(Console.ReadLine());
            Usuario admin = NUsuario.Listar_Usuario(id);

            NUsuario.espectadores = NUsuario.Abrir_Espectador();
            Espectador espectado = NUsuario.Listar_Espectadores(id);
            NUsuario.espectadores.Remove(espectado);
            NUsuario.Salvar_Espectador(NUsuario.espectadores);

            Admin novo_admin = new Admin { Id = id, Nome = admin.Nome, Senha = admin.Senha };
            NUsuario.Inserir_Admin(novo_admin);
            Console.WriteLine("Administrador inserido.");
            Console.WriteLine();
        }
        public static void Cadastro()
        {
            Console.WriteLine("----- Cadastro de Usuário ------");
            Console.Write("Insira um nome: ");
            string nome = Console.ReadLine();
            Console.Write("Insira uma senha: ");
            string senha = Console.ReadLine();
            Console.Write("Insira um id: ");
            int id = int.Parse(Console.ReadLine());

            Usuario novo = new Usuario {Id = id, Senha = senha, Nome = nome};


            Espectador novo_espectador = new Espectador { Id_espectador = novo.Id, Nome = nome, Senha = senha};

            NUsuario.Inserir_Usuario(novo);
            NUsuario.Inserir_Espectador(novo_espectador);
            
            Console.WriteLine("Usuário cadastrado");
            Console.WriteLine();
        }
        public static void Listar_Espectadores()
        {
            List<Espectador> espectadores = NUsuario.Listar_Espectadores();
            foreach (var item in espectadores)
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Senha: {item.Senha}");
            Console.WriteLine();
        }
        public static void Listar_Admins()
        {
            List<Admin> administradores = NUsuario.Listar_Admins();
            foreach (var item in administradores)
            {
                Console.WriteLine($"{item.Id} - {item.Nome} - {item.Senha}");
            }
            Console.WriteLine();
        }
        public static void Listar_Usuario()
        {
            List<Usuario> usuarios = NUsuario.Listar_Usuario();
            foreach (var item in usuarios)
                Console.WriteLine($"{item.Id} - {item.Nome} - {item.Senha}");
            Console.WriteLine();
        }
        public static void Login()
        {
            Console.Write("Insira o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Insira a senha: ");
            string senha = Console.ReadLine();
            if (nome == "admin" && senha == "admin")
            {
                MainAdmin();
            }
            else if (NUsuario.Autenticar_Admin(nome, senha) == true && NUsuario.Autenticar_Espectador(nome, senha) == true)
            {
                MainAdmin();
            }
            else if (NUsuario.Autenticar_Espectador(nome, senha) == true)
            {
                List<Espectador> usuarios = NUsuario.Abrir_Espectador();
                foreach(Espectador usuario in usuarios)
                {
                    if (usuario.Nome == nome && usuario.Senha == senha)
                    {
                        espec = usuario;
                    }
                }
                Main_Espectador();
            }
        }
        public static void Inserir_Ingresso()
        {
            Console.WriteLine("------ Seleção de Ingresso ------");
            Console.Write("Insira o id do ingresso: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira o tipo de ingresso: ");
            string tipo = Console.ReadLine();
            Console.Write("Insira o preço do ingresso: ");
            int preco = int.Parse(Console.ReadLine());
            Listar_Sessao();
            
            Ingresso ig = new Ingresso { Id = id, Tipo_ingresso = tipo, Preco = preco};
            NIngresso.Inserir_Ingresso(ig);
            Console.WriteLine("Ingresso inserido");
            Console.WriteLine();
            
        }
        public static void Inserir_Cadeira()
        {
            
            Console.WriteLine("----- Inserir Cadeira -----");
            Console.Write("Insirao o id da cadeira: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira a fileira da cadeira: ");
            string fileira_cadeira = Console.ReadLine();
            Console.Write("Insira a coluna da cadeira: ");
            string coluna_cadeira = Console.ReadLine();
            Console.Write("Insira o tipo de cadeira: ");
            string cadeira_tipo = Console.ReadLine();
            Listar_Cinema();
            Console.Write("Insira o id do Cinema: ");
            int id_Cinema = int.Parse(Console.ReadLine());

            Cadeira cad = new Cadeira { Cadeira_coluna = coluna_cadeira, Id = id, Cadeira_fileira = fileira_cadeira, Cadeira_tipo = cadeira_tipo, Id_cinema = id_Cinema };
            NCadeira.Inserir(cad);
            Console.WriteLine("Cadeira Inserida.");
            Console.WriteLine();

        }
        public static void Atualizar_Cadeira()
        {
            Listar_Cadeira();
            Console.WriteLine("Insira o id da cadeira que será atualizada: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira a nova fileira da cadeira: ");
            string fileira_nova = Console.ReadLine();
            Console.Write("Insira a coluna nova da cadeira: ");
            string coluna_nova = Console.ReadLine();
            Console.Write("Insira o novo tipo de cadeira: ");
            string tipo_cadeira = Console.ReadLine();
            Listar_Cinema();
            Console.Write("Insira o novo id do cinema: ");
            int id_Cinema = int.Parse(Console.ReadLine());
            
            Cadeira cadeira = new Cadeira { Cadeira_coluna = coluna_nova, Cadeira_fileira = fileira_nova, Cadeira_tipo = tipo_cadeira, Id = id, Id_cinema = id_Cinema };

            NCadeira.Atualizar(cadeira);
            Console.WriteLine("Cadeira atualizada.");
        }
        public static void Listar_Cadeira()
        {
            Console.WriteLine();
            Console.WriteLine("------ Listar Cadeiras ------");
            List<Cadeira> lista = NCadeira.Abrir();
            foreach(Cadeira cadeira in lista)
            {
                Console.WriteLine(cadeira);
            }
        }
        public static void Excluir_Cadeira()
        {
            Console.WriteLine();
            Console.WriteLine("------ Excluir Cadeiras ------");
            Listar_Cadeira();
            Console.Write("Insira o id da cadeira: ");
            int id = int.Parse(Console.ReadLine());
            Cadeira cade = NCadeira.Listar(id);
            NCadeira.cadeiras = NCadeira.Abrir();
            NCadeira.cadeiras.Remove(cade);

        }

        public static void Inserir_Cinema()
        {
            Console.WriteLine();
            Console.WriteLine("------ Inserir Cinema ------");
            Console.Write("Insira um id parao o cinema: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira um Nome para o cinema: ");
            string nome = Console.ReadLine();
            Console.Write("Insira um estado para o cinema:");
            string estado = Console.ReadLine();
            Console.Write("Insira uma cidade para o cinema: ");
            string cidade = Console.ReadLine();
            Console.Write("Insira um endereço parao  cinema: ");
            string endereco = Console.ReadLine();

            Cinema cine = new Cinema { Cidade = cidade, Endereco = endereco, Estado = estado, Id = id, Nome = nome };

            NCinema.Inserir(cine);
            Console.WriteLine("Cinema inserido.");
        }
        public static void Atualizar_Cinema()
        {
            Console.WriteLine("------ Atualizar Cinema ------");
            Listar_Cinema();
            Console.Write("Insira o id do Cinema que será atualizado: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira o novo nome do cinema: ");
            string nome = Console.ReadLine();
            Console.Write("Insira o novo estado: ");
            string estado = Console.ReadLine();
            Console.Write("Insira a nova cidade:  ");
            string cidade = Console.ReadLine();
            Console.Write("Insira o novo endereço: ");
            string endereco = Console.ReadLine();
            

            Cinema cine = new Cinema { Cidade = cidade, Endereco = endereco, Id = id, Nome = nome, Estado = estado};

            NCinema.Atualizar(cine);
            Console.WriteLine("Cinema atualizado.");
            Console.WriteLine();


        }
        public static void Listar_Cinema()
        {
            List<Cinema> cinemas = NCinema.Abrir();
            foreach (Cinema cine in cinemas)
            {
                Console.WriteLine(cine);
            }
        }
        public static void Excluir_Cinema()
        {
            Console.WriteLine("------ Excluir Cinema ------");
            Listar_Cinema();
            Console.Write("Insira o id do cinema: ");
            int id = int.Parse(Console.ReadLine());
            Cinema cine = NCinema.Listar(id);


            NCinema.Excluir(cine);
            Console.WriteLine("Cinema excluido.");
            Console.WriteLine();
        }
        public static void Inserir_Sessao()
        {
            Console.WriteLine("------ Inserir Sessão ------");
            Console.Write("Insira um id para a sessão: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira o sala do filme: ");
            string sala = Console.ReadLine();
            Console.Write("Insira a data da sessão: ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.Write("Insira a hora da sessão: ");
            int hora = int.Parse(Console.ReadLine());
            Listar_Filme();
            Console.Write("Insira o id do filme: ");
            int id_filme = int.Parse(Console.ReadLine());
            Listar_Cinema();
            Console.Write("Insira o id do cinema: ");
            int id_Cinema = int.Parse(Console.ReadLine());

            Sessao s = new Sessao { Data_Sessao = data, Hora_sessao = hora, Id = id, Id_Cinema = id_Cinema, Id_Filme = id_filme, Sala = sala };
            NSessao.Inserir(s);

            
            Console.WriteLine("Sessão inserida.");
            Console.WriteLine();
        }
        public static void Atualizar_Sessao()
        {
            Console.WriteLine("------ Atualizar Sessão ------");
            Console.Write("Insira um id para a sessão: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira a sala nova do filme: ");
            string sala = Console.ReadLine();
            Console.Write("Insira a data nova da sessão: ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.Write("Insira a hora nova da sessão: ");
            int hora = int.Parse(Console.ReadLine());
            Listar_Filme();
            Console.Write("Insira o id novo do filme: ");
            int id_filme = int.Parse(Console.ReadLine());
            Listar_Cinema();
            Console.Write("Insira o id novo do cinema: ");
            int id_Cinema = int.Parse(Console.ReadLine());

            Sessao s = new Sessao { Data_Sessao = data, Hora_sessao = hora, Id = id, Id_Cinema = id_Cinema, Id_Filme = id_filme, Sala = sala };
            NSessao.Atualizar(s);
            Console.WriteLine("Sessão Atualizada");
        }
        public static void Listar_Sessao()
        {
            List<Sessao> sessoes = NSessao.Abrir();
            List<Filme> filmes = NFilme.Abrir();
            List<Cinema> cinemas = NCinema.Abrir();
            foreach (Sessao s in sessoes)
            {
                foreach (Filme filme in filmes)
                {
                    if (filme.Id == s.Id_Filme)
                    {
                        foreach (Cinema cinema in cinemas)
                        {
                            if (cinema.Id == s.Id_Cinema)
                            {
                                Console.WriteLine($"Id:{s.Id} - Sala:{s.Sala} - Data:{s.Data_Sessao} - Hora:{s.Hora_sessao} - Filme:{filme.Nome_filme} - Gênero{filme.Genero} - Filme:{filme.Avaliacao} - Cinema:{cinema.Nome} - Cidade:{cinema.Cidade} - Estado:{cinema.Estado} - Endereco:{cinema.Endereco}");
                            }
                        }
                    }
                }
            }
        }
        public static void Excluir_Sessao()
        {
            Console.WriteLine("------ Excluir Cinema ------");
            Listar_Sessao();
            Console.Write("Insira o id do cinema para ser excluido: ");
            int id = int.Parse(Console.ReadLine());

            Sessao s = NSessao.Listar(id);
            NSessao.Excluir(s);
            Console.WriteLine("Sessão excluida.");
            Console.WriteLine();
        }
        public static void Inserir_Filme()
        {
            Console.WriteLine("------ Inserir Filme ------");
            Console.Write("Insira um id para o filme: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira o nome do filme: ");
            string nome = Console.ReadLine();
            Console.Write("Insira a quantiade de estrelas do filme: ");
            int avaliacao = int.Parse(Console.ReadLine());
            Console.Write("Insira o gênero do filme: ");
            string genero = Console.ReadLine();

            Filme filme = new Filme { Avaliacao = avaliacao, Genero = genero, Id = id, Nome_filme = nome };
            NFilme.Inserir(filme);
            Console.WriteLine("Filme inserido.");
            Console.WriteLine();
        }
        public static void Atualizar_Filme()
        {
            Console.WriteLine("------ Atualizar Filme ------");
            Listar_Filme();
            Console.Write("Insira um id para o filme: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Insira o novo nome do filme: ");
            string nome = Console.ReadLine();
            Console.Write("Insira a nova quantiade de estrelas do filme: ");
            int avaliacao = int.Parse(Console.ReadLine());
            Console.Write("Insira o novo gênero do filme: ");
            string genero = Console.ReadLine();

            Filme filme = new Filme { Avaliacao = avaliacao, Genero = genero, Id = id, Nome_filme = nome };
            NFilme.Atualizar(filme);

            Console.WriteLine("Filme Atualizado");
            Console.WriteLine();
        }
        public static void Listar_Filme()
        {
            //Console.WriteLine(NFilme.Listar());
            List<Filme> filmes = NFilme.Abrir();
            foreach(var item in filmes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void Excluir_Filme()
        {
            Console.WriteLine("------ Excluir Filme ------");
            Listar_Filme();
            Console.Write("Insira o id do filme para ser excluido: ");
            int id = int.Parse(Console.ReadLine());

            Filme f = NFilme.Listar(id);
            NFilme.Excluir(f);
            Console.WriteLine("Filme Excluido");
        }
        public static void Exibir_Vendas()
        {
            List<Ingresso> ingressos = NUsuario.Abrir_Comprado();
            int Venda_total = 0;
            foreach(var i in ingressos)
            {
                Console.WriteLine($"{i.Id} - {i.Tipo_ingresso} - {i.Preco} - {NUsuario.Listar_Espectadores(i.Id_Espectador)} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_coluna} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_fileira} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_tipo} - {NSessao.Listar(i.Id_Sessao).Sala} - {NSessao.Listar(i.Id_Sessao).Hora_sessao} - {NSessao.Listar(i.Id_Sessao).Data_Sessao}");
                Venda_total = i.Preco + Venda_total;
            }
            Console.WriteLine($"Total de vendas = {Venda_total}");
            Console.WriteLine();
        }
        public static void Listar_Ingresso()
        {
            List<Ingresso> ingresso = NIngresso.Abrir_Ingresso();
            foreach(var item in ingresso)
            {
                Console.WriteLine(item);
            }
        }
        public static void Atualizar_Ingresso()
        {
            Console.WriteLine("------ Atualização de Ingresso ------");
            Console.WriteLine("Insira o id do ingresso");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o novo tipo de ingresso");
            string tipo = Console.ReadLine();
            Console.Write("Insira o novo preço do ingresso: ");
            int preco = int.Parse(Console.ReadLine());
            Listar_Sessao();
            Console.Write("Insira o novo id da sessão");

            Ingresso ig = new Ingresso { Id = id, Tipo_ingresso = tipo, Preco = preco };
            NIngresso.Atualizar_1(ig);
            Console.WriteLine("Novo Ingresso inserido");
            Console.WriteLine();
        }
        public static void Excluir_Ingresso()
        {
            Listar_Ingresso();
            Console.Write("Insira o id do ingresso para ser excluido: ");
            int id = int.Parse(Console.ReadLine());
            Ingresso i = NIngresso.Listar_Ingresso(id);
            NIngresso.Excluir(i);

            Console.WriteLine("Ingresso Excluido");
            Console.WriteLine();
        }
        public static void Confirmar_Compra()
        {
            foreach(var item in quantidade_ingresso)
            {
                NUsuario.Inserir_Comprado(item);
            }
            Console.WriteLine("Compra Realizada");
            Console.WriteLine();
            quantidade_ingresso = null;
        }
        public static void Escolher_Ingresso()
        {
            Listar_Ingresso();
            Console.Write("Escolha o ingresso: ");
            int id = int.Parse(Console.ReadLine());
            Ingresso ig = NIngresso.Listar_Ingresso(id);

            Ingresso ig_2 = new Ingresso { Id = id, Id_Cadeira = ig.Id_Cadeira, Id_Espectador = espec.Id, Id_Sessao = ig.Id_Sessao, Preco = ig.Preco, Tipo_ingresso = ig.Tipo_ingresso };
            quantidade_ingresso.Add(ig_2);
            Console.WriteLine("Ingresso adicionado.");
            Console.WriteLine();
        }
        public static void Remover_Ingresso()
        {
            Ingresso ingresso;
            foreach (Ingresso i in quantidade_ingresso)
            {
                Console.WriteLine($"{i.Id} - {i.Preco} - {i.Tipo_ingresso} - {NUsuario.Listar_Espectadores(i.Id_Espectador)}");
            }
            Console.Write("Insira o id do ingresso para ser excluido");
            int id = int.Parse(Console.ReadLine());

            foreach (Ingresso i in quantidade_ingresso)
            {
                if (i.Id == id)
                {
                    ingresso = i;
                    quantidade_ingresso.Remove(ingresso);
                    Console.WriteLine("Ingresso removido");
                    Console.WriteLine();
                    break;
                }
            }
        }
        public static void Listar_Ingressos()
        {
            foreach (Ingresso i in quantidade_ingresso)
            {
                Console.WriteLine($"{i.Id} - {i.Tipo_ingresso} - {i.Preco} - {NUsuario.Listar_Espectadores(i.Id_Espectador)} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_coluna} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_fileira} - {NCadeira.Listar(i.Id_Cadeira).Cadeira_tipo} - {NSessao.Listar(i.Id_Sessao).Sala} - {NSessao.Listar(i.Id_Sessao).Hora_sessao} - {NSessao.Listar(i.Id_Sessao).Data_Sessao}");
            }
        }

    }
}
