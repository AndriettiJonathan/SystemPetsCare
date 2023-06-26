using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PetsCareConsole2._0.BancoDados;
using System.Drawing;

namespace PetsCareConsole2._0
{
    public class AcessoLogin
    {
        public int Id { get; set; }
        public string Usuar { get; set; }
        public string Secret { get; set; }
        public string ISACTIVE { get; set; }

        public string Usuar2 = "";
        public string Secret2 = "";
        public void Acesso()
        {
            Console.WriteLine("Favor, informar o nome de Acesso:");
            Usuar2 = Console.ReadLine();
            
            Console.WriteLine("Insira a sua Senha!");
            Secret2 = Console.ReadLine();

        }
            

        //public AcessoLogin()
        //{
        //    using (var conn = new SqlConnection(CONXBD.DBConnecting))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();

        //        cmd.CommandText = "Select ID, Usuar, Secret, ISACTIVE from Acess where Usuar = @Usuar";
        //        cmd.Parameters.AddWithValue("@Usuar", Usuar);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                Id = reader.GetInt32(0);
        //                Usuar = reader.GetString(1);
        //                Secret = reader.GetString(2);
        //                ISACTIVE = reader.GetString(3);


        //            }
        //        }
        //    }
        //    if (Usuar == Usuar2)
        //                {
        //        Console.WriteLine("Acesso liberado");
        //                }
        //    else
        //    {
        //        Console.WriteLine("Não pode entrar");
        //    }
        //}
        //public AcessoLogin(int id, string usuar, string secret, string isactive)
        //{
        //    Id = id;
        //    Usuar = usuar;
        //    Secret = secret;
        //    ISACTIVE = isactive;
        //}

        //public static List<AcessoLogin> GetAll()
        //{
        //    var result = new List<AcessoLogin>();

        //    using (var conn = new SqlConnection(CONXBD.DBConnecting))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();

        //        cmd.CommandText = "Select ID, Usuar, Secret, ISACTIVE from Acess";
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var login = new AcessoLogin(reader.GetInt32(0),
        //                    reader.GetString(1),
        //                    reader.GetString(2),
        //                    reader.GetString(3));
        //                result.Add(login);
        //            }
        //        }
        //    }

        //    return result;
        //}

        //if ()

    }
}
