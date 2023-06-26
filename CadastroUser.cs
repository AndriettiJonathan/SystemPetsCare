using PetsCareConsole2._0.BancoDados;
using PetsCareConsole2._0.Criptografy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareConsole2._0
{
    public class CadastroUser //Ok
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

        string user = "";
        
        public void CadUser()
        {
            Console.WriteLine("Informe o nome de acesso:");
            user = Console.ReadLine();
            SenhaNova();
        }
            string senha1 = "";
            string senha2 = "";

        public CadastroUser(string usuario)
        {
            Usuario = usuario;
        }

        public CadastroUser()
        {
        }

        //public CadastroUser(string usuario)
        //{
        //    Usuario = usuario;
        //}

        public void SenhaNova()
        {
            Console.Clear();
            Console.WriteLine($"{user} agora só cadastrar a senha:");
            Console.WriteLine("Informe a Senha:");
            senha1 = Console.ReadLine();
            int Cont = senha1.Length;
            if (Cont < 3)
            {
                Console.Write($"\n{user} a senha é muito Curta, Refaça\t");
                Console.Write("Precione qualquer Tecla\n");
                Console.ReadKey();
                SenhaNova();
            }
            else
            {
                Console.WriteLine($"{user} Repita a Senha Novamente:");
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
                    }
                        SenhaNova();
                }
                else
                {
                    Usuario = user;
                    Senha = senha2;
                    Console.Write("Informe o nome Completo: ");
                    Nome = Console.ReadLine();
                    Console.Write("Informe seu Apelido: ");
                    Apelido = Console.ReadLine();
                    Console.Write("Telefone de Contato: ");
                    Telefone = Console.ReadLine();
                    Console.Write("Seu CPF: ");
                    CPF = Console.ReadLine();
                    Console.Write("E-mail: ");
                    Email = Console.ReadLine();
                    Console.Write("Data de Nascimento: ");
                    Dat_Nasc = Console.ReadLine();
                    ID_Endereco = 1;
                    
                    Console.Write("Cadastro Ok");
                    Thread.Sleep(1500);
                    Save();
                }
            }
        }

        public void Save()
        {
            using (var conn = new SqlConnection(CONXBD.DBConnecting))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Tutores(Nome, Apelido, Telefone, CPF, Email, Dat_Nasc, ID_Endereco, Usuario, Senha) " +
                    "VALUES (@Nome, @Apelido, @Telefone, @CPF, @Email, @Dat_Nasc, @ID_Endereco, @Usuario , @Senha)";

                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Apelido", Apelido);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Dat_Nasc", Dat_Nasc);
                cmd.Parameters.AddWithValue("@ID_Endereco", ID_Endereco);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Senha", HashGenerator.GenerateHash(Senha, HashType.MD5).ToUpper());

                cmd.ExecuteNonQuery();
            }
        }

        //public bool IsValid()
        //{
        //    return ID > 0;
        //}

        //public CadastroUser(string usuario)
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
        //                Usuario = reader.GetString(8);
        //                Senha = reader.GetString(9);
        //            }
        //        }
        //    }
        //}

        //public CadastroUser(string usuario, string senha)
        //{
        //    Usuario = usuario;
        //    Senha = senha;
        //}
    }

}
