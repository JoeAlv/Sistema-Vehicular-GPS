using System;
using System.Data;
using System.Data.SqlClient;

public class Travels_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateTravel(Travel travel, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarViaje", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TravelID", travel.TravelID);
        cmd.Parameters.AddWithValue("@UserID", travel.UserID);
        cmd.Parameters.AddWithValue("@VehicleID", travel.VehicleID);
        cmd.Parameters.AddWithValue("@ConditionID", travel.ConditionID);
        cmd.Parameters.AddWithValue("@created_at", travel.created_at);
        
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteTravel(int TravelID)
    {
        SqlCommand cmd = new SqlCommand("EliminarViaje", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TravelID", TravelID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Travel FindTravel(int TravelID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarViaje", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@TravelID", SqlDbType.NVarChar);
        cmd.Parameters["@TravelID"].Value = TravelID;

        connectivity.OpenConnection();
        SqlDataReader result = cmd.ExecuteReader();
        Travel travel = new Travel();

        if (result.HasRows)
        {
            while (result.Read())
            {
                travel.TravelID = Convert.ToInt32(result["TravelID"]);
                travel.UserID = Convert.ToString(result["UserID"]);
                travel.VehicleID = Convert.ToString(result["VehicleID"]);
                travel.ConditionID = Convert.ToInt32(result["ConditionID"]);
                travel.created_at = Convert.ToDateTime(result["created_at"]);
            }
        }
        else
        {
            travel = null;
        }

        result.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return travel;
    }

    public DataTable GetTravels()
    {
        SqlCommand cmd = new SqlCommand("ListarViajes", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        connectivity.OpenConnection();
        SqlDataAdapter sqldata = new SqlDataAdapter(cmd);
        DataTable data = new DataTable();
        sqldata.Fill(data);
        connectivity.CloseConnection();
        return data;
    }

    public DataTable GetTravelsDate(DateTime FechaInicio, DateTime FechaFinal)
    {
        SqlCommand cmd = new SqlCommand("QryViajesFechaIngreso", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
        cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        connectivity.CloseConnection();
        sda.Dispose();
        return dt;
    }
}
