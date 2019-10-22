using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AtividadeDS
{
    class DAOClass
    {
        
        string resposta = "";
        private Banco db;

        public void Menu()
        {
            DAOClass dao = new DAOClass();
            Usuario usuario = new Usuario();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===========MENU==========\n" +
                              " 0 - Cadastrar Usuario\n" +
                              " 1 - Editar Usuario\n" +
                              " 2 - Excluir Usuario\n" +
                              " 3 - Listar Usuarios\n" +
                              " 4 - Sair \n" +
                              "=========================\n\n" +
                              "Escolha uma das opções acima!");

            resposta = Console.ReadLine();

            switch (resposta)
            {
                case "0":
                    Console.WriteLine("Digite o Nome do usuário");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Nome = Console.ReadLine();

                    Console.WriteLine("Digite o Cargo do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Cargo = Console.ReadLine();

                    Console.WriteLine("Digite a Data de nascimento do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                    dao.Insert(usuario);

                    //var leitor = dao.Listar();
                    dao.RetornaLista();
                    Console.ReadLine();
                    break;

                case "1":
                    Console.WriteLine("Digite o ID do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Id = Convert.ToInt32(Console.ReadLine());

                    if (usuario.Id > 0)
                    {
                        //Atualiza usuario
                        Console.WriteLine("Digite o Nome do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.Nome = Console.ReadLine();

                        Console.WriteLine("Digite o Cargo do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a Data de nascimento do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                        Atualizar(usuario);
                    }
                    else
                    {
                        //Cria usuário
                        Console.WriteLine("Digite o Nome do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.Nome = Console.ReadLine();


                        Console.WriteLine("Digite o Cargo do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.Cargo = Console.ReadLine();


                        Console.WriteLine("Digite a Data de nascimento do usuário", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.DataNasc = DateTime.Parse(Console.ReadLine());
                    }

                    //leitor = dao.Listar();
                    dao.RetornaLista();
                    Console.ReadLine();
                    break;

               case "2":
                    Console.WriteLine("Digite o ID do usuário a ser excluido", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Id = Convert.ToInt32(Console.ReadLine());

                    dao.Excluir(usuario);

                    dao.RetornaLista();
                    Console.ReadLine();
                    break;

                case "3":
                    dao.RetornaLista();
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("Obrigado por utilizar o programa, não esqueça de deixar seu feedback :)\n" +
                        "Pressione qualquer tecla para sair!", Console.ForegroundColor  = ConsoleColor.Green);
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Resposta inválida! Digite uma resposta de 0 a 4\n", Console.ForegroundColor = ConsoleColor.Red);
                    dao.Menu();
                    break;
            }

        }

        //Metodo de Loop que irá chamar o menu enquanto a resposta não for = 4
        public void Loop() {
            var dao = new DAOClass();
            while (resposta != "4")
              {
                dao.Menu();
              }
         }

        private void Insert(Usuario usuario)
        {
            var StrQuery = "";
            StrQuery += "INSERT INTO Usuario(Nome, Cargo, DataNasc)";
            StrQuery += string.Format("VALUES('{0}', '{1}', CONVERT(DATETIME,'{2}',103));",
            usuario.Nome, usuario.Cargo, usuario.DataNasc);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        private void Atualizar(Usuario usuario)
        {
           
            var StrQuery = "";
            StrQuery += "UPDATE Usuario SET ";
            StrQuery += string.Format("Nome = '{0}',", usuario.Nome);
            StrQuery += string.Format("Cargo = '{0}',", usuario.Cargo);
            StrQuery += string.Format("DataNasc = CONVERT(DATETIME, '{0}' ,103)", usuario.DataNasc);
            StrQuery += string.Format("WHERE Id = '{0}'", usuario.Id);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }
        public void Excluir(Usuario usuario)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM Usuario WHERE Id = '{0}'", usuario.Id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
         public void Salvar(Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                Atualizar(usuario);

            }
            else
            {
                Insert(usuario);
            }
        }
        public List<Usuario> Listar()
        {
            var db = new Banco();
            var strQuery = "SELECT * FROM Usuario;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeUsuario(retorno);
        }

        public List<Usuario> ListaDeUsuario(SqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();

            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    Id = int.Parse(retorno["Id"].ToString()),
                    Nome = retorno["Nome"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        //Metodo que faz um Loop para trazer a lista de usuarios
        public void RetornaLista()
        {
            var dao = new DAOClass();
            var leitor = dao.Listar();

            foreach (var usuarios in leitor)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", usuarios.Id,
                usuarios.Nome, usuarios.Cargo, usuarios.DataNasc);
            };

        }

    }
}
