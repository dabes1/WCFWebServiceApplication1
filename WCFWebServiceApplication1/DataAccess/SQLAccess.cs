using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added usings
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WCFWebServiceApplication1.DataAccess
{
    public class SQLAccess
    {
        public static string GetAbr(int id)
        {
            string _out;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PrimaryDatabase"].ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT abbreviation FROM States WHERE id =" + Convert.ToString(id);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr != null && sdr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sdr);
                        _out = dt.Rows[0]["abbreviation"].ToString();

                        return _out;
                    }
                }            
            }
            
            return null;
        }

        public static string GetName(int id)
        {
            string _out;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PrimaryDatabase"].ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name FROM States WHERE id =" + Convert.ToString(id);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr != null && sdr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sdr);
                        _out = dt.Rows[0]["name"].ToString();

                        return _out;
                    }
                }
            }

            return null;
        }

        public static List<string> GetStatesList()
        {
            List<string> _out = new List<string>();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PrimaryDatabase"].ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT name FROM States";

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr != null && sdr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sdr);

                        foreach (DataRow r in dt.Rows)
                        {
                            _out.Add(r["name"].ToString());
                        }

                        return _out;
                    }
                }
            }

            return null;
        }


        public static DataTable GetDataTable()
        {
            DataTable _dt = new DataTable();

            _dt.Columns.Add("Id", typeof(int));
            _dt.Columns.Add("Value1", typeof(string));
            _dt.Columns.Add("Value2", typeof(string));

            DataRow r = _dt.NewRow();
            r["Id"] = 1;
            r["Value1"] = "Row1 - First Value";
            r["Value2"] = "Row1 - Second Value";
            _dt.Rows.Add(r);

            r = _dt.NewRow();
            r["Id"] = 2;
            r["Value1"] = "Row2 - First Value";
            r["Value2"] = "Row2 - Second Value";
            _dt.Rows.Add(r);

            r = _dt.NewRow();
            r["Id"] = 3;
            r["Value1"] = "Row3 - First Value";
            r["Value2"] = "Row3 - Second Value";
            _dt.Rows.Add(r);

            return null;
        }

    }
}