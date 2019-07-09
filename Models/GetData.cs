using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TaskManager.Models
{
    public class GetData
    {
        public SqlConnection conn;
        public SqlConnection conn1;
        public static String WEBSITE_NAME = "Buyerfox";
        public static String COMPLETE_ORDER_STATUS_ID = "1";
        public static String LOW_STOCK = "10";
        public static String WEBSITE = "buyerfox.studyfield.com";

        public GetData()
        {
            //Connection String
            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString);
            conn1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString);
        }
        public DataTable GetDataWithSP(SqlCommand sc)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                
                SqlCommand cmd = sc;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            
            return dt;
        }
        
        public void ExecuteQueryWithSP(SqlCommand sc)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = sc;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

        }


        public DataTable GetDataTable(string strqry)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cm = new SqlCommand(strqry, conn);
                conn.Open();
                cm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();                
            }
            return dt;
        }

        public int GetMaxId(string SqlQuery)
        {
            int id = 0;
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cm = new SqlCommand(SqlQuery, conn);
                conn.Open();
                cm.ExecuteNonQuery();
                conn.Close();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    id = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            return id;
        }

        public void ExecuteQuery(string SqlQuery)
        {
            try
            {
                SqlCommand cm = new SqlCommand(SqlQuery, conn);
                conn.Open();
                cm.ExecuteNonQuery();
                conn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }



        public string StringEncrypt(string inText)
        {
            string key = "@NB$T|_|DYF!ELD@9879";
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }
        //Decrypting a string
        public string StringDecrypt(string cryptTxt)
        {
            try
            {
                string key = "@NB$T|_|DYF!ELD@9879";
                cryptTxt = cryptTxt.Replace(" ", "+");
                byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aes.Key = crypto.GetBytes(32);
                    aes.IV = crypto.GetBytes(16);
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cStream.Write(bytesBuff, 0, bytesBuff.Length);
                            cStream.Close();
                        }
                        cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                    }
                }
            }
            catch
            {

            }
            return cryptTxt;
        }


    }
}