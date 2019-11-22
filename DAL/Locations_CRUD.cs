using System;
using System.Data;
using System.Data.SqlClient;

public class Locations_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertLocation(Location location)
    {
        SqlCommand cmd = new SqlCommand("InsertarLocalizacion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TravelID", location.TravelID);
        cmd.Parameters.AddWithValue("@name", location.name);
        cmd.Parameters.AddWithValue("@address", location.address);
        cmd.Parameters.AddWithValue("@latitude", location.latitude);
        cmd.Parameters.AddWithValue("@longitude", location.longitude);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }
    public int UpdateLocation(Location location)
    {
        SqlCommand cmd = new SqlCommand("ActualizarLocalizacion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LocationID", location.LocationID);
        cmd.Parameters.AddWithValue("@name", location.name);
        cmd.Parameters.AddWithValue("@address", location.address);
        cmd.Parameters.AddWithValue("@latitude", location.latitude);
        cmd.Parameters.AddWithValue("@longitude", location.longitude);
        cmd.Parameters.AddWithValue("@Travel", location.TravelID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteLocation(int LocationID)
    {
        SqlCommand cmd = new SqlCommand("EliminarLocalizacion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LocationID", LocationID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Location FindLocation(int LocationID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarLocalizacion", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@LocationID", SqlDbType.NVarChar);
        cmd.Parameters["@LocationID"].Value = LocationID;

        connectivity.OpenConnection();
        SqlDataReader result = cmd.ExecuteReader();
        Location location = new Location();

        if (result.HasRows) {
            while (result.Read()) {
                location.LocationID = Convert.ToInt32(result["LocationID"]);
                location.name = Convert.ToString(result["name"]);
                location.address = Convert.ToString(result["address"]);
                location.latitude = Convert.ToString(result["latitude"]);
                location.longitude = Convert.ToString(result["longitude"]);
                location.TravelID = Convert.ToInt32(result["TravelID"]);
            }
        } else {
            location = null;
        }

        result.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return location;
    }

    public DataTable GetLocations()
    {
        SqlCommand cmd = new SqlCommand("ListarLocalizaciones", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        connectivity.CloseConnection();
        return dt;
    }

    public DataTable GetLocationsTravelID(int TravelID)
    {
        SqlCommand cmd = new SqlCommand("ListarLocalizacionesViaje", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@TravelID", SqlDbType.NVarChar);
        cmd.Parameters["@TravelID"].Value = TravelID;
        connectivity.OpenConnection();
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sd.Fill(dt);
        connectivity.CloseConnection();
        return dt;
    }
}

