using Elastic.Apm.Api;
using PetsCareConsole2._0.BancoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PetsCareConsole2._0.Criptografy;
using System.Data;

namespace PetsCareConsole2._0
{
    internal class LoginCadastro
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string Telefone { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Dat_Nasc { get; private set; }
        public int ID_Endereco { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        public LoginCadastro()
        {

        }
        public void Logar()
        {
            Console.WriteLine("Insira seu usuário");
            string usuario = Console.ReadLine();
            Console.WriteLine("Insira a senha");
            string senha = Console.ReadLine();

            using (var conn = new SqlConnection(CONXBD.DBConnecting))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ID, Nome, Apelido, Telefone, CPF, Email, Dat_Nasc, ID_Endereco, Usuario, Senha FROM Tutores WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", ID);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        Apelido = reader.GetString(2);
                        Telefone = reader.GetString(3);
                        CPF = reader.GetString(4);
                        Email = reader.GetString(5);
                        Dat_Nasc = reader.GetString(6);
                        ID_Endereco = reader.GetInt32(7);
                        Usuario = reader.GetString(8);
                        Senha = reader.GetString(9);
                    }
                }
            }

            static bool VerificarLoginSenha(string Ususario, string Senha, string connectionString)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT COUNT(*) FROM Tutores WHERE Usuario = @Usuario AND Senha = @Senha";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Usuario", Ususario);
                            command.Parameters.AddWithValue("@Senha", Senha);
                            int count = (int)command.ExecuteScalar();

                            return count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao verificar login e senha: " + ex.Message);
                    return false;
                }
            }

            //if (VerificarLoginSenha(Usuario, Senha, connectionString))
            //{
            //    Console.WriteLine("Login bem-sucedido!");
            //}
            //else
            //{
            //    Console.WriteLine("Nome de usuário ou senha incorretos.");
            //}

            //Console.ReadLine();
        }

        //private bool _autenticado = false;
        //    public string Usuario { get; private set; }

        //    public LoginCadastro(string usuario, string senha)
        //    {
        //    var cadastroUser = new CadastroUser(usuario);

        //    if (Usuario.ID > 0 && ValidPassword(senha, usuario))
        //        {
        //            _autenticado = true;
        //            Usuario = cadastroUser.Usuario;
        //        }
        //    }

        //private bool ValidPassword(string senha, string usuario)
        //{
        //    throw new NotImplementedException();
        //}

        //private bool ValidPassword(string senha, CadastroUser usuario)
        //    {
        //        var passwordHash = HashGenerator.GenerateHash(senha, HashType.MD5);
        //        return passwordHash.ToUpper() == usuario.Senha;
        //    }

        //    public bool Autenticado()
        //    {
        //        return _autenticado;
        //    }

        //public int ID { get; private set; }
        //public string Usuario { get; private set; }
        //public string Senha { get; private set; }

        //public LoginCadastro(string usuario)
        //{
        //    using (var conn = new SqlConnection(CONXBD.DBConnecting))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();

        //        cmd.CommandText = "SELECT ID, Usuario, Senha FROM Tutores WHERE Usuario = @Usuario";
        //        cmd.Parameters.AddWithValue("@Usuario", Usuario);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                ID = reader.GetInt32(0);
        //                Usuario = reader.GetString(1);
        //                Senha = reader.GetString(2);
        //                //IsActive = reader.GetString(3) == "X" ? true : false;
        //            }
        //        }
        //    }
        //}

        //public LoginCadastro(string usuario, string senha)
        //{
        //    Usuario = usuario;
        //    Senha = senha;
        //}

        //public void Save()
        //{
        //    using (var conn = new SqlConnection(CONXBD.DBConnecting))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();

        //        cmd.CommandText = "INSERT INTO USERS (Usuario, Senhas) VALUES (@Usuario, @Senha)";
        //        cmd.Parameters.AddWithValue("@Usuario", Usuario);
        //        cmd.Parameters.AddWithValue("@Senha", HashGenerator.GenerateHash(Senha, HashType.MD5).ToUpper());

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //___________________________________________________________________

        //internal void logar(string Usuario, string Senha)
        //{
        //    try
        //    {

        //        string sql = "select * From Tutores where Usuario = @Usuario and Senha = @Senha";

        //        using (var conn = new SqlConnection(CONXBD.DBConnecting))
        //        {
        //            conn.Open();
        //            var cmd = conn.CreateCommand();

        //        }
        //    }

        //    catch (Exception erro)
        //    {
        //        Console.WriteLine("Erro: " + erro);

        //    }


        //}

    }
}
