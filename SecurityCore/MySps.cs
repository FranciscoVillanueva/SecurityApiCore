using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityCore.Models;
namespace SecurityCore
{
    public class MySps
    {
        protected static string Key = "1234";
        protected static string connString = "Data source=microservicessttk2.database.windows.net;Initial catalog=SecurityApi;persist security info=True;user id=adminSttk;password=@Softtek01";
        public string DesencriptaSp(byte[] hash)
        {
            //string pass;
            string sql = "EXEC dbo.DesencriptaVer2 @key = @Key, @hash = @Hash";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Key";
            param1.Value = Key;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Hash";
            param2.Value = hash;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);

            //SqlDataReader output = cmd.ExecuteReader();
            string output = cmd.ExecuteScalar().ToString();
            conn.Close();
            return output;
        }

        public byte[] EncriptaSp(string word)
        {
            string sql = "EXEC dbo.EncriptaVer2 @key = @Key, @word = @Word";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Key";
            param1.Value = Key;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Word";
            param2.Value = word;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);

            //SqlDataReader output = cmd.ExecuteReader();
            byte[] output = (byte[])cmd.ExecuteScalar();
            conn.Close();
            return output;
        }
    }
}
