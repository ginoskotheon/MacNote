using MacNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNote.DataSource
{
    public class DataAccess
    {
        public static ObservableCollection<Paged> GetPages()
        {
            ObservableCollection<Paged> paged = new ObservableCollection<Paged>(); 
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"Select * from Page";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Paged p = new Paged();
                                p.ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("nID")));
                                p.Title = reader.GetValue(reader.GetOrdinal("PageName")).ToString();
                                p.Content = reader.GetValue(reader.GetOrdinal("Content")).ToString();

                                paged.Add(p);
                            }

                        }
                    }
                }
                return paged;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static void InsertIntoPageDetails(Paged pd)
        {
            try
            {
                using (SqlConnection ctx = new SqlConnection(DBConnection.ConnectionString))
                {
                    ctx.Open();
                    using (SqlCommand cmd = new SqlCommand("Page_Detail_Insert_sp", ctx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PageName", System.Data.SqlDbType.NVarChar).Value = pd.Title;
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdatePageDetails(int id, string content)
        {
            try
            {
                using (SqlConnection ctx = new SqlConnection(DBConnection.ConnectionString))
                {
                    ctx.Open();
                    using (SqlCommand cmd = new SqlCommand("Page_Detail_Update_sp", ctx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@Content", System.Data.SqlDbType.NVarChar).Value = content;
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeletePage(int id)
        {
            try
            {
                using (SqlConnection ctx = new SqlConnection(DBConnection.ConnectionString))
                {
                    ctx.Open();
                    using (SqlCommand cmd = new SqlCommand("Page_Detail_Delete_sp", ctx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
