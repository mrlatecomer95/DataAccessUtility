using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace DataAccessUtility

{
    public class MSSQLDB : DataBase
    {
        private SqlConnection sqlConn = new SqlConnection();
        public MSSQLDB(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            sqlConn.ConnectionString = ConnectionString;
        }

        public override void SetConnection(string value)
        {
            _ConnectionString = value;
            sqlConn.ConnectionString = value;
        }

        public override string GetConnectionString()
        {
            return _ConnectionString;
        }
        
        public override System.Data.DataTable CreateTable(string sql)
        {
            DataTable retval = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = sqlConn;
                cmd.CommandText = sql;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(retval);
                }
            }
            return retval;
        }

        public override IDataParameter CreateParam(string strparamName, object paramValue)
        {
            return new SqlParameter(strparamName, paramValue);
        }

        public override void RunSql(string strSQL, IDataParameter SqlParam)
        {
            try
            {
                sqlConn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = sqlConn;
                    cmd.Parameters.Add(SqlParam);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
        }

        public override void RunSql(string strSQL, IDataParameter[] sqlParam)
        {
            try
            {
                sqlConn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strSQL;
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddRange(sqlParam.ToArray());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
        }
    }
        
}
