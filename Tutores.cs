using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PetsCareConsole2._0.BancoDados;
using Elastic.Apm.Api;

namespace PetsCareConsole2._0
{
    internal class Tutores
    {
        public const string DBConnecting = @"Data Source=NOTE-TATO;Initial Catalog=DB_Pets_Care;Persist Security Info=True;User ID=sa;Password=124816"; static string connectionString = "Data Source=seu_servidor;Initial Catalog=seu_banco_de_dados;User ID=seu_usuario;Password=sua_senha";

        static void Inic()
        {

        }

        public void Tutor()
        //static void Main(string[] args)
        {
        //Console.BackgroundColor = ConsoleColor.DarkGray;
        //Console.ForegroundColor = ConsoleColor.DarkRed;
            bool executar = true;
            while (executar)
            {
                Console.Write("\t\t\t\t\t\t\tEscolha uma opção:\n");
                Console.WriteLine("|   1. Listar registros    |   2. Adicionar registro    |   3. Atualizar registro    |   4. Excluir registro    |   5. Sair |\n");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                Console.Write("Opção selecionada: ");
                string opcao = Console.ReadLine();

                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        ListarRegistros();
                        break;
                    case "2":
                        Console.Clear();
                        AdicionarRegistro();
                        break;
                    case "3":
                        Console.Clear();
                        AtualizarRegistro();
                        break;
                    case "4":
                        Console.Clear();
                        ExcluirRegistro();
                        break;
                    case "5":
                        Console.Clear();
                        executar = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ListarRegistros()
        {
            try
            {
                //using (SqlConnection connection = new SqlConnection(connectionString))
                using (var conn = new SqlConnection(CONXBD.DBConnecting))
                {
                    conn.Open();

                    string query = "SELECT * FROM Tutores";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Console.Clear();

                    Console.WriteLine("\t\t\t\t\t\tRegistros encontrados:");
                    Console.WriteLine("________________________________________________________________________________________________________________");
                    Console.WriteLine();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write($"ID: {row["ID"]}\t|");
                        Console.Write($"Nome: {row["Nome"]}\t\t|");
                        Console.Write($"Apelido: {row["Apelido"]}\t|");
                        Console.Write($"Telefone: {row["Telefone"]}\t|");
                        Console.Write($"CPF: {row["CPF"]}\t|\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                        Console.Write($"E-mail: {row["Email"]}\t\t\t|");
                        Console.Write($"Data de Nascimento: {row["Dat_Nasc"]}\t\t|");
                        Console.WriteLine($"Cod Endereço: {row["ID_Endereco"]} \t|");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                        Console.Write($"Usuário: {row["Usuario"]}\t|");
                        Console.WriteLine($"Senha: {row["Senha"]} \t|");
                        Console.WriteLine("\n_________________________________________________________________________________________________________________");
                        //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar registros: " + ex.Message);
            }
        }


        static void AdicionarRegistro()
        {
            try
            {
                string senha1 = "";
                string senha2 = "";

                Console.WriteLine("Novo Cadastro, informe os campos a Seguir:");

                Console.Write("Nome Completo: ");
                string Nome = Console.ReadLine();

                Console.Write("Apelido: ");
                string Apelido = Console.ReadLine();

                Console.Write("Telefone: ");
                string Telefone = Console.ReadLine();

                Console.Write("CPF: ");
                string CPF = Console.ReadLine();

                Console.Write("E-Mail: ");
                string Email = Console.ReadLine();

                Console.Write("Data de Nascimento: ");
                string Dat_Nasc = Console.ReadLine();

                Console.Write("Código de Cadastro de Endereço: ");
                int ID_Endereco = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nome de Usuário: ");
                string Usuario = Console.ReadLine();
                repSenha();

                void repSenha()
                {

                    Console.WriteLine($"{Nome} agora só cadastrar a senha:");
                    Console.WriteLine("Informe a Senha:");
                    senha1 = Console.ReadLine();
                    int Cont = senha1.Length;
                    if (Cont < 3)
                    {
                        Console.Write($"\n{Nome} a senha é muito Curta, Refaça\t");
                        Console.Write("Precione qualquer Tecla\n");
                        Console.ReadKey();
                        repSenha();
                    }
                    else
                    {
                        Console.WriteLine($"{Nome} Repita a Senha Novamente:");
                        senha2 = Console.ReadLine();
                        if (senha1 != senha2)
                        {
                            Console.WriteLine("Senha não conefere!");
                            Console.WriteLine("Nova Tentativa em: 30s");
                            Thread.Sleep(1500);
                            for (int i = 30; i >= 0; i--)
                            {
                                Console.Write($"{i}s");
                                Thread.Sleep(100);
                                Console.Clear();
                                repSenha();
                            }
                        }
                }
                       
                        string Senha = senha2;

                        using (var conn = new SqlConnection(CONXBD.DBConnecting))
                    {
                            conn.Open();

                            string query = "INSERT INTO Tutores (Nome, Apelido, Telefone, CPF, Email, Dat_Nasc, ID_Endereco, Usuario, Senha) " +
                            "VALUES (@Nome, @Apelido, @Telefone, @CPF, @Email, @Dat_Nasc, @ID_Endereco, @Usuario , @Senha)";
                            SqlCommand command = new SqlCommand(query, conn);

                            command.Parameters.AddWithValue("@Nome", Nome);
                            command.Parameters.AddWithValue("@Apelido", Apelido);
                            command.Parameters.AddWithValue("@Telefone", Telefone);
                            command.Parameters.AddWithValue("@CPF", CPF);
                            command.Parameters.AddWithValue("@Email", Email);
                            command.Parameters.AddWithValue("@Dat_Nasc", Dat_Nasc);
                            command.Parameters.AddWithValue("@ID_Endereco", ID_Endereco);
                            command.Parameters.AddWithValue("@Usuario", Usuario);
                            command.Parameters.AddWithValue("@Senha", Senha);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Registro adicionado com sucesso!");
                                Console.Write("Cadastro Ok");
                                Thread.Sleep(1500);
                            Console.Clear();
                                Inic();
                            }
                            else
                            {
                                Console.WriteLine("Erro ao adicionar registro.");
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar registro: " + ex.Message);
            }
        }

        static void AtualizarRegistro()
        {
            try
            {
                Console.Write("Digite o ID do registro a ser atualizado: ");
                string id = Console.ReadLine();

                Console.WriteLine("Digite os novos dados para atualização:");
                Console.Write("Coluna1: ");
                string coluna1 = Console.ReadLine();

                Console.Write("Coluna2: ");
                string coluna2 = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Tabela SET Coluna1 = @Coluna1, Coluna2 = @Coluna2 WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Coluna1", coluna1);
                    command.Parameters.AddWithValue("@Coluna2", coluna2);
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Registro atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao atualizar registro. Verifique se o ID está correto.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar registro: " + ex.Message);
            }
        }

        static void ExcluirRegistro()
        {
            try
            {
                Console.Write("Digite o ID do registro a ser excluído: ");
                string id = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Tabela WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Registro excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir registro. Verifique se o ID está correto.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir registro: " + ex.Message);
            }

        }

    }
}
