using System;
using System.Data;
using System.Data.SqlClient;

namespace Pastelaria.Repository.Infra
{
    public class BaseRepository
    {
        //private static string connString = @"server=DESKTOP-OBT5ICM;Database=teste;integrated security = true; User ID=sa; Password=@Admin;";

        private static SqlConnection conn = null;

        protected SqlCommand command;


        protected void OpenConection()
        {
            try
            {
                if (command.Connection.State == ConnectionState.Broken)
                {
                    command.Connection.Close();
                    command.Connection.Open();
                }

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 53)
                    throw new Exception("falha ao executar conexão com o banco de dados");
                throw;
            }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
            GC.SuppressFinalize(this);
        }

        protected void ExecuteProcedure(string procedureName)
        {
            var conexao = new SqlConnection(@"server=DESKTOP-OBT5ICM;Database=teste;integrated security = true; User ID=sa; Password=@Admin;");
            command = new SqlCommand(procedureName, conexao);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 99999;
        }


        protected IDataReader ExecuteReader()
        {
            OpenConection();
            return command.ExecuteReader();
        }

        protected void AddParameter(string parameterName, object parameterValue)
        {
            if (parameterValue is bool)
                command.Parameters.Add(parameterName, SqlDbType.Bit).Value = parameterValue;
            else
                command.Parameters.AddWithValue(parameterName, parameterValue);
        }

        protected int ExecuteNonQuery()
        {
            try
            {
                OpenConection();
                return command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 53)
                    throw new Exception("falha ao executar conexão com o banco de dados");
                throw;
            }
        }


    }

}
