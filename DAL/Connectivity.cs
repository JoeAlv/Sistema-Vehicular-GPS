using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Connectivity
{
    SqlConnection connection = new SqlConnection();

    public SqlConnection Connection()
    {
        try {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["db_connect"].ToString();

        } catch (Exception ex) {
            Console.WriteLine(ex);
            connection.ConnectionString = "Data Source=DESKTOP-A8C1L5H;Initial Catalog=db_WebVehicles;Integrated Security=True";
        }

        return connection;
    }

    public void CloseConnection()
    {
        if (connection.State.Equals(ConnectionState.Open)) connection.Close();
    }

    public void OpenConnection()
    {
        if (connection.State.Equals(ConnectionState.Closed)) connection.Open();
    }
}
