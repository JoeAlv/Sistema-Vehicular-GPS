using System;
using System.Data;
using System.Data.SqlClient;

public class Vehicles_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateVehicle(Vehicle vehicle, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarVehiculo", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
        cmd.Parameters.AddWithValue("@type", vehicle.type);
        cmd.Parameters.AddWithValue("@brand", vehicle.brand);
        cmd.Parameters.AddWithValue("@year", vehicle.year);
        cmd.Parameters.AddWithValue("@engine", vehicle.engine);
        cmd.Parameters.AddWithValue("@transmission", vehicle.transmission);
        cmd.Parameters.AddWithValue("@fuel", vehicle.fuel);
        cmd.Parameters.AddWithValue("@fueltank", vehicle.fueltank);
        cmd.Parameters.AddWithValue("@created_at", vehicle.created_at);
        cmd.Parameters.AddWithValue("@ConditionID", vehicle.ConditionID);
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteVehicle(String VehicleID)
    {
        SqlCommand cmd = new SqlCommand("EliminarVehiculo", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VehicleID", VehicleID);
        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Vehicle FindVehicle(String VehicleID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarVehiculo", connectivity.Connection())
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.Add("@VehicleID", SqlDbType.NVarChar);
        cmd.Parameters["@VehicleID"].Value = VehicleID;

        connectivity.OpenConnection();
        SqlDataReader result = cmd.ExecuteReader();
        Vehicle vehicle = new Vehicle();

        if (result.HasRows) {
            while (result.Read()) {
                vehicle.VehicleID = Convert.ToString(result["VehicleID"]);
                vehicle.type = Convert.ToString(result["type"]);
                vehicle.brand = Convert.ToString(result["brand"]);
                vehicle.year = Convert.ToDateTime(result["year"]);
                vehicle.engine = Convert.ToString(result["engine"]);
                vehicle.transmission = Convert.ToString(result["transmission"]);
                vehicle.fuel = Convert.ToString(result["fuel"]);
                vehicle.fueltank = Convert.ToInt32(result["fueltank"]);
                vehicle.created_at = Convert.ToDateTime(result["created_at"]);
                vehicle.ConditionID = Convert.ToInt32(result["ConditionID"]);
            }
        } else {
            vehicle = null;
        }

        result.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return vehicle;
    }

    public DataTable GetVehicles()
    {
        SqlCommand cmd = new SqlCommand("ListarVehiculos", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable data = new DataTable();
        sda.Fill(data);
        connectivity.CloseConnection();
        return data;
    }

    public DataTable GetVehiclesDate(DateTime FechaInicio, DateTime FechaFinal)
    {
        SqlCommand cmd = new SqlCommand("QryVehiculosFechaIngreso", connectivity.Connection());
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

